using rx_job_webapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rx_job_webapi.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IJobRepository Jobs { get; }
        IRoomTypeRepository RoomTypes { get; }
        Task<int> Complete();
    }
}
