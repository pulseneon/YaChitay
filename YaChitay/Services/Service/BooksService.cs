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

            var book = _mapper.Map<Book>(model);
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

        public async Task<List<Book>> GetAllBooks()
        {
            return await _repository.GetAllBooks();
        }

        public Task<Book> GetBook(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Book>> GetNewBooks(int amount)
        {
            int count = 20; // число запрашиваемых для рандома новых книг
            var books = await _repository.GetNewBooks(amount);
            // todo: зарандомить всю эту богодельню

            return books.Take(amount).ToList();
        }

        public async Task<List<Book>> GetPopularBooks(int amount)
        {
            int count = 20; // число запрашиваемых для рандома новых книг
            var books = await _repository.GetPopularBooks(amount);
            // todo: зарандомить всю эту богодельню

            return books.Take(amount).ToList();
        }

        // todo: переписать
        private async Task<List<GenreModel>> SplitGenres(string genres)
        {
            /* разделяем по разделителю и ищем их модели */
            var genresArray = genres.Split(';');
            return await _genresRepository.GetGenresByName(genresArray);
        }
    }
}
