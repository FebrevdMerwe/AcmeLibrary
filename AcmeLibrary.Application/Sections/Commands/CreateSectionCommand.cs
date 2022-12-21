
using AcmeLibrary.Domain.SectionAggregate;
using ErrorOr;
using MediatR;

namespace AcmeLibrary.Application.Sections.Commands
{
    public record CreateSectionCommand(
        string Name,
        Guid LibraryId) : IRequest<ErrorOr<Section>>;
}
