using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using YaChitay.Data.Repositories.Interface;
using YaChitay.Data.Repositories.QueryObjects;
using YaChitay.Entities.Models;

namespace YaChitay.Data.Repositories.Repository
{
    public class BooksRepository : IBooksRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly int pageSize;

        public BooksRepository(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            pageSize = 10;
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

        public async Task<int> GetBooksLastPageNumAsync() => _context.Book.AsNoTracking().OrderByDescending(x => (x.Score != 0) ? x.Score / x.ScoreVotes : 0).Count() / pageSize;

        public async Task<List<Book>> GetBooksPageAsync(int page) => await _context.Book.AsNoTracking().Include(x => x.Image).OrderByDescending(x => (x.Score != 0) ? x.Score / x.ScoreVotes : 0).Page(page, pageSize).ToListAsync();

        public async Task<List<Book>> GetNewBooksAsync(int amount) => await _context.Book.OrderByDescending(x => x.ReleaseDate).Include(x => x.Genres)
            .Include(x => x.Authors)
            .Include(x => x.Image).Take(amount).ToListAsync();

        public async Task<List<Book>> GetPopularBooksAsync(int amount) => await _context.Book.OrderByDescending(x => x.Score).Include(x => x.Genres)
            .Include(x => x.Authors)
            .Include(x => x.Image).Take(amount).ToListAsync();

        public async Task<List<Book>> GetSelectionBooksAsync(int amount) => await _context.Book.Include(x => x.Genres)
            .Include(x => x.Authors)
            .Include(x => x.Image).Where(x => x.Score > 0 && x.Score/x.ScoreVotes >= 4).Take(amount).ToListAsync();
    }
}
