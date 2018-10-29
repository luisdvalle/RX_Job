using rx_job_webapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rx_job_webapi.Interfaces
{
    public interface IRoomTypeRepository : IDataRepository<RX_RoomType>
    {
        Task<IEnumerable<RX_RoomType>> GetTopCounts(int count);
    }
}
