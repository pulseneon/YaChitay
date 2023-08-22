using System.ComponentModel.DataAnnotations;
using YaChitay.Entities.Models;

namespace YaChitay.Entities.Dto
{
    public class BookResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoData { get; set; }
        public int NumberOfPages { get; set; }
        public int AverageScore { get; set; }
        public List<string> Authors { get; set; }
        public List<string> Genres { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
