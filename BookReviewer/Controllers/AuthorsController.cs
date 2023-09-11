using BookReviewer.Models;
using BookReviewer.Models.DbModels;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace BookReviewer.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AuthorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Authors
        public ActionResult Index()
        {
            return View(db.Authors
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .ToList());
        }

        // GET: Authors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName")] Author author)
        {
            if (ModelState.IsValid)
            {
                db.Authors.Add(author);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(author);
        }

        // GET: Authors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName")] Author author)
        {
            if (ModelState.IsValid)
            {
                db.Entry(author).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(author);
        }

        // Post: Authors/Delete/5
        [HttpPost]
        public JsonResult Delete(int id)
        {
            Author author = db.Authors.Find(id);
            if (author == null)
                return Json(new { isSuccessful = false }, JsonRequestBehavior.AllowGet);
            db.Authors.Remove(author);
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
