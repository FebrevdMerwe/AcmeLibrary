using AcmeLibrary.Domain.LibraryAggregate;

namespace AcmeLibrary.Application.Interfaces.Persistance
{
    public interface ILibraryRepository
    {
        void Add(Library library);

        Library? Get(Guid id);

        IEnumerable<Library> GetAll();

        void Remove(Guid id);

        void Upsert(Library library);
    }
}
