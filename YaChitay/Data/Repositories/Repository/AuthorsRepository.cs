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

        public async Task<bool> AddAuthor(AuthorModel model)
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

        public async Task<AuthorModel> GetAuthor(int id) => await _context.Author.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<List<AuthorModel>> GetAll() => await _context.Author.ToListAsync();

        public async Task<List<AuthorModel>> GetAll(int amount) => await _context.Author.Take(amount).ToListAsync();

        public async Task<AuthorModel> GetAuthor(string name, string patronymic, string surname) => await _context.Author.FirstOrDefaultAsync(x => x.Name == name && x.Patronymic == patronymic && x.Surname == surname);

        public async Task<AuthorModel> GetAuthor(string fullname) => await _context.Author.FirstOrDefaultAsync(x => (x.Name + " " + x.Patronymic + " " + x.Surname) == fullname);
    }
}
