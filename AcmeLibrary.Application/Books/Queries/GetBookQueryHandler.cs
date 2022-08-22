using AcmeLibrary.Application.Books.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLibrary.Application.Books.Queries
{
    public class GetBookQueryHandler : IRequestHandler<GetBookQuery, BookResult>
    {
        public Task<BookResult> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
