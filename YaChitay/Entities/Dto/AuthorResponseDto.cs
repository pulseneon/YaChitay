using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YaChitay.Entities.Models;

namespace YaChitay.Entities.Dto
{
    [NotMapped]
    public class AuthorResponseDto
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Initials { get; set; }
        public string? Nickname { get; set; }
        public AuthorImage? Image { get; set; }
        public string? Birthplace { get; set; }
        public string? Deathplace { get; set; }
        public string Description { get; set; }
        public string? Quote { get; set; }
        public bool IsDead { get; set; }
        public string DateOfBirth { get; set; }
        public string? DateOfDeath { get; set; }
        public int LivedYears { get; set; }
        public List<Book> Books { get; set; }
        public int AverageScore { get; set; }
        public int ScoreVotes { get; set; }
        public string? WikiUrl { get; set; }
    }
}
