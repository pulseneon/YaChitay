using YaChitay.Entities.Models;

namespace YaChitay.Data.Repositories.Interface
{
    public interface IBookImagesRepository
    {
        Task<bool> AddPhotoAsync(BookImage model);
    }
}
