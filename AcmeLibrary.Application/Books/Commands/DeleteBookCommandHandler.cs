using AcmeLibrary.Application.Interfaces.Persistance;
using AcmeLibrary.Application.Interfaces.Services;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLibrary.Application.Books.Commands
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, ErrorOr<Deleted>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IIsbnService _isbnService;

        public DeleteBookCommandHandler(IBookRepository bookRepository, IIsbnService isbnService)
        {
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
            _isbnService = isbnService ?? throw new ArgumentNullException(nameof(isbnService));
        }

        public async Task<ErrorOr<Deleted>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var isbn = _isbnService.Dehyphenate(request.Isbn);
            _bookRepository.RemoveBook(isbn);

            return Result.Deleted;
        }
    }
}
