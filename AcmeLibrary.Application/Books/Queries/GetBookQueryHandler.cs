using AcmeLibrary.Application.Books.Common;
using AcmeLibrary.Application.Interfaces.Persistance;
using AcmeLibrary.Domain.Entities;
using MediatR;

namespace AcmeLibrary.Application.Books.Queries
{
    public class GetBookQueryHandler : IRequestHandler<GetBookQuery, BookResult>
    {
        private readonly IBookRepository _bookRepository;

        public GetBookQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<BookResult> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if(_bookRepository.GetBookByISBN(request.ISBN) is not Book book)
            {
                //TODO: Look into ErrorOr library
                throw new KeyNotFoundException("Book with given ISBN number not found");
            }

            return new BookResult(book.Isbn, book.Title, book.Description, book.Quantity); 
        }
    }
}
