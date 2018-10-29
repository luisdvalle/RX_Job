using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rx_job_webapi.Interfaces;
using rx_job_webapi.Models;
using rx_job_webapi.ViewModels;

namespace rx_job_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public JobController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllJobs()
        {
            var jobsList = await _unitOfWork.Jobs.GetAll();

            return Ok(jobsList.Select(
                j => new JobViewModel
                {
                    JobID = j.JobID, Floor = j.Floor, Name = j.Name, RoomType = j.RoomType, Status = j.Status
                })
            );
        }

        //[HttpPost("Update")]
        //public async Task<IActionResult> UpdateJob([FromBody] int jobID, [FromBody] string status)
        //{

        //}
    }
}