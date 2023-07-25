using YaChitay.Entities.Models;

namespace YaChitay.Data.Repositories.Interface
{
    public interface IBooksRepository
    {
        Task<bool> AddBook(BookModel model);
    }
}
