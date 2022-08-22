using AcmeLibrary.Application.Books.Commands;
using AcmeLibrary.Application.Books.Queries;
using AcmeLibrary.Contracts.Books;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AcmeLibrary.Api.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public BooksController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] AddBookRequest request)
        {
            var command = _mapper.Map<AddBookCommand>(request);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("{ISBN}")]
        public async Task<IActionResult> GetBook(string ISBN)
        {
            var isbn = ISBN
                .Replace(" ", "")
                .Replace("-", "");

            var query = new GetBookQuery(isbn);

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpDelete("{ISBN}")]
        public IActionResult DeleteBook(string ISBN)
        {
            //TODO: Implement DeleteBookCommand
            throw new NotImplementedException();
        }
    }
}
