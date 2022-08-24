using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLibrary.Application.Books.Common
{
    public record BookResult(
        string Isbn,
        string Title,
        string Description,
        int Quantity);
}
