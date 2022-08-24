using AcmeLibrary.Application.Books.Common;
using AcmeLibrary.Application.Interfaces.Persistance;
using AcmeLibrary.Domain.Entities;
using AcmeLibrary.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace AcmeLibrary.Application.Books.Queries
{
    public class GetBookQueryHandler : IRequestHandler<GetBookQuery, ErrorOr<BookResult>>
    {
        private readonly IBookRepository _bookRepository;

        public GetBookQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ErrorOr<BookResult>> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if(_bookRepository.GetBookByISBN(request.ISBN) is not Book book)
                return Errors.Book.NotFound;

            return new BookResult(book.Isbn, book.Title, book.Description, book.Quantity); 
        }
    }
}
