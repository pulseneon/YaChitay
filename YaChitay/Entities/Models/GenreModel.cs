namespace YaChitay.Entities.Models
{
    public class GenreModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; } = new();
    }
}
