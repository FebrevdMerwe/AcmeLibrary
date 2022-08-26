using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLibrary.Application.Clients.Common
{
    public record ClientResult(
        Guid Id,
        string FirstName,
        string LastName,
        string Email);
}
