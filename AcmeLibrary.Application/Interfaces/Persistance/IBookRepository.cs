using AcmeLibrary.Domain.Entities;

namespace AcmeLibrary.Application.Interfaces.Persistance
{
    public interface IBookRepository
    {
        void AddBook(Book book);

        Book? GetBookByISBN(string isbn);

        IEnumerable<Book> GetBooks();

        void RemoveBook(string isbn);

        void UpsertBook(Book book);
    }
}