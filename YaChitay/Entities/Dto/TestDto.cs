using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YaChitay.Entities.Dto
{
    [NotMapped]
    public class TestDTO
    {
        [Required]
        [Display(Name = "Название")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Автор")]
        public string Author { get; set; }

        [Required]
        [Display(Name = "Жанры")]
        public string Genres { get; set; }

        [Required]
        [Display(Name = "Количество страниц")]
        public int NumberOfPages { get; set; }

        [Required]
        [Display(Name = "Описание")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Фотография")]
        public IFormFile Photo { get; set; }
    }
}
