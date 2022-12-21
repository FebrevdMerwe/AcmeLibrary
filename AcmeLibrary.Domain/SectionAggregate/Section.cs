using AcmeLibrary.Domain.BookAggregate.ValueObjects;
using AcmeLibrary.Domain.BookshelfAggregate.ValueObjects;
using AcmeLibrary.Domain.ClientAggregate.ValueObjects;
using AcmeLibrary.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLibrary.Domain.SectionAggregate
{
    public class Section : AggregateRoot<SectionId>
    {
        private readonly List<BookId> _bookIds = new();
        public string Name { get; }
        public LibraryId LibraryId { get; }

        public IReadOnlyCollection<BookId> BookIds => _bookIds.AsReadOnly();

        private Section(SectionId sectionId,  string name, LibraryId libraryId)
            :base(sectionId)
        {
            Name = name;
            LibraryId = libraryId;
        }

        public static Section Create(string name, LibraryId libraryId)
        {
            return new Section(
                SectionId.CreateUnique(),
                name, 
                libraryId);
        }
    }
}
