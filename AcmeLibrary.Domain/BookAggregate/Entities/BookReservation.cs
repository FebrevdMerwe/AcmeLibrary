using AcmeLibrary.Domain.BookAggregate.ValueObjects;
using AcmeLibrary.Domain.ClientAggregate.ValueObjects;
using AcmeLibrary.Domain.Common.Models;

namespace AcmeLibrary.Domain.BookAggregate.Entities
{
    public class BookReservation : Entity<BookReservationId>
    {
        public ClientId ClientId {get;}

        private BookReservation(ClientId clientId) 
            : base(BookReservationId.CreateUnique())
        {
            ClientId = clientId;
        }

        public static BookReservation Create(ClientId clientId)
        {
            return new BookReservation(clientId);
        }
    }
}
