using StudentInfo.StudentApplication.Core.Model.ApplicantAggregate;
using System;
using System.Linq;
using System.Collections.Generic;
using StudentInfo.SharedKernel.ValueObjects;

namespace StudentInfo.StudentApplication.Data.Repositories
{
	public class ApplicantRepository : Core.Interfaces.IApplicantRepository
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

		public IEnumerable<Applicant> GetAllApplicants()
		{
			return _dbContext.Applicants.Select(applicant => MapApplicantEntityToModel(applicant));
		}


		public Applicant GetApplicantById(Guid id)
		{
			Applicant applicant = _dbContext.Applicants.Where(a => a.Id == id).Select(a => MapApplicantEntityToModel(a)).SingleOrDefault();
			// TODO: remember the pattern of not returning null?
			return applicant;
		}

		//public IEnumerable<Application> GetApplicationsByApplicant(Guid applicantId)
		//{
		//	throw new NotImplementedException();
		//}

		public void RemoveApplicant(Applicant applicant)
		{
			Entities.Applicant applicantEntity = MapApplicantModelToEntity(applicant);
			_dbContext.Applicants.Attach(applicantEntity);
			_dbContext.Applicants.Remove(applicantEntity);
		}

		//public void RemoveApplication(Applicant applicant, Application application)
		//{
		//	throw new NotImplementedException();
		//}

		public void Update()
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

			return applicantEntity;
		}

		//private Entities.Application MapApplicationModelToEntity(Application applicationModel)
		//{
		//	var applicationEntity = new Entities.Application()
		//	{
		//		ApplicantId = applicationModel.ApplicantId,
		//		ApplicationDate = applicationModel.ApplicationDate,
		//		CourseId = applicationModel.Course.Id,
		//		Status = applicationModel.Status
		//	};

		//	return applicationEntity;
		//}
		
		private Applicant MapApplicantEntityToModel(Entities.Applicant applicantEntity)
		{
			var applicantModel = new Applicant(applicantEntity.Id)
			{
				Name = new FullName(applicantEntity.FirstName, applicantEntity.LastName, applicantEntity.MiddleName),				
			};
			
			return applicantModel;
		}

		#endregion
	}
}