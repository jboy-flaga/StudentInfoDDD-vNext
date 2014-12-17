using StudentInfo.StudentApplication.Core.Model.ApplicantAggregate;
using System;
using System.Collections.Generic;

namespace StudentInfo.StudentApplication.Core.Interfaces
{
    public interface IApplicantRepository
    {
		//Applicant GetApplicantById(Guid id);
		//IEnumerable<Application> GetApplicationsByApplicant(Guid applicantId);

		// temporary method
		IEnumerable<Applicant> GetAllApplicants();

		void AddApplicant(Applicant applicant);
		void AddApplication(Guid applicantId, Application application);

		//void RemoveApplicant(Applicant applicant);
		//void RemoveApplication(Applicant applicant, Application application);

		void Update();
    }
}