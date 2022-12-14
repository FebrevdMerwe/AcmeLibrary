using AcmeLibrary.Application.Books.Common;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLibrary.Application.Books.Queries
{
    public record GetBookQuery(
        string Isbn) : IRequest<ErrorOr<BookResult>>;
}
