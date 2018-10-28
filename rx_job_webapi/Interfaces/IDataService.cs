using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace rx_job_webapi.Interfaces
{
    public interface IDataService<T>
    {
        IEnumerable<T> GetAll();
        void Add(T item);
        T GetSingle(Expression<Func<T, bool>> predicate);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
    }
}