using Microsoft.EntityFrameworkCore;
using rx_job_webapi.Interfaces;
using rx_job_webapi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rx_job_webapi.Services
{
    public class JobRepository : DataRepository<RX_Job>, IJobRepository
    {
        public RxJobDbContext RxJobDbContext => (_dbContext as RxJobDbContext);

        public JobRepository(RxJobDbContext rxJobDbContext)
            :base(rxJobDbContext)
        {
        }

        public async Task<IEnumerable<RX_Job>> GetLastCompletedJobs(int count)
        {
            return await RxJobDbContext.RX_Job.OrderByDescending(j => j.DateCompleted).Take(count).ToListAsync();
        }
    }
}
