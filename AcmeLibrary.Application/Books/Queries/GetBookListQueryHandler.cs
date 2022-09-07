using AcmeLibrary.Application.Books.Common;
using AcmeLibrary.Application.Interfaces.Persistance;
using AcmeLibrary.Domain.Entities;
using AcmeLibrary.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using AcmeLibrary.Application.Interfaces.Services;

namespace AcmeLibrary.Application.Books.Queries
{
    public class GetBookListQueryHandler : IRequestHandler<GetBookListQuery, ErrorOr<IEnumerable<BookResult>>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IIsbnService _isbnService;

        public GetBookListQueryHandler(IBookRepository bookRepository, IIsbnService isbnService)
        {
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
            _isbnService = isbnService ?? throw new ArgumentNullException(nameof(isbnService));
        }

        public async Task<ErrorOr<IEnumerable<BookResult>>> Handle(GetBookListQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var books = _bookRepository
                .GetBooks()
                .Select(book => new BookResult(_isbnService.Hyphenate(book.Isbn), book.Title, book.Description, book.Quantity))
                .ToList();

            return books;
        }
    }
}
