using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookReviewer.Models.DbModels
{
    public class Publisher
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public string FullName() => $"{Name} ({Location})";
    }
}