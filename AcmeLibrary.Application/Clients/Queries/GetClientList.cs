using AcmeLibrary.Domain.ClientAggregate;
using ErrorOr;
using MediatR;

namespace AcmeLibrary.Application.Clients.Queries
{
    public record GetClientListQuery() : IRequest<ErrorOr<IEnumerable<Client>>>;
}
