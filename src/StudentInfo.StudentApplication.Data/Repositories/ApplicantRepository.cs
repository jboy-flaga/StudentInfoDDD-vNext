using StudentInfo.StudentApplication.Core.Interfaces;
using StudentInfo.StudentApplication.Core.Model.ApplicantAggregate;
using System;
using System.Linq;
using System.Collections.Generic;
using StudentInfo.SharedKernel.ValueObjects;

namespace StudentInfo.StudentApplication.Data.Repositories
{
	public class ConcreteApplicantRepository : Core.Interfaces.ApplicantRepository
	{
		private StudentApplicationDbContext _dbContext;

		public ConcreteApplicantRepository(StudentApplicationDbContext dbContext)
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
			if (applicantEntity != null)
			{
				applicantEntity.Applications.Add(applicationEntity);
			}
		}

		public IEnumerable<Applicant> GetAllApplicants()
		{
			return _dbContext.Applicants.Select(applicant => MapApplicantEntityToModel(applicant));
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
		
		private Applicant MapApplicantEntityToModel(Entities.Applicant applicantEntity)
		{
			var applicantModel = new Applicant(applicantEntity.Id)
			{
				Name = new FullName(applicantEntity.FirstName, applicantEntity.LastName, applicantEntity.MiddleName),				
			};

			//// TODO: map applications
			//var applications = new List<Application>();
			//foreach (var applicationEntity in applicantEntity.Applications)
			//{
			//	var applicationModel = MapApplicationEntityToModel(applicationEntity);
			//	applications.Add(applicationModel);
			//}

			return applicantModel;
		}

		#endregion
	}
}