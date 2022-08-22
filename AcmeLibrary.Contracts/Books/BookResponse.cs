using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLibrary.Contracts.Books
{
    public record BookResponse(
        string Name,
        string Description);
}
