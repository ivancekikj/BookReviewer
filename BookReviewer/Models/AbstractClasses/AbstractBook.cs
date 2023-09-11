using BookReviewer.Models.DbModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace BookReviewer.Models.AbstractClasses
{
    public abstract class AbstractBook
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required, Display(Name = "ISBN")]
        public string Isbn { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Genre { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Published")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DatePublished { get; set; }

        public byte[] Image { get; set; }

        [Display(Name = "Author")]
        public int AuthorId { get; set; }

        [Display(Name = "Publisher")]
        public int PublisherId { get; set; }

        public virtual Author Author { get; set; }

        public virtual Publisher Publisher { get; set; }
    }
}