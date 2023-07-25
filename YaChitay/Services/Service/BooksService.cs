using AutoMapper;
using Microsoft.EntityFrameworkCore;
using YaChitay.Data.Repositories.Interface;
using YaChitay.Entities.DTO;
using YaChitay.Entities.Models;
using YaChitay.Services.Interface;

namespace YaChitay.Services.Service
{
    public class BooksService : IBooksService
    {
        private readonly IBooksRepository _repository;
        private readonly IGenresRepository _genresRepository;
        private readonly IAuthorsRepository _authorsRepository;
        private readonly IMapper _mapper;

        public BooksService(IBooksRepository repository, IMapper mapper, IGenresRepository genresRepository,
            IAuthorsRepository authorsRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _genresRepository = genresRepository;
            _authorsRepository = authorsRepository;
        }

        public async Task<bool> AddBook(BookDTO model)
        {
            // todo: implement many authors

            if (model is null) return false;

            var book = _mapper.Map<BookModel>(model);
            var image = ImageConverter.ImageToString(model.Photo);
            book.PhotoData = image;

            // adding book genres 
            var genresList = await SplitGenres(model.Genres);
            book.Genres.AddRange(genresList);

            // finding author
            var author = await _authorsRepository.GetAuthor(model.Author);
            if (author is null) return false;
            book.Author.Add(author);

            return await _repository.AddBook(book);
        }

        // todo: think more about logic
        private async Task<List<GenreModel>> SplitGenres(string genres)
        {
            /* we get genres separated by semicolons and return a list of models */
            var genresArray = genres.Split(';');
            return await _genresRepository.GetGenresByName(genresArray);
        }
    }
}
