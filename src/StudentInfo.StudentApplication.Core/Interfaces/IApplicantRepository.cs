using StudentInfo.StudentApplication.Core.Model.ApplicantAggregate;
using System;
using System.Collections.Generic;

namespace StudentInfo.StudentApplication.Core.Interfaces
{
	// I heard that experts recommend to drop the naming convention for interfaces that starts with "I"

    public interface IApplicantRepository
    {
		Applicant GetApplicantById(Guid id);
		//IEnumerable<Application> GetApplicationsByApplicant(Guid applicantId);

		// temporary method
		IEnumerable<Applicant> GetAllApplicants();

		void AddApplicant(Applicant applicant);

		// NOTE: An applicant can exist without an Application but an Application cannot exist without an Applicant
		//			 - therefore the association of the Applicant to the Application should be placed in the Application class
		//				(you can create a factory method or a public constructor that requires an Applicant as parameter
		//void AddApplication(Guid applicantId, Application application);

		void RemoveApplicant(Applicant applicant);

		void Update();
    }
}