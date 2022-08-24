using AcmeLibrary.Application.Interfaces.Persistance;
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

        public DeleteBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
        }
        public async Task<ErrorOr<Deleted>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            _bookRepository.RemoveBook(request.Isbn);

            return Result.Deleted;
        }
    }
}
