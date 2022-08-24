using AcmeLibrary.Application.Books.Common;
using AcmeLibrary.Application.Interfaces.Persistance;
using AcmeLibrary.Domain.Entities;
using AcmeLibrary.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace AcmeLibrary.Application.Books.Queries
{
    public class GetBookListQueryHandler : IRequestHandler<GetBookListQuery, ErrorOr<IEnumerable<BookResult>>>
    {
        private readonly IBookRepository _bookRepository;

        public GetBookListQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ErrorOr<IEnumerable<BookResult>>> Handle(GetBookListQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var books = _bookRepository
                .GetBooks()
                .Select(book => new BookResult(book.Isbn, book.Title, book.Description, book.Quantity))
                .ToList();

            return books;
        }
    }
}
