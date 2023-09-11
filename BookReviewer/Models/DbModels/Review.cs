using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace BookReviewer.Models.DbModels
{
    public class Review
    {
        public static List<SelectListItem> RatingsList;

        static Review()
        {
            RatingsList = new List<SelectListItem>();
            for (int i = 0; i <= 10; i++)
                RatingsList.Add(new SelectListItem
                {
                    Value = i.ToString(),
                    Text = i.ToString(),
                });
        }

        [Key, Column(Order = 0)]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Key, Column(Order = 1)]
        public int BookId { get; set; }

        public virtual Book Book { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Created")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateCreated { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Edited")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateEdited { get; set; }

        [Required, Range(0, 10)]
        public int Rating { get; set; }

        [Required]
        public string Comment { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Review review &&
                   UserId == review.UserId &&
                   BookId == review.BookId &&
                   DateCreated == review.DateCreated &&
                   DateEdited == review.DateEdited &&
                   Rating == review.Rating &&
                   Comment == review.Comment;
        }

        public override int GetHashCode()
        {
            int hashCode = 1691005613;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UserId);
            hashCode = hashCode * -1521134295 + BookId.GetHashCode();
            hashCode = hashCode * -1521134295 + DateCreated.GetHashCode();
            hashCode = hashCode * -1521134295 + DateEdited.GetHashCode();
            hashCode = hashCode * -1521134295 + Rating.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Comment);
            return hashCode;
        }
    }
}