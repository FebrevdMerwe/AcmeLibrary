using ErrorOr;
using MediatR;

namespace AcmeLibrary.Application.Clients.Commands.DeleteClient
{
    public record DeleteClientCommand(
        Guid Id) : IRequest<ErrorOr<Deleted>>;
}
