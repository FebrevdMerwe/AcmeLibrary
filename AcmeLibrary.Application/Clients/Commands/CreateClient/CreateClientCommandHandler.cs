using AcmeLibrary.Application.Interfaces.Persistance;
using ErrorOr;
using MediatR;
using AcmeLibrary.Domain.Common.Errors;
using AcmeLibrary.Domain.ClientAggregate;

namespace AcmeLibrary.Application.Clients.Commands.CreateClient
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, ErrorOr<Client>>
    {
        private readonly IClientRepository _clientRepository;

        public CreateClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
        }

        public async Task<ErrorOr<Client>> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var client = _clientRepository.GetClientByEmail(request.Email);
            if (client is not null)
            {
                return Errors.Client.DuplicateEmail;
            }

            client = Client.Create
            (
                firstName: request.FirstName,
                lastName: request.LastName,
                email: request.Email
            );

            _clientRepository.AddClient(client);

            return client;
        }
    }
}
