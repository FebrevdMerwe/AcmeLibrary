using AcmeLibrary.Domain.BookshelfAggregate.ValueObjects;
using AcmeLibrary.Domain.SectionAggregate;

namespace AcmeLibrary.Application.Interfaces.Persistance
{
    public interface ISectionRepository 
        : IBaseRepository<Section, SectionId>
    {
    }
}
