using BookReviewer.Models.DbModels;
using PagedList;

namespace BookReviewer.Models.ViewModels
{
    public class BookDetails
    {
        public Book Book { get; set; }
        public float? AverageRating { get; set; }
        public IPagedList<Review> Reviews { get; set; }
        public string UserId { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
    }
}