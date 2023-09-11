using System.ComponentModel.DataAnnotations;

namespace BookReviewer.Models.ViewModels
{
    public class AppStats
    {
        [Display(Name = "Number of users")]
        public int NumberOfUsers { get; set; }

        [Display(Name = "Number of books")]
        public int NumberOfBooks { get; set; }

        [Display(Name = "Number of reviews")]
        public int NumberOfReviews { get; set; }
    }
}