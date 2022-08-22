using AcmeLibrary.Application.Interfaces.Persistance;
using AcmeLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLibrary.Infrastructure.Persistence
{
    public class BookInMemoryRepository : IBookRepository
    {
        private static readonly Dictionary<string, Book> _books = new();

        public void AddBook(Book book)
        {
            _books.Add(book.Isbn, book);
        }

        public Book? GetBookByISBN(string ISBN)
        {
            if (_books.ContainsKey(ISBN))
                return _books[ISBN];

            return null;
        }

        public void RemoveBook(string ISBN)
        {
            _books.Remove(ISBN);
        }

        public void UpsertBook(Book book)
        {
            _books[book.Isbn] = book;
        }
    }
}
