using AcmeLibrary.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeLibrary.Application.Interfaces.Persistance
{
    public interface IBaseRepository<T, TId>
        where T : AggregateRoot<TId>
        where TId : ValueObject
    {
        IEnumerable<T> GetAll();
        T Get(TId id);
        void Add(T item);
        void Update(T item);
        void Delete(T item);
    }
}
