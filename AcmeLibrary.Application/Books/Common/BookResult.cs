using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLibrary.Application.Books.Common
{
    public record BookResult(
        string ISBN,
        string Name,
        string Description);
}
