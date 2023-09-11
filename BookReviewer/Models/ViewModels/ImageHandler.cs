using System;
using System.Web;

namespace BookReviewer.Models.ViewModels
{
    public class ImageHandler
    {
        public static byte[] ToByteArray(HttpPostedFileBase file)
        {
            if (file == null)
                return null;
            byte[] image = new byte[file.ContentLength];
            file.InputStream.Read(image, 0, file.ContentLength);
            return image;
        }

        public static byte[] CopyImage(byte[] image)
        {
            byte[] newImage = new byte[image.Length];
            image.CopyTo(newImage, 0);
            return newImage;
        }

        public static string GetImageSource(byte[] image)
        {
            if (image == null)
                return "/Content/Images/blank-profile.png";
            return $"data:image/jpg;base64,{Convert.ToBase64String(image)}";
        }
    }
}