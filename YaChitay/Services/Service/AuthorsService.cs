using AutoMapper;
using YaChitay.Data.Repositories.Interface;
using YaChitay.Entities.DTO;
using YaChitay.Entities.Models;
using YaChitay.Services.Interface;

namespace YaChitay.Services.Service
{
    public class AuthorsService : IAuthorsService
    {
        private readonly IWebHostEnvironment _env;
        private readonly IAuthorsRepository _repository;
        private readonly IAuthorImagesRepository _imagesRepo;
        private readonly IMapper _mapper;

        public AuthorsService(IAuthorsRepository repository, IAuthorImagesRepository imagesRepository, IMapper mapper, IWebHostEnvironment env)
        {
            _repository = repository;
            _imagesRepo = imagesRepository;
            _mapper = mapper;
            _env = env;
        }

        public async Task<bool> AddAuthorAsync(AuthorRequestDto model)
        {
            if (model is null || model.DateOfBirth > model.DateOfDeath && model.IsDead) return false;

            var author = _mapper.Map<Author>(model);

            AuthorImage authorImage = (model.Photo != null) ? new(model.Photo) : new(Path.Combine(_env.WebRootPath, "images", "author.png"));
            await _imagesRepo.AddPhotoAsync(authorImage);
            author.Image = authorImage;

            return await _repository.AddAuthorAsync(author);
        }

        public async Task<Author> GetAuthorAsync(int id)
        {
            var author = await _repository.GetAuthorAsync(id);
            return author;
        }
    }
}
