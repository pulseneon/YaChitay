using System.ComponentModel.DataAnnotations;

namespace YaChitay.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoData { get; set; }
        public int Size { get; set; }
        public int Score { get; set; }
        public int ScoreVotes { get; set; }
        public List<AuthorModel> Author { get; set; } = new();
        public List<GenreModel> Genres { get; set; } = new();

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime Created { get; set; }
        public bool IsDeleted { get; set; }

        public BookModel()
        {
            Created = DateTime.Now;
            Score = 0;
            ScoreVotes = 0;
            IsDeleted = false;
        }
    }
}
