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
    public class IndexModel : PageModel
    {
        private readonly YaChitay.Data.ApplicationContext _context;

        public IndexModel(YaChitay.Data.ApplicationContext context)
        {
            _context = context;
        }

        public IList<GenreModel> Genre { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Genre != null)
            {
                Genre = await _context.Genre.ToListAsync();
            }
        }
    }
}
