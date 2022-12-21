using AcmeLibrary.Domain.SectionAggregate;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLibrary.Application.Sections.Queries
{
    public record GetSectionListQuery() : IRequest<ErrorOr<IEnumerable<Section>>>;
}
