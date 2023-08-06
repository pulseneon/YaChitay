using YaChitay.Data.Repositories.Interface;
using YaChitay.Entities.Cache;

namespace YaChitay.Services.Service
{
    public class UpdateNewBooksService: BackgroundService
    {
        private readonly ILogger _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly NewBooksCache _cache;
        private readonly IConfiguration _configuration;

        public UpdateNewBooksService(IConfiguration configuration, IServiceProvider serviceProvider, NewBooksCache cache,
            ILogger<UpdateBooksOfDayService> logger)
        {
            _configuration = configuration;
            _serviceProvider = serviceProvider;
            _cache = cache;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var booksOptions = _configuration.GetSection("Layout:IndexPage");
            int booksCount = booksOptions.GetValue<int>("ShelfRows");
            int mixingSize = booksOptions.GetValue<int>("MixingSize");

            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var service = scope.ServiceProvider.GetRequiredService<IBooksRepository>();
                    var books = await service.GetNewBooksAsync(mixingSize);

                    var random = new Random();
                    books = books.OrderBy(x => random.Next()).ToList();
                    _cache.SetBooks(books.Take(booksCount).ToList());
                }

                _logger.LogInformation("Have been updated in the background new books: {0} ({1} of {2})", _cache.GetBooksNames(),
                    _cache.Books.Count, booksCount);
                await Task.Delay(TimeSpan.FromHours(12), stoppingToken).ConfigureAwait(false);
            }
        }
    }
}