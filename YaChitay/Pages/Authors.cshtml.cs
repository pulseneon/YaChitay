using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YaChitay.Entities.Models;
using YaChitay.Services.Service;

namespace YaChitay.Pages
{
    public class AuthorsModel : PageModel
    {
        private readonly AuthorsService _service;

        public List<Author> Author { get; set; }

        public AuthorsModel(AuthorsService service)
        {
            _service = service;
        }

        public void OnGet()
        {
        }
    }
}
