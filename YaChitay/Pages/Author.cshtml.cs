using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YaChitay.Entities.Dto;
using YaChitay.Entities.Models;
using YaChitay.Services.Service;

namespace YaChitay.Pages
{
    public class AuthorModel : PageModel
    {
        private readonly AuthorsService _service;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public AuthorResponseDto Author { get; set; } 
        public double BooksAverageScore { get; set; }
        public string YandexMapsAPIKey { get; set; }

        public AuthorModel(IConfiguration configuration, AuthorsService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
            _config = configuration;
        } 

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id is null)
            {
                return RedirectToPage("./Authors");
            }

            var authorModel = await _service.GetAuthorAsync((int)id);

            if (authorModel == null || authorModel.IsDeleted)
            {
                return RedirectToPage("./Authors");
            }

            Author = _mapper.Map<AuthorResponseDto>(authorModel);
            BooksAverageScore = CalcBooksAverageScore(Author.Books);

            YandexMapsAPIKey = _config.GetSection("API").GetValue<string>("YandexMaps");

            return Page();
        }

        private double CalcBooksAverageScore(List<Book> books)
        {
            if (books == null || books.Count == 0)
            {
                return 0;
            }

            double score = 0;
            int count = 0;

            foreach (Book book in books)
            {
                if (!book.IsDeleted && book.Score != 0)
                {
                    score += book.Score;
                    count++;
                }
            }

            return count == 0 ? 0 : score / count;
        }
    }
}
