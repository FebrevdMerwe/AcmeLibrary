using AcmeLibrary.Application.Books.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLibrary.Application.Books.Queries
{
    public record GetBookQuery(
        Guid id) : IRequest<BookResult>;
}
