using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using YaChitay.Data;
using YaChitay.Entities.DTO;
using YaChitay.Entities.Models;
using YaChitay.Services.Service;

namespace YaChitay.Pages.Admin.Authors
{
    public class CreateModel : PageModel
    {
        private readonly AuthorsService _service;

        public CreateModel(AuthorsService service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public AuthorRequestDto Author { get; set; } = default!;
        
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || Author == null)
            {
                return Page();
            }

            await _service.AddAuthorAsync(Author);

            return RedirectToPage("./Index");
        }
    }
}
