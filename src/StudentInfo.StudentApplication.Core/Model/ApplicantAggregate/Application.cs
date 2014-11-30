using StudentInfo.StudentApplication.Core.Model.Enums;
using System;

namespace StudentInfo.StudentApplication.Core.Model.ApplicantAggregate
{
    public class Application //: ValueObject<Application>
    {
        public Guid ApplicantId { get; private set; }
        public Course Course { get; private set; }
		public DateTime ApplicationDate { get; private set; }
		public ApplicationStatus Status { get; set; }

        public Application(Guid applicantId, Course course)
        {
            this.ApplicantId = applicantId;
			this.Course = course;
			this.Status = ApplicationStatus.Pending;
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
