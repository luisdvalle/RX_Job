using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rx_job_webapi.Interfaces;
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

        [HttpGet("all")]
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

        [HttpPost("update/{jobID}")]
        public async Task<IActionResult> UpdateJob([FromRoute] int jobID, [FromBody] string status)
        {
            var job = await _unitOfWork.Jobs.GetSingle(j => j.JobID == jobID);

            if (job == null)
                return BadRequest("Invalid request. Job does not exist in the DB");

            job.Status = status;
            if (string.Equals(status, "Complete"))
            {
                job.DateCompleted = DateTime.UtcNow;
            }

            await _unitOfWork.Complete();
            _unitOfWork.Dispose();

            return Ok(true);
        }
    }
}