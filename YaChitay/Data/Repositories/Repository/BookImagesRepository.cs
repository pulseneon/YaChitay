using YaChitay.Data.Repositories.Interface;
using YaChitay.Entities.Models;

namespace YaChitay.Data.Repositories.Repository
{
    public class BookImagesRepository : IBookImagesRepository
    {
        private ApplicationContext _context;

        public BookImagesRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> AddPhotoAsync(BookImage model)
        {
            try
            {
                await _context.BookImage.AddAsync(model);
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
