using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;
using YaChitay.Entities.Cache;
using YaChitay.Entities.Models;
using YaChitay.Services.Service;

namespace YaChitay.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly BooksService _service;
        private readonly SelectionBooksCache _cache;

        public IndexModel(ILogger<IndexModel> logger, BooksService service, SelectionBooksCache cache)
        {
            _service = service;
            _logger = logger;
            _cache = cache;
        }

        public List<Book> NewBooks { get; set; } = default!;
        public List<Book> PopularBooks { get; set; } = default!;
        public List<Book> SelectionBooks { get; set; } = default!;

        public async Task OnGetAsync()
        {
            int colums = 5;

            //NewBooks = new List<Book>();

            //NewBooks = await _service.GetNewBooks(colums);
            //PopularBooks = await _service.GetPopularBooks(colums);
            SelectionBooks = _cache.BooksOfDay;
            //Console.WriteLine(SelectionBooks.Count);
            //if (_context.Book != null)
            //{
            //    Book = await _context.Book.ToListAsync();
            //}
        }
    }
}