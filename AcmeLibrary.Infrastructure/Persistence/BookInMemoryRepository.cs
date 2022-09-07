using AcmeLibrary.Application.Interfaces.Persistance;
using AcmeLibrary.Application.Interfaces.Services;
using AcmeLibrary.Domain.Entities;

namespace AcmeLibrary.Infrastructure.Persistence
{
    public class BookInMemoryRepository : IBookRepository
    {
        private static readonly Dictionary<string, Book> _books = new();

        public void AddBook(Book book)
        {
            _books.Add(book.Isbn, book);
        }

        public Book? GetBookByISBN(string isbn)
        {
            if (_books.ContainsKey(isbn))
                return _books[isbn];

            return null;
        }

        public IEnumerable<Book> GetBooks()
        {
            return _books.Values;
        }

        public void RemoveBook(string isbn)
        {
            _books.Remove(isbn);
        }

        public void UpsertBook(Book book)
        {
            _books[book.Isbn] = book;
        }
    }
}