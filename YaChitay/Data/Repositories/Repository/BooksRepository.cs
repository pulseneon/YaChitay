using AutoMapper;
using YaChitay.Data.Repositories.Interface;
using YaChitay.Entities.Models;

namespace YaChitay.Data.Repositories.Repository
{
    public class BooksRepository: IBooksRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public BooksRepository(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AddBook(BookModel model)
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
    }
}
