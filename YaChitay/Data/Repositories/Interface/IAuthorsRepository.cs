using YaChitay.Entities.DTO;
using YaChitay.Entities.Models;

namespace YaChitay.Data.Repositories.Interface
{
    public interface IAuthorsRepository
    {
        Task<AuthorModel> GetAuthor(int id);
        Task<AuthorModel> GetAuthor(string name, string patronymic, string surname);
        Task<AuthorModel> GetAuthor(string fullname);
        Task<List<AuthorModel>> GetAll();
        Task<List<AuthorModel>> GetAll(int amount);
        Task<bool> AddAuthor(AuthorModel model);
    }
}
