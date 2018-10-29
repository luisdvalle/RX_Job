using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rx_job_webapi.ViewModels
{
    public class JobViewModel
    {
        public int JobID { get; set; }
        public string Name { get; set; }
        public int? Floor { get; set; }
        public string Status { get; set; }
        public string RoomType { get; set; }
    }
}
