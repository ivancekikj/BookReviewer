using BookReviewer.Models;
using BookReviewer.Models.DbModels;
using BookReviewer.Models.ViewModels;
using Microsoft.AspNet.Identity;
using PagedList;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace BookReviewer.Controllers
{
    public class BooksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public static readonly int REVIEWS_PER_PAGE = 6;

        // GET: Books
        public ActionResult Index()
        {
            var books = db.Books
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .OrderBy(b => b.Title);
            return View(books.ToList());
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id, int page = 1)
        {
            if (page <= 0)
                page = 1;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }

            BookDetails model = new BookDetails
            {
                Book = book,
                AverageRating = book.Reviews.Count > 0
                    ? (float?)book.Reviews
                        .Select(r => r.Rating)
                        .Average()
                    : null,
                UserId = User.IsInRole("NormalUser") ? User.Identity.GetUserId() : null,
                Reviews = book.Reviews
                    .OrderByDescending(r => r.DateEdited)
                    .ToPagedList(page, REVIEWS_PER_PAGE),
                PageSize = REVIEWS_PER_PAGE,
                CurrentPage = page
            };

            return View(model);
        }

        // GET: Books/Create
        [Authorize]
        public ActionResult Create()
        {
            BookAuthorsPublishers model = new BookAuthorsPublishers();
            model.Book = new Book();

            model.Authors = db.Authors.ToList();
            model.Publishers = db.Publishers.ToList();

            return View(model);
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create(BookAuthorsPublishers model)
        {
            if (ModelState.IsValid)
            {
                model.Book.Image = ImageHandler.ToByteArray(model.ImageFile);
                db.Books.Add(model.Book);
                db.SaveChanges();
                return RedirectToAction("Index", "Books");
            }

            model.Authors = db.Authors.ToList();
            model.Publishers = db.Publishers.ToList();

            return View(model);
        }

        // GET: Books/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }

            BookAuthorsPublishers model = new BookAuthorsPublishers();
            model.Book = book;
            model.Authors = db.Authors.ToList();
            model.Publishers = db.Publishers.ToList();

            return View(model);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(BookAuthorsPublishers model)
        {
            if (ModelState.IsValid)
            {
                Book book = db.Books.Find(model.Book.Id);

                book.Title = model.Book.Title;
                book.Isbn = model.Book.Isbn;
                book.Genre = model.Book.Genre;
                book.Description = model.Book.Description;
                book.DatePublished = model.Book.DatePublished;
                book.AuthorId = model.Book.AuthorId;
                book.PublisherId = model.Book.PublisherId;
                book.Image = ImageHandler.ToByteArray(model.ImageFile);

                db.SaveChanges();
                return RedirectToAction("Index", "Books");
            }
            model.Authors = db.Authors.ToList();
            model.Publishers = db.Publishers.ToList();
            return View(model);
        }

        // POST: Books/Delete/5
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id)
        {
            Book book = db.Books.Find(id);
            if (book == null)
                return Json(new { isSuccessful = false }, JsonRequestBehavior.AllowGet);
            db.Books.Remove(book);
            db.SaveChanges();
            return Json(new { isSuccessful = true }, JsonRequestBehavior.AllowGet);
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
