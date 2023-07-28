using System.ComponentModel.DataAnnotations;

namespace YaChitay.Entities.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoData { get; set; }
        public int Size { get; set; }
        public int Score { get; set; }
        public int ScoreVotes { get; set; }
        public List<Author> Author { get; set; } = new();
        public List<GenreModel> Genres { get; set; } = new();

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
