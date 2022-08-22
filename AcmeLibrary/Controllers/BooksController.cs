using AcmeLibrary.Application.Books.Commands;
using AcmeLibrary.Application.Books.Queries;
using AcmeLibrary.Contracts.Books;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AcmeLibrary.Api.Controllers
{
    [Route("/api/[controller]")]
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
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] AddBookRequest request)
        {
            var command = _mapper.Map<AddBookCommand>(request);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(Guid id)
        {
            var query = new GetBookQuery(id);

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook()
        {
            return Ok();
        }
    }
}
