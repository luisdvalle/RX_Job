using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace rx_job_webapi.Interfaces
{
    public interface IDataRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task Add(T item);
        Task<T> GetSingle(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
    }
}