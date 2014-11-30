using StudentInfo.StudentApplication.Core.Interfaces;
using StudentInfo.StudentApplication.Core.Model.ApplicantAggregate;
using System;
using System.Linq;
using System.Collections.Generic;
using StudentInfo.SharedKernel.ValueObjects;

namespace StudentInfo.StudentApplication.Data.Repositories
{
	public class ApplicantRepository : IApplicantRepository
	{
		private StudentApplicationDbContext _dbContext;

		public ApplicantRepository(StudentApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		#region IApplicantRepository

		public void AddApplicant(Applicant applicant)
		{
			var applicantEntity = MapApplicantModelToEntity(applicant);
			_dbContext.Applicants.Add(applicantEntity);
		}

		public void AddApplication(Guid applicantId, Application application)
		{
			var applicantEntity = _dbContext.Applicants.SingleOrDefault(a => a.Id == applicantId);
			var applicationEntity = MapApplicationModelToEntity(application);
			if(applicantEntity != null)
			{
				applicantEntity.Applications.Add(applicationEntity);
			}
		}

		//public Applicant GetApplicantById(Guid id)
		//{
		//	throw new NotImplementedException();
		//}

		//public IEnumerable<Application> GetApplicationsByApplicant(Guid applicantId)
		//{
		//	throw new NotImplementedException();
		//}

		//public void RemoveApplicant(Applicant applicant)
		//{
		//	throw new NotImplementedException();
		//}

		//public void RemoveApplication(Applicant applicant, Application application)
		//{
		//	throw new NotImplementedException();
		//}

		public void Update(Applicant applicant)
		{

			_dbContext.SaveChanges();
		}

		#endregion


		#region Helper Methods

		private Entities.Applicant MapApplicantModelToEntity(Applicant applicantModel)
		{
			var applicantEntity = new Entities.Applicant()
			{
				Id = applicantModel.Id,
				FirstName = applicantModel.Name.First,
				LastName = applicantModel.Name.Last,
				MiddleName = applicantModel.Name.Middle
			};

			foreach (var applicationModel in applicantModel.Applications)
			{
				var applicationEntity = MapApplicationModelToEntity(applicationModel);
                applicantEntity.Applications.Add(applicationEntity);
			}

			return applicantEntity;
		}
		
		private Entities.Application MapApplicationModelToEntity(Application applicationModel)
		{
			var applicationEntity = new Entities.Application()
			{
				ApplicantId = applicationModel.ApplicantId,
				ApplicationDate = applicationModel.ApplicationDate,
				CourseId = applicationModel.Course.Id,
				Status = applicationModel.Status
			};

			return applicationEntity;
		}

		#endregion
	}
}