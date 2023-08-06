using System.Drawing;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing.Imaging;

namespace YaChitay.Utilities
{
    public class ImageConverterUtility
    {
        static public string? ImageToBase64String(IFormFile file)
        {
            if (file == null) return null;

            byte[] bytes;
            using (Stream fs = file.OpenReadStream())
            {
                using (BinaryReader br = new(fs))
                {
                    bytes = br.ReadBytes((int)fs.Length);
                }
            }

            return Convert.ToBase64String(bytes, 0, bytes.Length);
        }

        static public string? ImageToBase64String(Bitmap bitmap)
        {
            MemoryStream ms = new();
            bitmap.Save(ms, ImageFormat.Jpeg);
            byte[] bytes = ms.ToArray();

            return Convert.ToBase64String(bytes);
        }
    }
}
