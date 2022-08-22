using AcmeLibrary.Application.Books.Common;
using AcmeLibrary.Application.Interfaces.Persistance;
using AcmeLibrary.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLibrary.Application.Books.Commands
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, BookResult>
    {
        private readonly IBookRepository _bookRepository;

        public AddBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
        }

        public async Task<BookResult> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var isbn = request.Isbn
                .Replace(" ", "")
                .Replace("-", "");
    
            var book = _bookRepository.GetBookByISBN(isbn);
            if ( book is not null)
            {
                book.Quantity += request.Quantity;
                _bookRepository.UpsertBook(book);
            }

            var newBook = new Book
            {
                Isbn = isbn,
                Title = request.Title,
                Description = request.Description,
                Quantity = request.Quantity
            };

            _bookRepository.AddBook(newBook);

            return new BookResult(newBook.Isbn, newBook.Title, newBook.Description, newBook.Quantity);
        }
    }
}
