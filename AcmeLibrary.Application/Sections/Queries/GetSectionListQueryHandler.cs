using AcmeLibrary.Application.Interfaces.Persistance;
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
    public class GetSectionListQueryHandler : IRequestHandler<GetSectionListQuery, ErrorOr<IEnumerable<Section>>>
    {
        private readonly ISectionRepository _sectionRepository;

        public GetSectionListQueryHandler(ISectionRepository sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }

        public async Task<ErrorOr<IEnumerable<Section>>> Handle(GetSectionListQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var sections = _sectionRepository
                .GetAll()
                .ToList();

            return sections;
        }
    }
}
