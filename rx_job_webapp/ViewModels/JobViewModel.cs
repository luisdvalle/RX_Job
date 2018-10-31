using rx_job_webapp.Models;
using System.Collections.Generic;

namespace rx_job_webapp.ViewModels
{
    public class JobViewModel
    {
        public int Count { get; set; }
        public IEnumerable<Job> Jobs { get; set; }
    }
}
