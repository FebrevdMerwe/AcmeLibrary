using AcmeLibrary.Application.Libraries.Commands;
using AcmeLibrary.Application.Libraries.Queries;
using AcmeLibrary.Contracts.Libraries;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AcmeLibrary.Api.Controllers
{
    [Route("api/[controller]")]
    public class LibrariesController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public LibrariesController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetLibraries()
        {
            var query = new GetLibraryListQuery();

            var result = await _mediator.Send(query);

            return result.Match(
               result => Ok(_mapper.Map<IEnumerable<LibraryResponse>>(result)),
               errors => Problem(errors));
        }

        [HttpPost]
        public async Task<IActionResult> CreateLibrary([FromBody] CreateLibraryRequest request)
        {
            var command = _mapper.Map<CreateLibraryCommand>(request);

            var result = await _mediator.Send(command);

            return result.Match(
                result => Ok(_mapper.Map<LibraryResponse>(result)),
                errors => Problem(errors));
        }
    }
}
