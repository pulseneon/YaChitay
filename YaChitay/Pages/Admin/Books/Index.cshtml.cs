using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YaChitay.Services.Service;

namespace YaChitay.Pages.Admin.Books
{
    public class IndexModel : PageModel
    {
        private readonly BooksService _service;

        public IndexModel(BooksService service)
        {
            _service = service;
        }

        public IList<Entities.Models.Book> Book { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Book = await _service.GetAllBooksAsync();
        }
    }
}
