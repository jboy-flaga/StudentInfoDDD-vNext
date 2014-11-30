using System;

namespace StudentInfo.SharedKernel
{
	public abstract class Entity
	{
		public Guid Id { get; private set; }

		public Entity()
		{
			this.Id = Guid.NewGuid();
		}

		public Entity(Guid id)
		{
			this.Id = id;
		}

		// From Implementing DDD - Chapter 5: Entities -  Validation
		//public void Validate(ValidationNotificationHandler handler);

	}
}
