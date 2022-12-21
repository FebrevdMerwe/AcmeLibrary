using AcmeLibrary.Domain.Common.Models;

namespace AcmeLibrary.Domain.BookshelfAggregate.ValueObjects
{
    public sealed class SectionId : ValueObject
    {
        public Guid Value { get; }

        private SectionId(Guid value)
        {
            Value = value;
        }

        public static SectionId CreateUnique()
        {
            return new SectionId(Guid.NewGuid());
        }

        public static SectionId Create(Guid value)
        {
            return new SectionId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
