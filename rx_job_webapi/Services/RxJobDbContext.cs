using Microsoft.EntityFrameworkCore;
using rx_job_webapi.Models;

namespace rx_job_webapi.Services
{
    public class RxJobDbContext : DbContext
    {
        public DbSet<RX_Job> RxJobTbl { get; set; }
        public DbSet<RX_RoomType> RxRoomTypeTbl { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\SQLEXPRESS; Database=Demo; Trusted_Connection=True");
        }
    }
}