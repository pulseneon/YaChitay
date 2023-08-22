using System.ComponentModel.DataAnnotations;

namespace YaChitay.Entities.Models
{
    public class Author: BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string? Nickname { get; set; }
        public AuthorImage? Image { get; set; }
        public string? Birthplace { get; set; }
        public string? Deathplace { get; set; }
        public string Description { get; set; }
        public string? Quote { get; set; }
        public bool IsDead { get; set; }
        public bool IsDeleted { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOfDeath { get; set; }
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }
        public List<Book> Books { get; set; }
        public int Score { get; set; }
        public int ScoreVotes { get; set; }
        public string? WikiUrl { get; set; }

        public Author()
        {
            Created = DateTime.UtcNow;
            IsDeleted = false;
        }
    }
}
