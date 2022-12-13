using AcmeLibrary.Domain.Common.Models;

namespace AcmeLibrary.Domain.BookAggregate.ValueObjects
{
    public sealed class BookIsbn : ValueObject
    {
        //ISBN number of book
        public string Value { get; }

        private BookIsbn(string value)
        {
            Value = value;
        }

        public static BookIsbn Create(string value)
        {
            return new BookIsbn(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
