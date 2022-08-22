using AcmeLibrary.Application.Books.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLibrary.Application.Books.Commands
{
    public record AddBookCommand(
        string Name,
        string Description
        ) : IRequest<BookResult>;
}
