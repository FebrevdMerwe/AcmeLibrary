using AcmeLibrary.Application.Books.Common;
using ErrorOr;
using MediatR;

namespace AcmeLibrary.Application.Books.Queries
{
    public record GetBookListQuery() : IRequest<ErrorOr<IEnumerable<BookResult>>>;
}