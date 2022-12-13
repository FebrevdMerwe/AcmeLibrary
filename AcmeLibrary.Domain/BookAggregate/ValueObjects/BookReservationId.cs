using AcmeLibrary.Domain.Common.Models;

namespace AcmeLibrary.Domain.BookAggregate.ValueObjects
{
    public sealed class BookReservationId : ValueObject
    {
        public Guid Value { get; }

        private BookReservationId(Guid value)
        {
            Value = value;
        }

        public static BookReservationId CreateUnique()
        {
            return new BookReservationId(Guid.NewGuid());
        }

        public static BookReservationId Create(Guid value)
        {
            return new BookReservationId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
