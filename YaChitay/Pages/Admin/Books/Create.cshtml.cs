using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YaChitay.Data;
using YaChitay.Models;
using YaChitay.Models.Book;
using YaChitay.Services;
using static Azure.Core.HttpHeader;

namespace YaChitay.Pages.Admin.Books
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public CreateModel(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BookDTO Model { get; set; } = default!;
        [BindProperty]
        public string? Error { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var imageData = ImageUtility.ImageToString(Model.Photo);

            if (!ModelState.IsValid || Model is null || imageData is null)
            {
                return Page();
            }

            Error = null;

            // upload model
            var book = _mapper.Map<Models.BookModel>(Model);
            book.PhotoData = imageData;

            var genres = Model.Genres.Split(';');
            var findedGenres = _context.Genre.Where(g => genres.Contains(g.Name)).ToList();
            book.Genres.AddRange(findedGenres);

            var findedAuthor = await _context.Author.FirstOrDefaultAsync(x => string.Format("{0} {1} {2}", x.Name, x.Patronymic, x.Surname).Equals(Model.Author));

            if (findedAuthor == null)
            {
                Error = "Такого автора нет в базе данных";
                return Page();
            }

            _context.Book.Add(book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");   
        }
    }
}
