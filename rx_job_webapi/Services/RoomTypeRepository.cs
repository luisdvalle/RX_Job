using Microsoft.EntityFrameworkCore;
using rx_job_webapi.Interfaces;
using rx_job_webapi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rx_job_webapi.Services
{
    public class RoomTypeRepository : DataRepository<RX_RoomType>, IRoomTypeRepository
    {
        public RxJobDbContext RxJobDbContext => (_dbContext as RxJobDbContext);

        public RoomTypeRepository(RxJobDbContext rxJobDbContext)
            :base(rxJobDbContext)
        {

        }
        public async Task<IEnumerable<RX_RoomType>> GetTopCounts(int count)
        {
            return await RxJobDbContext.RX_RoomType.OrderByDescending(r => r.Count).Take(count).ToListAsync();
        }
    }
}
