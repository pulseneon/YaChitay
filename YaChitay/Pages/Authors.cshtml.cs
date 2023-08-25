using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YaChitay.Entities.Dto;
using YaChitay.Entities.Models;
using YaChitay.Services.Service;

namespace YaChitay.Pages
{
    public class AuthorsModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly AuthorsService _service;

        public List<AuthorResponseDto> Authors { get; set; }
        public int PageNum { get; set; }
        public int LastPageNum { get; set; }

        public AuthorsModel(IMapper mapper, AuthorsService service)
        {
            _mapper = mapper;
            _service = service;
        }

        public async Task OnGetAsync(int? page)
        {
            if (page == null || page < 0)
            {
                page = 1;
            }

            var authorsModel = await _service.GetAuthorsPageAsync((int)page);
            Authors = _mapper.Map<List<AuthorResponseDto>>(authorsModel);
            PageNum = (int)page;
            LastPageNum = await _service.GetAuthorsLastPageNumAsync();
        }
    }
}
