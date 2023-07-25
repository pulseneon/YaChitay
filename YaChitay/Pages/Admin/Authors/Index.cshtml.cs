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
    public class IndexModel : PageModel
    {
        private readonly ApplicationContext _context;

        public IndexModel(ApplicationContext context)
        {
            _context = context;
        }

        public IList<AuthorModel> AuthorModel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Author != null)
            {
                AuthorModel = await _context.Author.ToListAsync();
            }
        }
    }
}
