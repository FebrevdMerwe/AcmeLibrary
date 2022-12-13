using AcmeLibrary.Domain.Common.Models;

namespace AcmeLibrary.Domain.BookshelfAggregate.ValueObjects
{
    public sealed class BookshelfId : ValueObject
    {
        public Guid Value { get; }

        private BookshelfId(Guid value)
        {
            Value = value;
        }

        public static BookshelfId CreateUnique()
        {
            return new BookshelfId(Guid.NewGuid());
        }

        public static BookshelfId Create(Guid value)
        {
            return new BookshelfId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
