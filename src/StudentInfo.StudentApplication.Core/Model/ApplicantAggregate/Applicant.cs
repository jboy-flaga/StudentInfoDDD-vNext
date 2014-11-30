using StudentInfo.SharedKernel;
using StudentInfo.SharedKernel.ValueObjects;
using System;
using System.Linq;
using System.Collections.Generic;

namespace StudentInfo.StudentApplication.Core.Model.ApplicantAggregate
{
	public class Applicant : Entity	// aggregate root
	{
		private List<Application> _applications;

		public FullName Name { get; set; }
		public IEnumerable<Application> Applications
		{
			get { return _applications; }
			private set { _applications = value.ToList(); }
		}

		public Applicant()
			: this(id: Guid.NewGuid())
		{ }

		public Applicant(Guid id)
			: base(id)
		{
			_applications = new List<Application>();
		}

		public void ApplyForCourse(Course course)
		{
			_applications.Add(new Application(this.Id, course));
		}

		public void SubmitApplications()
		{
			foreach (var application in Applications)
			{
				application.Submit();
			}
		}
	}
}
