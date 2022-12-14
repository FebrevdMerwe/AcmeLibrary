using AcmeLibrary.Domain.BookAggregate.Entities;
using AcmeLibrary.Domain.BookAggregate.ValueObjects;
using AcmeLibrary.Domain.BookshelfAggregate.ValueObjects;
using AcmeLibrary.Domain.ClientAggregate.ValueObjects;
using AcmeLibrary.Domain.Common.Models;

namespace AcmeLibrary.Domain.BookAggregate
{
    public sealed class Book : AggregateRoot<BookId>
    {
        private readonly List<BookReservation> _bookReservations = new();
        private readonly List<BookReviewId> _bookReviewIds = new();

        public string Title { get; }
        public string Description { get; }
        public SectionId BookshelfId { get; }
        public ClientId ClientId { get; }
        public LibraryId LibraryId { get; }

        public IReadOnlyList<BookReviewId> BookReviewIds => _bookReviewIds.AsReadOnly();
        public IReadOnlyList<BookReservation> BookReservations => _bookReservations.AsReadOnly();

        private Book(
            BookId bookIsbn,
            string title,
            string description,
            SectionId bookshelfId,
            ClientId clientId,
            LibraryId libraryId)
            :base(bookIsbn)
        {
            Title = title;
            Description = description;
            BookshelfId = bookshelfId;
            ClientId = clientId;
            LibraryId = libraryId;
        }

        public static Book Create(
            string isbn,
            string title,
            string description,
            SectionId bookshelfId,
            ClientId clientId,
            LibraryId libraryId)
        {
            return new Book(BookId.Create(isbn), title, description, bookshelfId, clientId, libraryId);
        }

    }
}
