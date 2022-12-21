using AcmeLibrary.Domain.LibraryAggregate;
using ErrorOr;
using MediatR;

namespace AcmeLibrary.Application.Libraries.Queries
{
    public record GetLibraryListQuery() : IRequest<ErrorOr<IEnumerable<Library>>>;
}
