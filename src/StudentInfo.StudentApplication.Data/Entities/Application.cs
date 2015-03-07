using StudentInfo.StudentApplication.Core.Model.Enums;
using System;
using System.Collections.Generic;

namespace StudentInfo.StudentApplication.Data.Entities
{
	public class Application
	{
		public Guid ApplicantId { get; set; }
		public Guid CourseId { get; set; }
		public DateTime ApplicationDate { get; set; }

		// I have chosen to use the enum from the model
		public Decision Status { get; set; }
	}
}