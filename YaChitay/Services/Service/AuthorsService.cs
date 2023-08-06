using AutoMapper;
using YaChitay.Data.Repositories.Interface;
using YaChitay.Entities.DTO;
using YaChitay.Entities.Models;
using YaChitay.Services.Interface;
using YaChitay.Utilities;

namespace YaChitay.Services.Service
{
    public class AuthorsService : IAuthorsService
    {
        private readonly IAuthorsRepository _repository;
        private readonly IMapper _mapper;

        public AuthorsService(IAuthorsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> AddAuthor(AuthorDTO model)
        {
            // todo: вынести фотографию автора в отдельную таблицу бд

            if (model is null || model.DateOfBirth > model.DateOfDeath) return false;

            var author = _mapper.Map<Author>(model);
            
            if (model.Photo != null)
            {
                var photo = ImageConverterUtility.ImageToBase64String(model.Photo);
                author.PhotoData = photo;
            }

            return await _repository.AddAuthor(author);
        }
    }
}
