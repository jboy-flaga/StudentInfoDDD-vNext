using System;

namespace StudentInfo.SharedKernel.ValueObjects
{
	public class DateTimeRange :ValueObject<DateTimeRange>
	{
		public DateTime Start { get; private set; }
		public DateTime End { get; private set; }

		public DateTimeRange(DateTime start, DateTime end)
		{
			if (start < end) { throw new Exception("Start date must be before end date"); }

			this.Start = start;
			this.End = end;
		}
	}
}
