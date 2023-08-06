using Microsoft.AspNetCore.Mvc;
using YaChitay.Services.Service;
using AutoMapper;
using YaChitay.Entities.Response;
using YaChitay.Entities.DTO;
using YaChitay.Entities.Dto;

namespace YaChitay.Api.v1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/book")]
    public class BookController : ControllerBase
    {
        private readonly BooksService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<BookController> _logger;

        public BookController(ILogger<BookController> logger, BooksService service, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        // GET: api/Book/5
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

        // GET: api/Book/Photo/5
        [HttpGet("photo/{id}")]
        public async Task<IActionResult> GetBookPhoto(int id)
        {
            _logger.LogInformation($"The api received a request by 'photo/id' with id = {id}");
            var book = await _service.GetBookAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            var photo = new PhotoDto(book.Image.Id, book.Image.ImageData);
            _logger.LogInformation($"API response returned {photo}");

            return Ok(photo);
        }

        // POST: api/Book/{book}
        [HttpPost()]
        public async Task<IActionResult> AddBook([FromBody] TestDTO book) //
        {
            Console.WriteLine("add book");
            
            if (!ModelState.IsValid || book == null)
            {
                return BadRequest();
            }

            //var result = await _service.AddBookAsync(book);

            //return (result) ? Ok(result) : NotFound();
            return Ok();
        }
    }
}
