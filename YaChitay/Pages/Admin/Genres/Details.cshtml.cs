using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YaChitay.Data;
using YaChitay.Models;
using YaChitay.Models.Book;

namespace YaChitay.Pages.Admin.Genres
{
    public class DetailsModel : PageModel
    {
        private readonly YaChitay.Data.ApplicationContext _context;

        public DetailsModel(YaChitay.Data.ApplicationContext context)
        {
            _context = context;
        }

      public GenreModel Genre { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Genre == null)
            {
                return NotFound();
            }

            var genre = await _context.Genre.FirstOrDefaultAsync(m => m.Id == id);
            if (genre == null)
            {
                return NotFound();
            }
            else 
            {
                Genre = genre;
            }
            return Page();
        }
    }
}
