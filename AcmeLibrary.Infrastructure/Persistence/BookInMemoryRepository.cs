using AcmeLibrary.Application.Interfaces.Persistance;
using AcmeLibrary.Application.Interfaces.Services;
using AcmeLibrary.Domain.Entities;

namespace AcmeLibrary.Infrastructure.Persistence
{
    public class BookInMemoryRepository : IBookRepository
    {
        private static readonly Dictionary<string, Book> _books = new();
        private readonly IIsbnService _isbnService;

        public BookInMemoryRepository(IIsbnService isbnService)
        {
            _isbnService = isbnService ?? throw new ArgumentNullException(nameof(isbnService));
        }

        public void AddBook(Book book)
        {
            var cleanIsbn = _isbnService.Dehyphenate(book.Isbn);
            book.Isbn = _isbnService.Hyphenate(cleanIsbn);

            _books.Add(cleanIsbn, book);
        }

        public Book? GetBookByISBN(string isbn)
        {
            var cleanIsbn = _isbnService.Dehyphenate(isbn);

            if (_books.ContainsKey(cleanIsbn))
                return _books[cleanIsbn];

            return null;
        }

        public IEnumerable<Book> GetBooks()
        {
            return _books.Values;
        }

        public void RemoveBook(string isbn)
        {
            var cleanIsbn = _isbnService.Dehyphenate(isbn);
            _books.Remove(cleanIsbn);
        }

        public void UpsertBook(Book book)
        {
            var cleanIsbn = _isbnService.Dehyphenate(book.Isbn);
            book.Isbn = _isbnService.Hyphenate(cleanIsbn);

            _books[cleanIsbn] = book;
        }
    }
}