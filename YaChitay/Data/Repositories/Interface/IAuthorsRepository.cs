using YaChitay.Entities.DTO;
using YaChitay.Entities.Models;

namespace YaChitay.Data.Repositories.Interface
{
    public interface IAuthorsRepository
    {
        Task<Author> GetAuthorAsync(int id);
        Task<Author> GetAuthorAsync(string name, string patronymic, string surname);
        Task<Author> GetAuthorAsync(string fullname);
        Task<List<Author>> GetAllAsync();
        Task<List<Author>> GetAllAsync(int amount);
        Task<bool> AddAuthorAsync(Author model);
    }
}
