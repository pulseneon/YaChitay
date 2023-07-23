using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YaChitay.Data;
using YaChitay.Models;
using YaChitay.Models.Book;

namespace YaChitay.Pages.Admin.Genres
{
    public class EditModel : PageModel
    {
        private readonly YaChitay.Data.ApplicationContext _context;

        public EditModel(YaChitay.Data.ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public GenreModel Genre { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Genre == null)
            {
                return NotFound();
            }

            var genre =  await _context.Genre.FirstOrDefaultAsync(m => m.Id == id);
            if (genre == null)
            {
                return NotFound();
            }
            Genre = genre;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Genre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenreExists(Genre.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GenreExists(int id)
        {
          return (_context.Genre?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
