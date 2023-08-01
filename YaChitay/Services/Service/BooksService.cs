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
        private readonly IBookImagesRepository _bookImagesRepository;
        private readonly IMapper _mapper;

        public BooksService(IBooksRepository repository, IMapper mapper, IGenresRepository genresRepository,
            IAuthorsRepository authorsRepository, IBookImagesRepository bookImagesRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _genresRepository = genresRepository;
            _authorsRepository = authorsRepository;
            _bookImagesRepository = bookImagesRepository;
        }

        public async Task<bool> AddBookAsync(BookDTO model)
        {
            // todo: implement many authors

            if (model is null) return false;

            var book = _mapper.Map<Book>(model);
            var image = ImageConverterService.ImageToString(model.Photo);

            BookImage bookImage = new(image);
            await _bookImagesRepository.AddPhotoAsync(bookImage);
            book.Image = bookImage;

            // adding book genres 
            var genresList = await SplitGenres(model.Genres);
            book.Genres.AddRange(genresList);

            // finding author
            var author = await _authorsRepository.GetAuthor(model.Author);
            if (author is null) return false;
            book.Authors.Add(author);

            return await _repository.AddBookAsync(book);
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _repository.GetAllBooksAsync();
        }

        public async Task<Book> GetBookAsync(int id) => await _repository.GetBookAsync(id);

        public async Task<List<Book>> GetNewBooksAsync(int amount)
        {
            int count = 20; // число запрашиваемых для рандома новых книг
            var books = await _repository.GetNewBooksAsync(amount);
            // todo: зарандомить всю эту богодельню

            return books.Take(amount).ToList();
        }

        public async Task<List<Book>> GetPopularBooksAsync(int amount)
        {
            int count = 20; // число запрашиваемых для рандома новых книг
            var books = await _repository.GetPopularBooksAsync(amount);
            // todo: зарандомить всю эту богодельню

            return books.Take(amount).ToList();
        }

        // todo: переписать
        private async Task<List<Genre>> SplitGenres(string genres)
        {
            /* разделяем по разделителю и ищем их модели */
            var genresArray = genres.Split(';');
            return await _genresRepository.GetGenresByNameAsync(genresArray);
        }
    }
}
