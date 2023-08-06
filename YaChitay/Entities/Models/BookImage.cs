using YaChitay.Utilities;

namespace YaChitay.Entities.Models
{
    public class BookImage: BaseEntity
    {
        public string Thumbnail { get; set; } // 150x200px
        public string Low { get; set; } // 450x580px
        public string Original { get; set; } // оригинальный размер фото

        public BookImage() { }

        public BookImage(IFormFile imageFile)
        {
            var thumbnailBitmap = ImageResizerUtility.ResizeIFormFile(imageFile, 150, 200);
            var lowBitmap = ImageResizerUtility.ResizeIFormFile(imageFile, 450, 580);

            Thumbnail = ImageConverterUtility.ImageToBase64String(thumbnailBitmap);
            Low = ImageConverterUtility.ImageToBase64String(lowBitmap);
            Original = ImageConverterUtility.ImageToBase64String(imageFile);
        } 
    }
}
