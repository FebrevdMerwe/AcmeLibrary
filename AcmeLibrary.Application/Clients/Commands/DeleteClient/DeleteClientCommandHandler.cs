using AcmeLibrary.Application.Interfaces.Persistance;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLibrary.Application.Clients.Commands.DeleteClient
{
    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, ErrorOr<Deleted>>
    {
        private readonly IClientRepository _clientRepository;

        public DeleteClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
        }
        public async Task<ErrorOr<Deleted>> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            _clientRepository.RemoveClientById(request.Id);

            return Result.Deleted;
        }
    }
}
