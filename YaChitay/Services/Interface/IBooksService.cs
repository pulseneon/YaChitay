using YaChitay.Entities.DTO;

namespace YaChitay.Services.Interface
{
    public interface IBooksService
    {
        Task<bool> AddBook(BookDTO model);
    }
}
