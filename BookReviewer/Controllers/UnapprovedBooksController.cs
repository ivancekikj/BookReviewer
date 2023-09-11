using BookReviewer.Models;
using BookReviewer.Models.DbModels;
using BookReviewer.Models.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace BookReviewer.Controllers
{
    public class UnapprovedBooksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            return View(db.UnapprovedBooks
                .OrderBy(b => b.Title)
                .ToList());
        }

        [HttpPost, Authorize(Roles = "Administrator")]
        public JsonResult Approve(int id)
        {
            UnapprovedBook unapprovedBook = db.UnapprovedBooks.Find(id);

            if (unapprovedBook == null)
            {
                return Json(new { isSuccessful = false }, JsonRequestBehavior.AllowGet);
            }

            Book book = new Book
            {
                Title = unapprovedBook.Title,
                Isbn = unapprovedBook.Isbn,
                Genre = unapprovedBook.Genre,
                Description = unapprovedBook.Description,
                DatePublished = unapprovedBook.DatePublished,
                AuthorId = unapprovedBook.AuthorId,
                PublisherId = unapprovedBook.PublisherId,
                Image = ImageHandler.CopyImage(unapprovedBook.Image)
            };

            db.UnapprovedBooks.Remove(unapprovedBook);
            db.Books.Add(book);
            db.SaveChanges();

            return Json(new { isSuccessful = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost, Authorize(Roles = "NormalUser")]
        public ActionResult Create(BookAuthorsPublishers model)
        {
            if (!ModelState.IsValid)
            {
                model.Authors = db.Authors.ToList();
                model.Publishers = db.Publishers.ToList();
                return View("~/Views/Books/Create.cshtml", model);
            }

            UnapprovedBook book = new UnapprovedBook
            {
                Title = model.Book.Title,
                Isbn = model.Book.Isbn,
                Genre = model.Book.Genre,
                Description = model.Book.Description,
                DatePublished = model.Book.DatePublished,
                AuthorId = model.Book.AuthorId,
                PublisherId = model.Book.PublisherId,
                Image = ImageHandler.ToByteArray(model.ImageFile)
            };

            db.UnapprovedBooks.Add(book);
            db.SaveChanges();

            return RedirectToAction("Index", "Books");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}