using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLibrary.Contracts.Books
{
    public record ReturnBookRequest(
        string Isbn,
        Guid ClientId,
        int Quantity);
}
