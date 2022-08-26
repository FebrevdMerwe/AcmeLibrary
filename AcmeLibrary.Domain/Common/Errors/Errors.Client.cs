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
        public static class Client
        {
            public static Error NotFound { get; set; } = Error.NotFound(
              code: "Client.NotFound",
              description: "Client with given Id not found");

            public static Error DuplicateEmail { get; set; } = Error.Conflict(
               code: "Client.DuplicateEmail",
               description: "Email is already in use.");
        }
    }
}
