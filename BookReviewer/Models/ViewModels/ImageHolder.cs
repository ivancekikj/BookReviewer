using System.ComponentModel.DataAnnotations;
using System.Web;

namespace BookReviewer.Models.ViewModels
{
    public abstract class ImageHolder
    {
        [Required, Display(Name = "Image")]
        [HttpPostedFileExtensions(Extensions = "jpg", ErrorMessage = "The image must be a JPG!")]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}