using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLibrary.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Book
        {
            public static Error NotFound { get; set; } = Error.NotFound(
               code: "Book.NotFound",
               description: "Book with given ISBN number not found");
        }
    }
}
