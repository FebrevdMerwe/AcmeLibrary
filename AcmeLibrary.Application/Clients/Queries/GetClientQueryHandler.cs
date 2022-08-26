using AcmeLibrary.Application.Clients.Common;
using AcmeLibrary.Application.Interfaces.Persistance;
using AcmeLibrary.Domain.Entities;
using AcmeLibrary.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace AcmeLibrary.Application.Clients.Queries
{
    public class GetClientQueryHandler : IRequestHandler<GetClientQuery, ErrorOr<ClientResult>>
    {
        private readonly IClientRepository _ClientRepository;

        public GetClientQueryHandler(IClientRepository ClientRepository)
        {
            _ClientRepository = ClientRepository;
        }

        public async Task<ErrorOr<ClientResult>> Handle(GetClientQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if(_ClientRepository.GetClientById(request.Id) is not Client Client)
                return Errors.Client.NotFound;

            return new ClientResult(Client.Id, Client.FirstName, Client.LastName, Client.Email); 
        }
    }
}
