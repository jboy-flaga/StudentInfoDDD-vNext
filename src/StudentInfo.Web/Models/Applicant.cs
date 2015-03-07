using System;

namespace StudentInfo.Web.Models
{
	public class Applicant
	{
		public Guid Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}