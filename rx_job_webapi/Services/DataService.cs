using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
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
        public async Task Add(T item)
        {
            await _dbSet.AddAsync(item);
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetSingle(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.SingleOrDefaultAsync(predicate);
        }
    }
}