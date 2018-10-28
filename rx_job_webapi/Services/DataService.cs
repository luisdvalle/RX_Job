using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using rx_job_webapi.Interfaces;

namespace rx_job_webapi.Services
{
    public class DataService<T> : IDataService<T> where T : class
    {
        private RxJobDbContext _rxJobDbContext;
        private DbSet<T> _dbSet;

        public DataService()
        {
            var map = new HashSet<int>();
            _rxJobDbContext = new RxJobDbContext();
            _dbSet = _rxJobDbContext.Set<T>();
        }
        public void Add(T item)
        {
            _dbSet.Add(item);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.SingleOrDefault(predicate);
        }
    }
}