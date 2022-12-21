using AcmeLibrary.Application.Sections.Commands;
using AcmeLibrary.Application.Sections.Queries;
using AcmeLibrary.Contracts.Sections;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AcmeLibrary.Api.Controllers
{
    [Route("api/[controller]")]
    public class SectionsController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public SectionsController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetSectionListQuery();

            var result = await _mediator.Send(query);

            return result.Match(
               result => Ok(_mapper.Map<IEnumerable<SectionResponse>>(result)),
               errors => Problem(errors));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSectionRequest request)
        {
            var command = _mapper.Map<CreateSectionCommand>(request);

            var result = await _mediator.Send(command);

            return result.Match(
                result => Ok(_mapper.Map<SectionResponse>(result)),
                errors => Problem(errors));
        }
    }
}
