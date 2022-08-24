using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLibrary.Contracts.Books
{
    public record BookResponse(
        string Isbn,
        string Title,
        string Description,
        int Quantity);
}
