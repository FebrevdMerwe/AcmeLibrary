using AcmeLibrary.Application.Interfaces.Persistance;
using AcmeLibrary.Domain.BookshelfAggregate.ValueObjects;
using AcmeLibrary.Domain.SectionAggregate;

namespace AcmeLibrary.Infrastructure.Persistence
{
    public class SectionRepository : BaseRepository<Section, SectionId>, ISectionRepository
    {
    }
}
