using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing;

namespace YaChitay.Utilities
{
    public class ImageResizerUtility
    {
        static public Bitmap Resize(IFormFile file, int width, int height)
        {
            Image image = Image.FromStream(file.OpenReadStream(), true, true);
            var newImage = new Bitmap(width, height);
            using (var g = Graphics.FromImage(newImage))
            {
                g.DrawImage(image, 0, 0, width, height);
            }

            return newImage;
        }

        static public Bitmap Resize(string path, int width, int height)
        {
            Bitmap image = new Bitmap(Image.FromFile(path));
            var newImage = new Bitmap(width, height);
            using (var g = Graphics.FromImage(newImage))
            {
                g.DrawImage(image, 0, 0, width, height);
            }

            return newImage;
        }
    }
}
