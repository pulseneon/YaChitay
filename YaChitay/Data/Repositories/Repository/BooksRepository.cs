using AutoMapper;
using Microsoft.EntityFrameworkCore;
using YaChitay.Data.Repositories.Interface;
using YaChitay.Entities.Models;

namespace YaChitay.Data.Repositories.Repository
{
    public class BooksRepository : IBooksRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public BooksRepository(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AddBookAsync(Book model)
        {
            try
            {
                await _context.Book.AddAsync(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Book>> GetAllBooksAsync() => await _context.Book.ToListAsync();

        public async Task<Book> GetBookAsync(int id) => await _context.Book.Include(x => x.Genres)
            .Include(x => x.Authors)
            .Include(x => x.Image)
            .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<List<Book>> GetNewBooksAsync(int amount) => await _context.Book.OrderByDescending(x => x.ReleaseDate).Take(amount).ToListAsync();

        public async Task<List<Book>> GetPopularBooksAsync(int amount) => await _context.Book.OrderByDescending(x => x.Score).Take(amount).ToListAsync();

        public async Task<List<Book>> GetSelectionBooksAsync(int amount) => await _context.Book.Where(x => x.Score > 0 && x.Score/x.ScoreVotes > 4).Take(amount).ToListAsync();
    }
}
