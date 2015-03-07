using StudentInfo.SharedKernel;
using StudentInfo.SharedKernel.ValueObjects;
using System;

namespace StudentInfo.StudentApplication.Core.Model.ApplicationAggregate
{
	public class Course : ValueObject<Course>
	{
		public string Name { get; private set; }
		public DateTimeRange CoursePeriod { get; set; }

		public Course()
			: this(Guid.NewGuid())
		{ }

		public Course(Guid id)
		{ }
	}
}
