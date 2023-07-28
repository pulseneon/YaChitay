using YaChitay.Entities.Models;

namespace YaChitay.Data.Repositories.Interface
{
    public interface IBooksRepository
    {
        Task<bool> AddBook(Book model);
        Task<List<Book>> GetAllBooks();
        Task<List<Book>> GetNewBooks(int amount);
        Task<List<Book>> GetPopularBooks(int amount);
        Task<List<Book>> GetSelectionBooks(int amount);
    }
}
