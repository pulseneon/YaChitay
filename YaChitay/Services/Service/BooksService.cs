using AutoMapper;
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
        private readonly int BooksCount;

        public BooksService(IConfiguration configuration, IBooksRepository repository, IMapper mapper, IGenresRepository genresRepository,
            IAuthorsRepository authorsRepository, IBookImagesRepository bookImagesRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _genresRepository = genresRepository;
            _authorsRepository = authorsRepository;
            _bookImagesRepository = bookImagesRepository;

            var booksOptions = configuration.GetSection("Layout:IndexPage");
            BooksCount = booksOptions.GetValue<int>("ShelfRows");
        }

        public async Task<bool> AddBookAsync(BookDTO model)
        {
            // todo: реализовать многоавторство

            if (model is null) return false;

            var book = _mapper.Map<Book>(model);

            // загрузка фотографии
            BookImage bookImage = new(model.Photo);
            await _bookImagesRepository.AddPhotoAsync(bookImage);
            book.Image = bookImage;

            // добавление жанров
            book.Genres.AddRange(await SplitGenres(model.Genres));

            // нахождение и добавление автора
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
            var random = new Random();

            var books = await _repository.GetNewBooksAsync(BooksCount);
            books = books.OrderBy(x => random.Next()).ToList();

            return books.Take(amount).ToList();
        }

        public async Task<List<Book>> GetPopularBooksAsync(int amount)
        {
            var random = new Random();
            var books = await _repository.GetPopularBooksAsync(BooksCount);

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
