using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YaChitay.Data;
using YaChitay.Services.Service;

namespace YaChitay.Pages
{
    public class BookModel : PageModel
    {
        private readonly BooksService _service;

        [BindProperty]
        public Entities.Models.Book Book { get; set; }

        public BookModel(BooksService service)
        {
            _service = service;
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id is null)
            {
                return RedirectToPage("./Index");
            }

            //Book = await _context.Book.FindAsync(id);
            //Book = await _context.Book.Include(x => x.Genres)
            //    .Include(x => x.Author)
            //    .FirstOrDefaultAsync(x => x.Id == id);

            if (Book is null || Book.IsDeleted)
            {
                return RedirectToPage("./Error");
            }

            return Page();
        }
    }
}
