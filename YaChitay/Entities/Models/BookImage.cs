namespace YaChitay.Entities.Models
{
    public class BookImage: BaseEntity
    {
        public string ImageData { get; set; }
        public Book Book { get; set; }

        public BookImage()
        {
        }

        public BookImage(string image)
        {
            ImageData = image;
        } 
    }
}
