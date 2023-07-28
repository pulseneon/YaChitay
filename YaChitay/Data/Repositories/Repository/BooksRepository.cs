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

        public async Task<bool> AddBook(Book model)
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

        public async Task<List<Book>> GetAllBooks() => await _context.Book.ToListAsync();

        public async Task<List<Book>> GetNewBooks(int amount) => await _context.Book.OrderByDescending(x => x.ReleaseDate).Take(amount).ToListAsync();

        public async Task<List<Book>> GetPopularBooks(int amount) => await _context.Book.OrderByDescending(x => x.Score).Take(amount).ToListAsync();

        public async Task<List<Book>> GetSelectionBooks(int amount) => await _context.Book.Where(x => x.Score/x.ScoreVotes > 4).Take(amount).ToListAsync();
    }
}
