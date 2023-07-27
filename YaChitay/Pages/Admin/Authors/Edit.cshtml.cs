using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YaChitay.Data;
using YaChitay.Entities.Models;

namespace YaChitay.Pages.Admin.Authors
{
    public class EditModel : PageModel
    {
        private readonly YaChitay.Data.ApplicationContext _context;

        public EditModel(YaChitay.Data.ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Author AuthorModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Author == null)
            {
                return NotFound();
            }

            var authormodel =  await _context.Author.FirstOrDefaultAsync(m => m.Id == id);
            if (authormodel == null)
            {
                return NotFound();
            }
            AuthorModel = authormodel;
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

            _context.Attach(AuthorModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorModelExists(AuthorModel.Id))
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

        private bool AuthorModelExists(int id)
        {
          return (_context.Author?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
