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
        private readonly BooksOfDayCache _selectionBooksCache;
        private readonly NewBooksCache _newBooksCache;
        private readonly PopularBooksCache _popularBooksCache;

        public IndexModel(ILogger<IndexModel> logger, BooksService service, IConfiguration configuration, BooksOfDayCache selectionCache,
            NewBooksCache newBooksCache, PopularBooksCache popularBooksCache)
        {
            _service = service;
            _logger = logger;
            _config = configuration;
            _selectionBooksCache = selectionCache;
            _newBooksCache = newBooksCache;
            _popularBooksCache = popularBooksCache;
        }

        public List<Book> NewBooks { get; set; } = default!;
        public List<Book> PopularBooks { get; set; } = default!;
        public List<Book> SelectionBooks { get; set; } = default!;
        public int BooksCount { get; set; }

        public async Task OnGetAsync()
        {
            var booksOptions = _config.GetSection("Layout:IndexPage");
            BooksCount = booksOptions.GetValue<int>("ShelfRows");

            NewBooks = _newBooksCache.Books;
            PopularBooks = _popularBooksCache.Books;
            SelectionBooks = _selectionBooksCache.Books;
        }
    }
}