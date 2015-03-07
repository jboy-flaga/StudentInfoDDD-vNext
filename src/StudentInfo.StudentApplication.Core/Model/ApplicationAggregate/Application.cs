using StudentInfo.StudentApplication.Core.Model.ApplicantAggregate;
using System;
using System.Collections.Generic;
using StudentInfo.SharedKernel;

// this idea came from Julie Lerman in her lecture "Entity Framework in Core-Business Applications that Leverage DDD"
// TODO:the Application is an aggregate root so it is the point of entry for everything in this aggregate
// - It has many courses
// - It has an applicant

namespace StudentInfo.StudentApplication.Core.Model.ApplicationAggregate
{
	public class Application : AggregateRoot
	{
		public Applicant Applicant { get; private set; }
		public IList<Enrollment> Enrollments { get; private set; }
		public DateTime ApplicationDate { get; private set; }

		public Application CreateApplication(Applicant applicant)
		{
			return new Application(applicant);
		}

		private Application(Applicant applicant)
			: base(Guid.NewGuid())
		{
			this.Enrollments = new List<Enrollment>();
			this.Applicant = applicant;
		}

		public void AddEnrollment(Enrollment enrollment)
		{
			this.Enrollments.Add(enrollment);
		}

		public void AddEnrollments(IEnumerable<Enrollment> enrollments)
		{
			foreach (var enrollment in enrollments)
			{
				this.Enrollments.Add(enrollment);
			}
		}

		// QUESTION: should Submit() be in in the Application entity or should be in Applicant entity
		// or should be in a domain service?
		public void Submit()
		{
			ApplicationDate = DateTime.Now;
			// TODO: raise domain event application submitted
		}
	}
}