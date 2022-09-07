using AcmeLibrary.Application.Books.Common;
using AcmeLibrary.Application.Interfaces.Persistance;
using AcmeLibrary.Application.Interfaces.Services;
using AcmeLibrary.Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLibrary.Application.Books.Commands
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, ErrorOr<BookResult>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IIsbnService _isbnService;

        public AddBookCommandHandler(IBookRepository bookRepository, IIsbnService isbnService)
        {
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
            _isbnService = isbnService ?? throw new ArgumentNullException(nameof(isbnService));
        }

        public async Task<ErrorOr<BookResult>> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var isbn = _isbnService.Dehyphenate(request.Isbn);

            var book = _bookRepository.GetBookByISBN(isbn);
            if (book is not null)
            {
                book.Quantity += request.Quantity;
                _bookRepository.UpsertBook(book);
            }
            else
            {
                book = new Book
                {
                    Isbn = isbn,
                    Title = request.Title,
                    Description = request.Description,
                    Quantity = request.Quantity
                };

                _bookRepository.AddBook(book);
            }

            return new BookResult(
                _isbnService.Hyphenate(book.Isbn),
                book.Title,
                book.Description,
                book.Quantity);
        }
    }
}
