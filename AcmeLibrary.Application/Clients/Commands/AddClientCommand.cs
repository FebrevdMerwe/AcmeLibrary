using AcmeLibrary.Application.Clients.Common;
using ErrorOr;
using MediatR;

namespace AcmeLibrary.Application.Clients.Commands
{
    public record AddClientCommand(
        string FirstName,
        string LastName,
        string Email) : IRequest<ErrorOr<ClientResult>>;
}