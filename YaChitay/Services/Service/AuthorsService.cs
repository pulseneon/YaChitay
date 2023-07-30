using AutoMapper;
using Microsoft.EntityFrameworkCore;
using YaChitay.Data;
using YaChitay.Data.Repositories.Interface;
using YaChitay.Entities.DTO;
using YaChitay.Entities.Models;
using YaChitay.Services.Interface;

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
            if (model is null || model.DateOfBirth > model.DateOfDeath) return false;

            var author = _mapper.Map<Author>(model);
            
            if (model.Photo != null)
            {
                var photo = ImageConverterService.ImageToString(model.Photo);
                author.PhotoData = photo;
            }

            return await _repository.AddAuthor(author);
        }
    }
}
