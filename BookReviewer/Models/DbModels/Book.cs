using BookReviewer.Models.AbstractClasses;
using System.Collections.Generic;

namespace BookReviewer.Models.DbModels
{
    public class Book : AbstractBook
    {
        public virtual ICollection<Review> Reviews { get; set; }
    }
}