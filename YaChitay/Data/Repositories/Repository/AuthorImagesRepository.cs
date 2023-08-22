using YaChitay.Data.Repositories.Interface;
using YaChitay.Entities.Models;

namespace YaChitay.Data.Repositories.Repository
{
    public class AuthorImagesRepository : IAuthorImagesRepository
    {
        private ApplicationContext _context;

        public AuthorImagesRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> AddPhotoAsync(AuthorImage model)
        {
            try
            {
                await _context.AuthorImage.AddAsync(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
