using YaChitay.Entities.DTO;
using YaChitay.Entities.Models;

namespace YaChitay.Data.Repositories.Interface
{
    public interface IAuthorsRepository
    {
        Task<Author> GetAuthor(int id);
        Task<Author> GetAuthor(string name, string patronymic, string surname);
        Task<Author> GetAuthor(string fullname);
        Task<List<Author>> GetAll();
        Task<List<Author>> GetAll(int amount);
        Task<bool> AddAuthor(Author model);
    }
}
