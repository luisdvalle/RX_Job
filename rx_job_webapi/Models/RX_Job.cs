using System;

namespace rx_job_webapi.Models
{
    public class RX_Job
    {
        public int JobId { get; set; }
        public int ContractorId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int Floor { get; set; }
        public int Room { get; set; }
        public string DelayReason { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateCompleted { get; set; }
        public DateTime DateDelayed { get; set; }
        public int StatusNum { get; set; }
        public string RoomType { get; set; }
        public int RJobId { get; set; }
    }
}