using rx_job_webapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rx_job_webapi.Interfaces
{
    public interface IJobRepository : IDataRepository<RX_Job>
    {
        Task<IEnumerable<RX_Job>> GetLastCompletedJobs(int count);
    }
}
