using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLibrary.Contracts.Libraries
{
    public record LibraryResponse(
        Guid Id,
        string Name);
}
