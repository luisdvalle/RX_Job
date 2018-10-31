using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rx_job_webapp.Interfaces;
using rx_job_webapp.Models;
using rx_job_webapp.ViewModels;

namespace rx_job_webapp.Controllers
{
    public class HomeController : Controller
    {
        private IRestClient<Job> _jobRestClient;

        public HomeController(IRestClient<Job> jobRestClient)
        {
            _jobRestClient = jobRestClient;
            _jobRestClient.Host = "http://localhost:5000/";
            _jobRestClient.Path = "api/job/all";
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var jobs = await _jobRestClient.GetAll();
            JobViewModel vm = new JobViewModel();
            vm.Jobs = jobs;
            vm.Count = jobs.Count();

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Complete(int jobId)
        {

            _jobRestClient.Path = "api/job/update/" + jobId;
            var result = await _jobRestClient.UpdateSingle("Complete");

            if (result)
                return RedirectToAction("Index", "Home");

            ModelState.AddModelError("", "Error while updating Job. Please try later");
            return RedirectToAction("Index", "Home");
        }
    }
}