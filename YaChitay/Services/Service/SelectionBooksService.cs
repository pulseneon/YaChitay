using YaChitay.Data.Repositories.Repository;
using YaChitay.Entities;
using YaChitay.Entities.Models;

namespace YaChitay.Services.Service
{
    public class SelectionBooksService: BackgroundService
    {
        //private readonly BooksRepository _repository;
        // private readonly ILogger _logger;
        //private readonly SelectionBooksCache _cache;

        public SelectionBooksService() // BooksRepository repository, 
        { // ILogger logger
            //_repository = repository; // SelectionBooksCache cache
            // _logger = logger;
            // _cache = cache;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (stoppingToken.IsCancellationRequested)
            {
                // todo: заменить число константой 
                // todo: настроить и переписать эту богодельню
                int booksCount = 5;
                //List<Book> books = (await _repository.GetSelectionBooks(100)).Take(booksCount).ToList();
                Console.WriteLine("test");
                // _cache.SetBooks(books);
                // _logger.LogInformation("Have been updated in the background {booksCount} selection books", booksCount);
                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }
        }
    }
}
