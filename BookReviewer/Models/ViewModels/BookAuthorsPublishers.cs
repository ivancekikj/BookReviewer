using BookReviewer.Models.DbModels;
using System.Collections.Generic;

namespace BookReviewer.Models.ViewModels
{
    public class BookAuthorsPublishers : ImageHolder
    {
        public Book Book { get; set; }
        public ICollection<Author> Authors { get; set; }
        public ICollection<Publisher> Publishers { get; set; }
    }
}