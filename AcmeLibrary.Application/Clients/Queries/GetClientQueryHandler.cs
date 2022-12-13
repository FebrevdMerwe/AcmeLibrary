using AcmeLibrary.Application.Interfaces.Persistance;
using AcmeLibrary.Domain.ClientAggregate;
using AcmeLibrary.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace AcmeLibrary.Application.Clients.Queries
{
    public class GetClientQueryHandler : IRequestHandler<GetClientQuery, ErrorOr<Client>>
    {
        private readonly IClientRepository _ClientRepository;

        public GetClientQueryHandler(IClientRepository ClientRepository)
        {
            _ClientRepository = ClientRepository;
        }

        public async Task<ErrorOr<Client>> Handle(GetClientQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if(_ClientRepository.GetClientById(request.Id) is not Client client)
                return Errors.Client.NotFound;

            return client;
        }
    }
}

