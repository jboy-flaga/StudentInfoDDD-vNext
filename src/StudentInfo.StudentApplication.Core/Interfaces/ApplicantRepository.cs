using StudentInfo.StudentApplication.Core.Model.ApplicantAggregate;
using System;
using System.Collections.Generic;

namespace StudentInfo.StudentApplication.Core.Interfaces
{
	// I heard that experts recommend to drop the naming convention for interfaces that starts with "I"

    public interface ApplicantRepository
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