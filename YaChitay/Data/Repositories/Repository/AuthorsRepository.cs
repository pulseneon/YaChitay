using AutoMapper;
using Microsoft.EntityFrameworkCore;
using YaChitay.Data;
using YaChitay.Data.Repositories.Interface;
using YaChitay.Entities.DTO;
using YaChitay.Entities.Models;

namespace YaChitay.Entities.Repository
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public AuthorsRepository(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AddAuthorAsync(Author model)
        {
            try
            {
                if (model is null) return false;
                await _context.Author.AddAsync(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Author> GetAuthorAsync(int id) => await _context.Author
            .Include(x => x.Books).ThenInclude(x => x.Genres)
            .Include(x => x.Image)
            .AsNoTracking().
            FirstOrDefaultAsync(x => x.Id == id);

        public async Task<List<Author>> GetAllAsync() => await _context.Author.ToListAsync();

        public async Task<List<Author>> GetAllAsync(int amount) => await _context.Author.Take(amount).ToListAsync();

        public async Task<Author> GetAuthorAsync(string name, string patronymic, string surname) => await _context.Author.FirstOrDefaultAsync(x => x.Name == name && x.Patronymic == patronymic && x.Surname == surname);

        public async Task<Author> GetAuthorAsync(string fullname) => await _context.Author.FirstOrDefaultAsync(x => (x.Name + " " + x.Patronymic + " " + x.Surname) == fullname);
    }
}
