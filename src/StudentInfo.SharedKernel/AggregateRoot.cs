using System;

namespace StudentInfo.SharedKernel
{
	public abstract class AggregateRoot : Entity
	{
		public AggregateRoot()
			: base()
		{ }

		public AggregateRoot(Guid id)
			: base(id)
		{ }
	}
}