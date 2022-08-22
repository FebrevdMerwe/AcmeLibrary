using AcmeLibrary.Application.Books.Common;
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
        public Task<BookResult> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
