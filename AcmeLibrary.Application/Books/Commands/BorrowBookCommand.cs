using AcmeLibrary.Application.Books.Common;
using ErrorOr;
using MediatR;

namespace AcmeLibrary.Application.Books.Commands
{
    public record BorrowBookCommand(
        string Isbn,
        Guid ClientId,
        int Quantity) : IRequest<ErrorOr<Updated>>;
}