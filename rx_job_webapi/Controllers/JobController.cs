using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rx_job_webapi.Interfaces;
using rx_job_webapi.Models;

namespace rx_job_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IDataService<RX_Job> _jobDataService;

        public JobController(IDataService<RX_Job> jobDataService)
        {
            _jobDataService = jobDataService;
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllJobs()
        {
            return Ok(await _jobDataService.GetAll());
        }
    }
}