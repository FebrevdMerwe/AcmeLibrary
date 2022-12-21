using AcmeLibrary.Domain.Common.Models;

namespace AcmeLibrary.Domain.BookAggregate.ValueObjects
{
    public sealed class BookId : ValueObject
    {
        //ISBN number of book
        public string Value { get; }

        private BookId(string value)
        {
            Value = value;
        }

        public static BookId Create(string value)
        {
            return new BookId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
