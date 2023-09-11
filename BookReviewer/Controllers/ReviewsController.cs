using BookReviewer.Models;
using BookReviewer.Models.DbModels;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;

namespace BookReviewer.Controllers
{
    [Authorize(Roles = "NormalUser")]
    public class ReviewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reviews/Create
        public ActionResult Create(int bookId)
        {
            Book book = db.Books.Find(bookId);
            string userId = User.Identity.GetUserId();

            if (book == null)
            {
                return HttpNotFound($"Couldn't find a book with the id '{bookId}'!");
            }

            if (book.Reviews.Any(r => r.UserId.Equals(userId) && r.BookId == bookId))
            {
                return RedirectToAction("Edit", "Reviews", new { bookId = bookId });
            }

            Review model = new Review
            {
                UserId = userId,
                BookId = book.Id,
                Book = book,
            };

            return View(model);
        }

        // POST: Reviews/Create
        [HttpPost]
        public ActionResult Create(Review model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.DateCreated = model.DateEdited = DateTime.Now;
            db.Reviews.Add(model);
            db.SaveChanges();

            return RedirectToAction("Details", "Books", routeValues: new { id = model.BookId });
        }

        // GET: Reviews/Edit/5
        public ActionResult Edit(int bookId)
        {
            string userId = User.Identity.GetUserId();
            Review model = db.Reviews.Find(userId, bookId);

            if (model == null)
            {
                return HttpNotFound($"Couldn't find a review with the user id '{userId}' and the book id '{bookId}'!");
            }

            return View(model);
        }

        // POST: Reviews/Edit/5
        [HttpPost]
        public ActionResult Edit(Review model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Review review = db.Reviews.Find(model.UserId, model.BookId);
            if (review == null)
            {
                return HttpNotFound($"Couldn't find a review with the user id '{model.UserId}' and the book id '{model.BookId}'!");
            }

            review.Rating = model.Rating;
            review.Comment = model.Comment;
            review.DateEdited = DateTime.Now;
            db.SaveChanges();

            return RedirectToAction("Details", "Books", routeValues: new { id = model.BookId }); ;
        }

        // POST: Reviews/Delete/5
        [HttpPost]
        public ActionResult Delete(int bookId)
        {
            string userId = User.Identity.GetUserId();
            Review review = db.Reviews.Find(userId, bookId);

            if (review == null)
            {
                return HttpNotFound($"Couldn't find a review with the user id '{userId}' and the book id '{bookId}'!");
            }

            db.Reviews.Remove(review);
            db.SaveChanges();

            return RedirectToAction("Details", "Books", routeValues: new { id = bookId });
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
