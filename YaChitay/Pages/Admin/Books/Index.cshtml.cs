﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YaChitay.Data;

namespace YaChitay.Pages.Admin.Books
{
    public class IndexModel : PageModel
    {
        private readonly YaChitay.Data.ApplicationContext _context;

        public IndexModel(YaChitay.Data.ApplicationContext context)
        {
            _context = context;
        }

        public IList<Entities.Models.BookModel> Book { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Book != null)
            {
                Book = await _context.Book.ToListAsync();
            }
        }
    }
}
