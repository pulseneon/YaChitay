using Microsoft.EntityFrameworkCore;
using YaChitay.Data.Repositories.Interface;
using YaChitay.Entities.Models;

namespace YaChitay.Data.Repositories.Repository
{
    public class GenresRepository : IGenresRepository
    {
        private readonly ApplicationContext _context;
        public GenresRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Genre>> GetGenresByName(string[] genresNames) => await _context.Genre.Where(g => genresNames.Contains(g.Name)).ToListAsync();
    }
}
