namespace YaChitay.Services.Service
{
    public class ImageConverterService
    {
        static public string? ImageToString(IFormFile photo)
        {
            if (photo == null) return null;

            byte[] bytes;
            using (Stream fs = photo.OpenReadStream())
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    bytes = br.ReadBytes((int)fs.Length);
                }
            }

            return Convert.ToBase64String(bytes, 0, bytes.Length);
        }
    }
}
