using YaChitay.Utilities;

namespace YaChitay.Entities.Models
{
    public class AuthorImage: BaseEntity
    {
        public string Thumbnail { get; set; } // 150x200px
        public string Low { get; set; } // 450x580px
        public string Original { get; set; }

        public AuthorImage() { }

        public AuthorImage(IFormFile imageFile)
        {
            var originalBitmap = ImageResizerUtility.ResizeIFormFile(imageFile, 400, 700);
            var thumbnailBitmap = ImageResizerUtility.ResizeIFormFile(imageFile, 150, 200);
            var lowBitmap = ImageResizerUtility.ResizeIFormFile(imageFile, 350, 480);

            Thumbnail = ImageConverterUtility.ImageToBase64String(thumbnailBitmap);
            Low = ImageConverterUtility.ImageToBase64String(lowBitmap);
            Original = ImageConverterUtility.ImageToBase64String(originalBitmap);
        }
    }
}
