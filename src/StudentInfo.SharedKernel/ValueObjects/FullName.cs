using System;
using System.Linq;

namespace StudentInfo.SharedKernel.ValueObjects
{
	public class FullName : ValueObject<FullName>
	{
		public string First { get; private set; }
		public string Last { get; private set; }
		public string Middle { get; private set; }

		public string MiddleInitial { get { return string.IsNullOrWhiteSpace(this.Middle) ? string.Empty : this.Middle[0].ToString(); } }

		public FullName(string first, string last, string middle = "")
		{
			if (string.IsNullOrWhiteSpace(first)) { throw new ArgumentException("First name should not be null or empty"); }
			if (string.IsNullOrWhiteSpace(last)) { throw new ArgumentException("Last name should not be null or empty"); }

			char[] whitespaces = " \n\t".ToCharArray();

			// We need to check for consecutive whitespaces in each part of the name because, for example, 
			// first name might contain two or more words separated by spaces: "  Camille    Joy   "
			// And we want that name to be equal to a string with only one whitespace "Camille Joy"
			// TODO: We might want to change this to use regular expression in the future (if it is more efficient)
			first = string.Join(" ", first.Split(whitespaces, StringSplitOptions.RemoveEmptyEntries).Select(fn => fn.Trim()).ToArray());
			last = string.Join(" ", last.Split(whitespaces, StringSplitOptions.RemoveEmptyEntries).Select(fn => fn.Trim()).ToArray());

			// If middle name is null we store it as string.Empty so that users will not need to check 
			// for null everytime they use the property Middle
			middle = middle == null ? string.Empty
						: string.Join(" ", middle.Split(whitespaces, StringSplitOptions.RemoveEmptyEntries).Select(fn => fn.Trim()).ToArray());

			this.First = first;
			this.Last = last;
			this.Middle = middle;
		}

		public override string ToString()
		{
			return FormatAsFML();
		}

		public string FormatAsLFM()
		{
			if (string.IsNullOrEmpty(this.Middle))
			{
				return string.Format("{0}, {1}", this.Last, this.First);
			}
			else
			{
				return string.Format("{0}, {1} {2}.", this.Last, this.First, this.MiddleInitial);
			}
		}

		public string FormatAsFML()
		{
			if (string.IsNullOrEmpty(this.Middle))
			{
				return string.Format("{0} {1}", this.First, this.Last);
			}
			else
			{
				return string.Format("{0} {1}. {2}", this.First, this.MiddleInitial, this.Last);
			}
		}

	}
}
