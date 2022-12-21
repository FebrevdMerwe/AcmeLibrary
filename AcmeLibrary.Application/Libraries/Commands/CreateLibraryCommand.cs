using AcmeLibrary.Domain.LibraryAggregate;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLibrary.Application.Libraries.Commands
{
    public record CreateLibraryCommand(
        string Name) : IRequest<ErrorOr<Library>>;
}
