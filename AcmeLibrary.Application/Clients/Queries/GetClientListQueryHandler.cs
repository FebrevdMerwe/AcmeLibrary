using AcmeLibrary.Application.Interfaces.Persistance;
using AcmeLibrary.Domain.ClientAggregate;
using ErrorOr;
using MediatR;

namespace AcmeLibrary.Application.Clients.Queries
{
    public class GetClientListQueryHandler : IRequestHandler<GetClientListQuery, ErrorOr<IEnumerable<Client>>>
    {
        private readonly IClientRepository _ClientRepository;

        public GetClientListQueryHandler(IClientRepository ClientRepository)
        {
            _ClientRepository = ClientRepository;
        }

        public async Task<ErrorOr<IEnumerable<Client>>> Handle(GetClientListQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var Clients = _ClientRepository
                .GetClients()
                .ToList();

            return Clients;
        }
    }
}
