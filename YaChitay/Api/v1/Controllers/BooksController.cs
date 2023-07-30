using Microsoft.AspNetCore.Mvc;
using YaChitay.Services.Service;
using AutoMapper;
using YaChitay.Entities.Response;
using YaChitay.Entities.DTO;

namespace YaChitay.Api.v1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/books")]
    public class BooksController : ControllerBase
    {
        private readonly BooksService _service;
        private readonly IMapper _mapper;

        public BooksController(BooksService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await _service.GetBookAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<BookResponse>(book);

            return Ok(response);
        }

        // POST: api/Books/{book}
        [HttpPost()]
        public async Task<IActionResult> AddBook([FromBody] BookDTO book)
        {
            Console.WriteLine("add book");
            
            if (!ModelState.IsValid || book == null)
            {
                return BadRequest();
            }

            var result = await _service.AddBookAsync(book);

            return (result) ? Ok(result) : NotFound();
            //return Ok();
        }

        // POST: api/Books/
        [HttpPost("test")]
        public async Task<IActionResult> AddBook()
        {
            return Ok();
        }
    }
}
