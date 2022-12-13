using AcmeLibrary.Domain.ClientAggregate;
using ErrorOr;
using MediatR;

namespace AcmeLibrary.Application.Clients.Queries
{
    public record GetClientQuery(
        Guid Id) : IRequest<ErrorOr<Client>>;
}
