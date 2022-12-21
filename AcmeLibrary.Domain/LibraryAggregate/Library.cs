using AcmeLibrary.Domain.BookAggregate.ValueObjects;
using AcmeLibrary.Domain.BookshelfAggregate.ValueObjects;
using AcmeLibrary.Domain.ClientAggregate.ValueObjects;
using AcmeLibrary.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLibrary.Domain.LibraryAggregate
{
    public class Library : AggregateRoot<LibraryId>
    {
        private readonly List<BookId> _bookIds = new();
        private readonly List<SectionId> _sectionIds = new();
        public string Name { get; set; }

        public IReadOnlyCollection<BookId> BookIds => _bookIds.AsReadOnly();

        public IReadOnlyCollection<SectionId> SectionIds => _sectionIds.AsReadOnly();

        private Library(string name)
            :base(LibraryId.CreateUnique())
        {
            Name = name;
        }

        public static Library Create(string name)
        {
            return new Library(name);
        }
    }
}
