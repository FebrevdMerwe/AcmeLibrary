using AcmeLibrary.Application.Books.Common;
using AcmeLibrary.Application.Interfaces.Persistance;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcmeLibrary.Domain.Common.Errors;
using AcmeLibrary.Application.Interfaces.Services;

namespace AcmeLibrary.Application.Books.Commands
{
    public class BorrowBookCommandHandler : IRequestHandler<BorrowBookCommand, ErrorOr<Updated>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBorrowedBooksRepository _borrowedBooksRepository;
        private readonly IIsbnService _isbnService;

        public BorrowBookCommandHandler(IBookRepository bookRepository, IBorrowedBooksRepository borrowedBooksRepository, IIsbnService isbnService)
        {
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
            _borrowedBooksRepository = borrowedBooksRepository ?? throw new ArgumentNullException(nameof(borrowedBooksRepository));
            _isbnService = isbnService ?? throw new ArgumentNullException(nameof(isbnService));
        }

        public async Task<ErrorOr<Updated>> Handle(BorrowBookCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var isbn = _isbnService.Dehyphenate(request.Isbn);

            var book = _bookRepository.GetBookByISBN(isbn);

            if (book is null)
                return Errors.Book.NotFound;

            if (book.Quantity < request.Quantity)
                return Errors.Book.OutOfStock;

            _borrowedBooksRepository.BorrowBook(isbn, request.ClientId, request.Quantity);

            book.Quantity -= request.Quantity;
             _bookRepository.UpsertBook(book);


            return Result.Updated;
        }
    }
}
