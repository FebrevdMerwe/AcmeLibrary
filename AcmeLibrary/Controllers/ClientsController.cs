using AcmeLibrary.Application.Clients.Commands.CreateClient;
using AcmeLibrary.Application.Clients.Commands.DeleteClient;
using AcmeLibrary.Application.Clients.Queries;
using AcmeLibrary.Contracts.Clients;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AcmeLibrary.Api.Controllers
{
    [Route("/api/[controller]")]
    public class ClientsController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public ClientsController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            var query = new GetClientListQuery();

            var result = await _mediator.Send(query);

            return result.Match(
               result => Ok(_mapper.Map<IEnumerable<ClientResponse>>(result)),
               errors => Problem(errors));
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] CreateClientRequest request)
        {
            var command = _mapper.Map<CreateClientCommand>(request);

            var createClientResult = await _mediator.Send(command);

            return createClientResult.Match(
                result => Ok(_mapper.Map<ClientResponse>(result)),
                errors => Problem(errors));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient(Guid id)
        {
            var query = new GetClientQuery(id);

            var result = await _mediator.Send(query);

            return result.Match(
               result => Ok(_mapper.Map<ClientResponse>(result)),
               errors => Problem(errors));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(Guid id)
        {
            var command = new DeleteClientCommand(id);

            var result = await _mediator.Send(command);

            return result.Match(
               result => Ok(_mapper.Map<Deleted>(result)),
               errors => Problem(errors));
        }
    }
}
