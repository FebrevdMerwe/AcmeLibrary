using AcmeLibrary.Application.Books.Common;
using AcmeLibrary.Application.Interfaces.Persistance;
using AcmeLibrary.Domain.Entities;
using AcmeLibrary.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using AcmeLibrary.Application.Interfaces.Services;

namespace AcmeLibrary.Application.Books.Queries
{
    public class GetBookQueryHandler : IRequestHandler<GetBookQuery, ErrorOr<BookResult>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IIsbnService _isbnService;

        public GetBookQueryHandler(IBookRepository bookRepository, IIsbnService isbnService)
        {
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
            _isbnService = isbnService ?? throw new ArgumentNullException(nameof(isbnService));
        }

        public async Task<ErrorOr<BookResult>> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var isbn = _isbnService.Dehyphenate(request.Isbn);
            if(_bookRepository.GetBookByISBN(isbn) is not Book book)
                return Errors.Book.NotFound;

            return new BookResult(
                _isbnService.Hyphenate(book.Isbn), 
                book.Title, 
                book.Description, 
                book.Quantity); 
        }
    }
}
