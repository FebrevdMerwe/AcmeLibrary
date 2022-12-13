using AcmeLibrary.Domain.Common.Models;

namespace AcmeLibrary.Domain.ClientAggregate.ValueObjects
{
    public sealed class LibraryId : ValueObject
    {
        public Guid Value { get; }

        private LibraryId(Guid value)
        {
            Value = value;
        }

        public static LibraryId CreateUnique()
        {
            return new LibraryId(Guid.NewGuid());
        }

        public static LibraryId Create(Guid value)
        {
            return new LibraryId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
