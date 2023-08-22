using YaChitay.Entities.DTO;
using YaChitay.Entities.Models;

namespace YaChitay.Services.Interface
{
    public interface IBooksService
    {
        Task<bool> AddBookAsync(BookRequestDto model);
        Task<Book> GetBookAsync(int id);
        Task<List<Book>> GetAllBooksAsync();
        Task<List<Book>> GetNewBooksAsync(int amount);
        Task<List<Book>> GetPopularBooksAsync(int amount);
    }
}
