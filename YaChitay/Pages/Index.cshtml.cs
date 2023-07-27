using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YaChitay.Data;

namespace YaChitay.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly YaChitay.Data.ApplicationContext _context;

        public IndexModel(ILogger<IndexModel> logger, ApplicationContext context)
        {
            _context = context;
            _logger = logger;
        }


        public IList<Entities.Models.BookModel> Book { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Book != null)
            {
                Book = await _context.Book.ToListAsync();
            }
        }
    }
}