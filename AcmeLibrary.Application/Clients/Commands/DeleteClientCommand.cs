using AcmeLibrary.Application.Clients.Common;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLibrary.Application.Clients.Commands
{
    public record DeleteClientCommand(
        Guid Id) : IRequest<ErrorOr<Deleted>>;
}
