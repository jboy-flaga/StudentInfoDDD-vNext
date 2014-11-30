using System;
using System.Collections.Generic;

namespace StudentInfo.StudentApplication.Data.Entities
{
    public class Applicant
    {
		public Guid Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MiddleName { get; set; }
		public ICollection<Application> Applications { get; set; }
	}
}