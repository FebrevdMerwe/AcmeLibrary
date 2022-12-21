using AcmeLibrary.Application.Interfaces.Persistance;
using AcmeLibrary.Domain.ClientAggregate.ValueObjects;
using AcmeLibrary.Domain.SectionAggregate;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLibrary.Application.Sections.Commands
{
    public class CreateSectionCommandHandler : IRequestHandler<CreateSectionCommand, ErrorOr<Section>>
    {
        private readonly ISectionRepository _sectionRepository;

        public CreateSectionCommandHandler(ISectionRepository sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }

        public async Task<ErrorOr<Section>> Handle(CreateSectionCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var section = Section.Create(request.Name, LibraryId.Create(request.LibraryId));

            _sectionRepository.Add(section);

            return section;
        }
    }
}
