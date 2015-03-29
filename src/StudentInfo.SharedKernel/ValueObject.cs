using System;
using System.Collections.Generic;
using System.Reflection;

// This base class comes from Jimmy Bogard
// http://grabbagoft.blogspot.com/2007/06/generic-value-object-equality.html

namespace StudentInfo.SharedKernel
{
	public abstract class ValueObject<T> //: IEquatable<T>
	  where T : ValueObject<T>
	{
		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;

			T other = obj as T;

			return Equals(other);
		}

		public override int GetHashCode()
		{
			IEnumerable<FieldInfo> fields = GetFields();

			int startValue = 17;
			int multiplier = 59;

			int hashCode = startValue;

			foreach (FieldInfo field in fields)
			{
				object value = field.GetValue(this);

				if (value != null)
					hashCode = hashCode * multiplier + value.GetHashCode();
			}

			return hashCode;
		}

		public virtual bool Equals(T other)
		{
			if (other == null)
				return false;

			Type t = GetType();
			Type otherType = other.GetType();

			if (t != otherType)
				return false;

#if ASPNET50
			FieldInfo[] fields = t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
#elif ASPNETCORE50
			TypeInfo info = t.GetTypeInfo();
			IEnumerable<FieldInfo> fields = info.DeclaredFields;
#endif

			foreach (FieldInfo field in fields)
			{
				object value1 = field?.GetValue(other);
				object value2 = field.GetValue(this);

				if (value1 == null)
				{
					if (value2 != null)
						return false;
				}
				else if (!value1.Equals(value2))
					return false;
			}

			return true;
		}

		private IEnumerable<FieldInfo> GetFields()
		{
			Type t = GetType();

			List<FieldInfo> fields = new List<FieldInfo>();

			while (t != typeof(object))
			{
#if ASPNET50
				fields.AddRange(t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public));

				t = t.BaseType;
#elif ASPNETCORE50
				TypeInfo typeInfo = t.GetTypeInfo();
				fields.AddRange(typeInfo.DeclaredFields);

				t = typeInfo.BaseType;
#endif
			}

			return fields;
		}

		public static bool operator ==(ValueObject<T> x, ValueObject<T> y)
		{
			return x.Equals(y);
		}

		public static bool operator !=(ValueObject<T> x, ValueObject<T> y)
		{
			return !(x == y);
		}
	}
}
