using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookReviewer.Models.DbModels
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "The first name should be a single capitalized word!")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "The last name should be a single capitalized word!")]
        public string LastName { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public string FullName() => $"{FirstName} {LastName}";
    }
}