using AcmeLibrary.Application.Clients.Common;
using AcmeLibrary.Application.Interfaces.Persistance;
using AcmeLibrary.Domain.Entities;
using AcmeLibrary.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace AcmeLibrary.Application.Clients.Queries
{
    public class GetClientListQueryHandler : IRequestHandler<GetClientListQuery, ErrorOr<IEnumerable<ClientResult>>>
    {
        private readonly IClientRepository _ClientRepository;

        public GetClientListQueryHandler(IClientRepository ClientRepository)
        {
            _ClientRepository = ClientRepository;
        }

        public async Task<ErrorOr<IEnumerable<ClientResult>>> Handle(GetClientListQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var Clients = _ClientRepository
                .GetClients()
                .Select(Client => new ClientResult(Client.Id, Client.FirstName, Client.LastName, Client.Email))
                .ToList();

            return Clients;
        }
    }
}
