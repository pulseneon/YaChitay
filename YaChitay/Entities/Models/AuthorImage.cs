using System.Drawing;
using System.IO;
using YaChitay.Utilities;

namespace YaChitay.Entities.Models
{
    public class AuthorImage: BaseEntity
    {
        public string Thumbnail { get; set; } // 150x200px
        public string Low { get; set; } // 450x580px
        public string Original { get; set; }

        public AuthorImage() { }

        public AuthorImage(string filePath)
        {
            var originalBitmap = new Bitmap(Image.FromFile(filePath));
            var thumbnailBitmap = ImageResizerUtility.Resize(filePath, 150, 200);
            var lowBitmap = ImageResizerUtility.Resize(filePath, 350, 480);

            Thumbnail = ImageConverterUtility.ImageToBase64String(thumbnailBitmap);
            Low = ImageConverterUtility.ImageToBase64String(lowBitmap);
            Original = ImageConverterUtility.ImageToBase64String(originalBitmap);
        }

        public AuthorImage(IFormFile imageFile)
        {
            var originalBitmap = ImageResizerUtility.Resize(imageFile, 400, 700);
            var thumbnailBitmap = ImageResizerUtility.Resize(imageFile, 150, 200);
            var lowBitmap = ImageResizerUtility.Resize(imageFile, 350, 480);

            Thumbnail = ImageConverterUtility.ImageToBase64String(thumbnailBitmap);
            Low = ImageConverterUtility.ImageToBase64String(lowBitmap);
            Original = ImageConverterUtility.ImageToBase64String(originalBitmap);
        }
    }
}
