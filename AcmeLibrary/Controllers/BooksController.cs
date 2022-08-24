using AcmeLibrary.Application.Books.Commands;
using AcmeLibrary.Application.Books.Common;
using AcmeLibrary.Application.Books.Queries;
using AcmeLibrary.Contracts.Books;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AcmeLibrary.Api.Controllers
{
    [Route("/api/[controller]")]
    public class BooksController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public BooksController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var query = new GetBookListQuery();

            var result = await _mediator.Send(query);

            return result.Match(
               result => Ok(_mapper.Map<IEnumerable<BookResult>>(result)),
               errors => Problem(errors));
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] AddBookRequest request)
        {
            var command = _mapper.Map<AddBookCommand>(request);

            var result = await _mediator.Send(command);

            return result.Match(
                result => Ok(_mapper.Map<BookResponse>(result)),
                errors => Problem(errors));
        }

        [HttpGet("{ISBN}")]
        public async Task<IActionResult> GetBook(string ISBN)
        {
            var query = new GetBookQuery(ISBN);

            var result = await _mediator.Send(query);

            return result.Match(
               result => Ok(_mapper.Map<BookResponse>(result)),
               errors => Problem(errors));
        }

        [HttpDelete("{ISBN}")]
        public async Task<IActionResult> DeleteBook(string ISBN)
        {
            var query = new DeleteBookCommand(ISBN);

            var result = await _mediator.Send(query);

            return result.Match(
               result => Ok(_mapper.Map<Deleted>(result)),
               errors => Problem(errors));
        }
    }
}
