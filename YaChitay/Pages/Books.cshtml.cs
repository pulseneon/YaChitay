using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YaChitay.Entities.Dto;
using YaChitay.Services.Service;

namespace YaChitay.Pages
{
    public class BooksModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly BooksService _service;

        public BooksModel(IMapper mapper, BooksService service)
        {
            _mapper = mapper;
            _service = service;
        }

        public List<BookResponseDto> Books { get; set; }
        public int PageNum { get; set; }
        public int LastPageNum { get; set; }

        public async Task OnGetAsync(int? page)
        {
            if (page == null || page < 0)
            {
                page = 1;
            }

            var booksModel = await _service.GetBooksPageAsync((int)page);
            Books = _mapper.Map<List<BookResponseDto>>(booksModel);
            PageNum = (int)page;
            LastPageNum = await _service.GetBooksLastPageNumAsync();
        }
    }
}
