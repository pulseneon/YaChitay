using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YaChitay.Entities.DTO;
using YaChitay.Services.Service;

namespace YaChitay.Pages.Admin.Books
{
    public class CreateModel : PageModel
    {
        private readonly BooksService _service;

        public CreateModel(BooksService service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BookDTO Model { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Model is null || Model.Photo is null)
            {
                return Page();
            }

            await _service.AddBookAsync(Model);

            return RedirectToPage("./Index");   
        }
    }
}
