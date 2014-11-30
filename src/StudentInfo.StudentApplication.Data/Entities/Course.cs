using System;

namespace StudentInfo.StudentApplication.Data.Entities
{
	public class Course
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
	}
}