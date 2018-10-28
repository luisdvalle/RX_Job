using Microsoft.EntityFrameworkCore;
using rx_job_webapi.Models;

namespace rx_job_webapi.Services
{
    public class RxJobDbContext : DbContext
    {
        public DbSet<RX_Job> RX_Job { get; set; }
        public DbSet<RX_RoomType> RX_RoomType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=localhost\SQLEXPRESS; Database=Demo; Trusted_Connection=True");
        }
    }
}