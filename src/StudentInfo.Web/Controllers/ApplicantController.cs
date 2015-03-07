using Microsoft.AspNet.Mvc;
using StudentInfo.StudentApplication.Core.Interfaces;
using StudentInfo.Web.Models;
using System.Collections.Generic;
using System;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentInfo.Web.Controllers
{
	public class ApplicantController : Controller
	{
		private IApplicantRepository _applicantRepository;

		public ApplicantController(IApplicantRepository applicationRepository)
		{
			_applicantRepository = applicationRepository;
		}

		// GET: /<controller>/
		public IActionResult Index()
		{
			return View(GetAllApplicantVMs());
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View(new Applicant());
		}

		[HttpPost]
		public IActionResult Create(Applicant applicant)
		{
			_applicantRepository.AddApplicant(new StudentApplication.Core.Model.ApplicantAggregate.Applicant
			{
				Name = new SharedKernel.ValueObjects.FullName(applicant.FirstName, applicant.LastName)
			});

			_applicantRepository.Update();

			return View("Index", GetAllApplicantVMs());
		}

		[HttpGet]
		public IActionResult Delete(Guid id)
		{
			StudentApplication.Core.Model.ApplicantAggregate.Applicant applicant = _applicantRepository.GetApplicantById(id);
			
			if (applicant == null) { return HttpNotFound(); }

			Applicant applicantVM = new Applicant()
			{
				Id = applicant.Id,
				FirstName = applicant.Name.First,
				LastName = applicant.Name.Last
			};

			return View(applicantVM);
		}

		[HttpPost]
		[ActionName("Delete")]
		public IActionResult DeleteConfirm(Guid id)
		{
			StudentApplication.Core.Model.ApplicantAggregate.Applicant applicant = _applicantRepository.GetApplicantById(id);
			_applicantRepository.RemoveApplicant(applicant);
			_applicantRepository.Update();

			return RedirectToAction("Index");
		}

		private List<Applicant> GetAllApplicantVMs()
		{
			var applicantDomainModels = _applicantRepository.GetAllApplicants();
			var applicantVMs = new List<Applicant>();

			foreach (var applicantDomainModel in applicantDomainModels)
			{
				applicantVMs.Add(new Applicant
				{
					Id = applicantDomainModel.Id,
					FirstName = applicantDomainModel.Name.First,
					LastName = applicantDomainModel.Name.Last
				});
			}

			return applicantVMs;
		}
	}
}
