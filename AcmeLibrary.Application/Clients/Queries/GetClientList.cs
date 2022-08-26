using AcmeLibrary.Application.Clients.Common;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLibrary.Application.Clients.Queries
{
    public record GetClientListQuery() : IRequest<ErrorOr<IEnumerable<ClientResult>>>;
}
