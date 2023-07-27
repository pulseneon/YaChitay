using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace YaChitay.Pages
{
    public class AuthorModel : PageModel
    {
        [BindProperty]
        public Entities.Models.Author Author { get; set; }
        
        public IActionResult OnGet(int? id)
        {
            if (id is null)
            {
                return RedirectToPage("./Authors");
            }

            Author = new Entities.Models.Author();
            Author.Name = "Косятин";
            Author.Surname = "Руднев";
            Author.Patronymic = id.ToString();

            return Page();
        }
    }
}
