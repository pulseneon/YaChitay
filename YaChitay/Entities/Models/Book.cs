using System.ComponentModel.DataAnnotations;

namespace YaChitay.Entities.Models
{
    public class Book: BaseEntity
    {
        public string Title { get; set; }
        // public string OrigTitle { get; set; }
        public string Description { get; set; }
        public int? ImageId { get; set; }
        public BookImage? Image { get; set; }
        public int NumberOfPages { get; set; }
        public int Score { get; set; }
        public int ScoreVotes { get; set; }
        public List<Author> Authors { get; set; } = new();
        public List<Genre> Genres { get; set; } = new();
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }
        public bool IsDeleted { get; set; }

        public Book()
        {
            Created = DateTime.Now;
            Score = 0;
            ScoreVotes = 0;
            IsDeleted = false;
        }
    }
}
