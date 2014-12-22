using Microsoft.AspNet.Mvc;
using StudentInfo.StudentApplication.Core.Interfaces;
using StudentInfo.Web.Models;
using System.Collections.Generic;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentInfo.Web.Controllers
{
    public class ApplicantController : Controller
    {
		private ApplicantRepository _applicantRepository;

		public ApplicantController(ApplicantRepository applicationRepository)
		{
			_applicantRepository = applicationRepository;
		}

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(GetAllApplicants());
        }

		[HttpGet]
		public IActionResult AddApplicant()
		{
			return View(new Applicant());
		}

		[HttpPost]
		public IActionResult AddApplicant(Applicant applicant)
		{
			_applicantRepository.AddApplicant(new StudentApplication.Core.Model.ApplicantAggregate.Applicant
			{
				Name = new SharedKernel.ValueObjects.FullName(applicant.FirstName, applicant.LastName)
			});

			_applicantRepository.Update();

			return View("Index", GetAllApplicants());
		}

		private List<Applicant> GetAllApplicants()
		{
			var applicantDomainModels = _applicantRepository.GetAllApplicants();
			var applicants = new List<Applicant>();

			foreach (var applicantDomainModel in applicantDomainModels)
			{
				applicants.Add(new Applicant
				{
					FirstName = applicantDomainModel.Name.First,
					LastName = applicantDomainModel.Name.Last
				});
			}

			return applicants;
		}
    }
}
