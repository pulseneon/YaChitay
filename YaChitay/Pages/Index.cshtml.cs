using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;
using System.Configuration;
using YaChitay.Entities.Cache;
using YaChitay.Entities.Models;
using YaChitay.Services.Service;

namespace YaChitay.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _config;
        private readonly BooksService _service;
        private readonly SelectionBooksCache _cache;

        public IndexModel(ILogger<IndexModel> logger, BooksService service, IConfiguration configuration, SelectionBooksCache cache)
        {
            _service = service;
            _logger = logger;
            _config = configuration;
            _cache = cache;
        }

        public List<Book> NewBooks { get; set; } = default!;
        public List<Book> PopularBooks { get; set; } = default!;
        public List<Book> SelectionBooks { get; set; } = default!;
        public int BooksCount { get; set; }

        public async Task OnGetAsync()
        {
            var booksOptions = _config.GetSection("Layout:IndexPage");
            BooksCount = booksOptions.GetValue<int>("ShelfRows");

            NewBooks = await _service.GetNewBooksAsync(BooksCount);
            PopularBooks = await _service.GetPopularBooksAsync(BooksCount);
            SelectionBooks = _cache.BooksOfDay;
        }
    }
}