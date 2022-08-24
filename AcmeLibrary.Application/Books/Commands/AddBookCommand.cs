using AcmeLibrary.Application.Books.Common;
using ErrorOr;
using MediatR;

namespace AcmeLibrary.Application.Books.Commands
{
    public record AddBookCommand(
        string Isbn,
        string Title,
        string Description,
        int Quantity) : IRequest<ErrorOr<BookResult>>;
}