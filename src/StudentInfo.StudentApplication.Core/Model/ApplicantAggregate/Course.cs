using StudentInfo.SharedKernel;
using StudentInfo.SharedKernel.ValueObjects;
using System;

namespace StudentInfo.StudentApplication.Core.Model.ApplicantAggregate
{
	public class Course : Entity
	{
		public string Name { get; private set; }
		public DateTimeRange CoursePeriod { get; set; }

		public Course()
			: this(Guid.NewGuid())
		{ }
		public Course(Guid id)
			: base(id)
		{ }
	}
}
