using Microsoft.AspNetCore.Mvc;
using TechJobs.Data;
using TechJobs.Models;
using TechJobs.ViewModels;

using TechJobs.ViewModels;

namespace TechJobs.Controllers
{
    public class JobController : Controller
    {
        // Our reference to the data store
        private static JobData JobData;

        static JobController()
        {
            JobData = JobData.GetInstance();
        }

        // The detail display for a given Job at URLs like /Job?id=17
        public IActionResult Index(int id)
        {
            // TODO #1 - get the Job with the given ID and pass it into the view
            //******************************************************************
            Job someJob = JobData.Find(id);
            SingleJobViewModel singleJobViewModel = new SingleJobViewModel();
            singleJobViewModel.Title = "Single Job Display";
            singleJobViewModel.job = someJob;
            return View(singleJobViewModel);
        }

        [HttpGet]
        public IActionResult New()
        {
            NewJobViewModel newJobViewModel = new NewJobViewModel();
            return View(newJobViewModel);
        }

        [HttpPost]
        public IActionResult New(NewJobViewModel newJobViewModel)
        {
            // TODO #6 - Validate the ViewModel and if valid, create a
            // new Job and add it to the JobData data store. Then
            // redirect to the Job detail (Index) action/view for the new Job.

            if (ModelState.IsValid)
            {
                // Add the new job to  existing jobs
                Job newJob = newJobViewModel.CreateJob();
                JobData.Jobs.Add(newJob);
                return Redirect("/Job?id=" + newJob.ID);
            }

            return View(newJobViewModel);
        }
    }
}