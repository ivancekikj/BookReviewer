using BookReviewer.Models;
using BookReviewer.Models.DbModels;
using BookReviewer.Models.ViewModels;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BookReviewer.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private static Random rng = new Random();

        public ActionResult Index()
        {
            ICollection<Review> reviews = getRandomReviews(BooksController.REVIEWS_PER_PAGE);
            return View(reviews);
        }

        private ICollection<Review> getRandomReviews(int n)
        {
            ICollection<Review> result = new HashSet<Review>();

            List<Book> books = db.Books
                .Where(b => b.Reviews.Count > 0)
                .ToList();

            if (books.Count == 0)
                return result;

            Dictionary<int, Book> booksByPosition = new Dictionary<int, Book>();

            if (n >= books.Count)
            {
                for (int i = 0; i < books.Count; i++)
                    booksByPosition[i] = books[i];
            }
            else
            {
                int index;
                for (int i = 0; i < n; i++)
                {
                    do
                    {
                        index = rng.Next(books.Count);
                    } while (booksByPosition.ContainsKey(index));
                    booksByPosition[index] = books[index];
                }
            }

            booksByPosition.Values
                .Select(b =>
                {
                    List<Review> reviews = b.Reviews.ToList();
                    return reviews[rng.Next(reviews.Count)];
                })
                .ForEach(result.Add);

            return result;
        }

        public ActionResult About()
        {
            AppStats model = new AppStats
            {
                NumberOfUsers = db.Users.Count(),
                NumberOfReviews = db.Reviews.Count(),
                NumberOfBooks = db.Books.Count()
            };

            return View(model);
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