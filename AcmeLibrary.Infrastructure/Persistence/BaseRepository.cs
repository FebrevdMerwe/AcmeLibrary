using AcmeLibrary.Application.Interfaces.Persistance;
using AcmeLibrary.Domain.Common.Models;

namespace AcmeLibrary.Infrastructure.Persistence
{
    public class BaseRepository<T, TId> : IBaseRepository<T, TId>
        where T : AggregateRoot<TId>
        where TId : ValueObject
    {
        private static Dictionary<TId, T> _values = new();

        public virtual void Add(T item)
        {
            _values.Add(item.Id, item);
        }

        public virtual void Delete(T item)
        {
            _values.Remove(item.Id);
        }

        public virtual T Get(TId id)
        {
            return _values[id];
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _values.Values;
        }

        public virtual void Update(T item)
        {
            _values[item.Id] = item;
        }
    }
}
