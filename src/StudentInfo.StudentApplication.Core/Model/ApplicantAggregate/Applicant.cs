using StudentInfo.SharedKernel;
using StudentInfo.SharedKernel.ValueObjects;
using System;

namespace StudentInfo.StudentApplication.Core.Model.ApplicantAggregate
{
	public class Applicant : AggregateRoot
	{
		public FullName Name { get; set; }

		public Applicant()
			: base(Guid.NewGuid())
		{ }

		public Applicant(Guid id)
			: base(id)
		{ }
	}
}
