using System.ComponentModel.DataAnnotations;

namespace YaChitay.Entities.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string? Nickname { get; set; }
        public string? PhotoData { get; set; }
        public string Birthplace { get; set; }
        public string Description { get; set; }
        public bool IsDead { get; set; }
        public bool IsDeleted { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOfDeath { get; set; }
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }

        public Author()
        {
            Created = DateTime.UtcNow;
            IsDeleted = false;
        }
    }
}
