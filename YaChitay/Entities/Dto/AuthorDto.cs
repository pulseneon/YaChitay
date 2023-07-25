using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YaChitay.Entities.DTO
{
    [NotMapped]
    public class AuthorDTO
    {
        [Required]
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        [Required]
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }
        [Required]
        [Display(Name = "Псевдоним")]
        public string? Nickname { get; set; }
        [Display(Name = "Фотография")]
        public IFormFile? Photo { get; set; }
        [Display(Name = "Место рождения")]
        public string? Birthplace { get; set; }
        [Required]
        [Display(Name = "Краткая биография")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Мертв?")]
        public bool IsDead { get; set; }
        [Required]
        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Дата смерти")]
        [DataType(DataType.Date)]
        public DateTime? DateOfDeath { get; set; }
    }
}
