using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YaChitay.Data;
using YaChitay.Entities.Models;

namespace YaChitay.Pages.Admin.Authors
{
    public class DetailsModel : PageModel
    {
        private readonly YaChitay.Data.ApplicationContext _context;

        public DetailsModel(YaChitay.Data.ApplicationContext context)
        {
            _context = context;
        }

      public AuthorModel AuthorModel { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Author == null)
            {
                return NotFound();
            }

            var authormodel = await _context.Author.FirstOrDefaultAsync(m => m.Id == id);
            if (authormodel == null)
            {
                return NotFound();
            }
            else 
            {
                AuthorModel = authormodel;
            }
            return Page();
        }
    }
}
