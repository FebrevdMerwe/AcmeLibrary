using AcmeLibrary.Application.Books.Common;
using MediatR;

namespace AcmeLibrary.Application.Books.Commands
{
    public record AddBookCommand(
        string Isbn,
        string Title,
        string Description,
        int Quantity) : IRequest<BookResult>;
}