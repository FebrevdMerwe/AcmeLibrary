using AcmeLibrary.Domain.ClientAggregate;
using ErrorOr;
using MediatR;

namespace AcmeLibrary.Application.Clients.Commands.CreateClient
{
    public record CreateClientCommand(
        string FirstName,
        string LastName,
        string Email) : IRequest<ErrorOr<Client>>;
}