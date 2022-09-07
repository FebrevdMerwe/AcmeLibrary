using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLibrary.Application.Interfaces.Persistance
{
    public interface IBorrowedBooksRepository
    {
        void BorrowBook(string isbn, Guid clientId, int quantity);
        void ReturnBook(string isbn, Guid clientId, int quantity);
    }
}
