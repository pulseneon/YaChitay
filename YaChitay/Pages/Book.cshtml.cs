using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YaChitay.Data;

namespace YaChitay.Pages
{
    public class BookModel : PageModel
    {
        private readonly ApplicationContext _context;

        [BindProperty]
        public Entities.Models.BookModel Book { get; set; }

        public BookModel(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id is null)
            {
                return RedirectToPage("./Index");
            }

            //Book = await _context.Book.FindAsync(id);
            Book = await _context.Book.Include(x => x.Genres).FirstOrDefaultAsync(x => x.Id == id);

            if (Book is null || Book.IsDeleted)
            {
                return RedirectToPage("./Error");
            }

            return Page();
        }
    }
}
