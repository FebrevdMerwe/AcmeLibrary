using AcmeLibrary.Domain.Entities;

namespace AcmeLibrary.Application.Interfaces.Persistance
{
    public interface IBookRepository
    {
        void AddBook(Book book);
        Book? GetBookByISBN(string ISBN);
        void RemoveBook(string ISBN);
        void UpsertBook(Book book);
    }
}