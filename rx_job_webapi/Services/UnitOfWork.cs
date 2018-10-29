using rx_job_webapi.Interfaces;
using rx_job_webapi.Models;
using System.Threading.Tasks;

namespace rx_job_webapi.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RxJobDbContext _rxJobDbContext;
        public IJobRepository Jobs { get; private set; }
        public IRoomTypeRepository RoomTypes { get; private set; }

        public UnitOfWork(RxJobDbContext rxJobDbContext)
        {
            _rxJobDbContext = rxJobDbContext;
            Jobs = new JobRepository(_rxJobDbContext);
            RoomTypes = new RoomTypeRepository(_rxJobDbContext);
        }

        public async Task<int> Complete()
        {
            return await _rxJobDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _rxJobDbContext.Dispose();
        }
    }
}
