using AcmeLibrary.Domain.Common.Models;

namespace AcmeLibrary.Domain.ClientAggregate.ValueObjects
{
    public sealed class BookReviewId : ValueObject
    {
        public Guid Value { get; }

        private BookReviewId(Guid value)
        {
            Value = value;
        }

        public static BookReviewId CreateUnique()
        {
            return new BookReviewId(Guid.NewGuid());
        }

        public static BookReviewId Create(Guid value)
        {
            return new BookReviewId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
