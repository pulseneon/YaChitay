using YaChitay.Entities.Models;

namespace YaChitay.Data.Repositories.Interface
{
    public interface IGenresRepository
    {
        Task<List<Genre>> GetGenresByName(string[] genresNames);
    }
}
