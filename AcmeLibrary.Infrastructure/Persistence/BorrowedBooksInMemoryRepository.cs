using AcmeLibrary.Application.Interfaces.Persistance;
using AcmeLibrary.Application.Interfaces.Services;
using AcmeLibrary.Domain.Entities;
using AcmeLibrary.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLibrary.Infrastructure.Persistence
{
    public class BorrowedBooksInMemoryRepository : IBorrowedBooksRepository
    {
        private static readonly Dictionary<string, Dictionary<Guid, int>> _borrowedBooks = new();

        public void BorrowBook(string isbn, Guid clientId, int quantity)
        {
            if(!_borrowedBooks.ContainsKey(isbn))
                _borrowedBooks.Add(isbn, new Dictionary<Guid, int>());

            if (!_borrowedBooks[isbn].ContainsKey(clientId))
                _borrowedBooks[isbn].Add(clientId, quantity);
            else
                _borrowedBooks[isbn][clientId] += quantity;
        }

        public void ReturnBook(string isbn, Guid clientId, int quantity)
        {
            _borrowedBooks[isbn][clientId] -= quantity;
        }
    }
}
