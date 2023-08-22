using YaChitay.Entities.Models;

namespace YaChitay.Data.Repositories.Interface
{
    public interface IAuthorImagesRepository
    {
        Task<bool> AddPhotoAsync(AuthorImage model);
    }
}
