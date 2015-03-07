using StudentInfo.SharedKernel;
using StudentInfo.StudentApplication.Core.Model.Enums;
using System;

namespace StudentInfo.StudentApplication.Core.Model.ApplicationAggregate
{
    public class Enrollment : Entity
    {
		public Course Course { get; set; }
		public Decision Decision { get; set; }

		public Enrollment(Course course)
		{
			this.Course = course;
			this.Decision = Decision.Pending;
		}
    }
}