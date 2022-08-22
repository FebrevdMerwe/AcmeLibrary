using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLibrary.Contracts.Books
{
    public record AddBookRequest(
        string ISBN,
        string Name,
        string Description,
        int Quantity);
}
