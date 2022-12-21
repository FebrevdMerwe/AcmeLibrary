using AcmeLibrary.Application.Interfaces.Persistance;
using AcmeLibrary.Domain.LibraryAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLibrary.Infrastructure.Persistence
{
    public class LibraryRepository : ILibraryRepository
    {
        private static readonly Dictionary<Guid, Library> _libraries = new();

        public void Add(Library library)
        {
            _libraries.Add(library.Id.Value, library);
        }

        public Library? Get(Guid id)
        {
            return _libraries[id];
        }

        public IEnumerable<Library> GetAll()
        {
            return _libraries.Values;
        }

        public void Remove(Guid id)
        {
            _libraries.Remove(id);
        }

        public void Upsert(Library library)
        {
            throw new NotImplementedException();
        }
    }
}
