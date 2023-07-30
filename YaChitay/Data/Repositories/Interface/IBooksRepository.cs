using YaChitay.Entities.Models;

namespace YaChitay.Data.Repositories.Interface
{
    public interface IBooksRepository
    {
        Task<bool> AddBookAsync(Book model);
        Task<Book> GetBookAsync(int id);
        Task<List<Book>> GetAllBooksAsync();
        Task<List<Book>> GetNewBooksAsync(int amount);
        Task<List<Book>> GetPopularBooksAsync(int amount);
        Task<List<Book>> GetSelectionBooksAsync(int amount);
    }
}
