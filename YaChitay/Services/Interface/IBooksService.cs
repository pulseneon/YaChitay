using YaChitay.Entities.DTO;
using YaChitay.Entities.Models;

namespace YaChitay.Services.Interface
{
    public interface IBooksService
    {
        Task<bool> AddBook(BookDTO model);
        Task<Book> GetBook(int id);
        Task<List<Book>> GetAllBooks();
        Task<List<Book>> GetNewBooks(int amount);
        Task<List<Book>> GetPopularBooks(int amount);
    }
}
