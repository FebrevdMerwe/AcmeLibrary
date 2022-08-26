using AcmeLibrary.Application.Books.Common;
using AcmeLibrary.Application.Clients.Commands;
using AcmeLibrary.Application.Clients.Common;
using AcmeLibrary.Application.Interfaces.Persistance;
using AcmeLibrary.Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcmeLibrary.Domain.Common.Errors;

namespace AcmeLibrary.Application.Clients.Commands
{
    public class AddClientCommandHandler : IRequestHandler<AddClientCommand, ErrorOr<ClientResult>>
    {
        private readonly IClientRepository _clientRepository;

        public AddClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
        }

        public async Task<ErrorOr<ClientResult>> Handle(AddClientCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var client = _clientRepository.GetClientByEmail(request.Email);
            if (client is not null)
            {
                return Errors.Client.DuplicateEmail;
            }

            client = new Client
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            _clientRepository.AddClient(client);

            return new ClientResult(client.Id, client.FirstName, client.LastName, client.Email);
        }
    }
}
