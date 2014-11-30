using System;
using Xunit;
using StudentInfo.SharedKernel.ValueObjects;

namespace StudentInfo.SharedKernel.UnitTest.ValueObjects
{
	public class FullNameTest
	{
		public class CreatingAFullNameWithFirstLastOrMiddleNamesHavingContiguousSpaces
		{
			FullName fullname;

			string firstNameWithSpaces;
			string lastNameWithSpaces;
			string middleNameWithSpaces;

			public CreatingAFullNameWithFirstLastOrMiddleNamesHavingContiguousSpaces()
			{
				Given();
				When();
			}

			private void Given()
			{
				firstNameWithSpaces = "  Camille   Joy  ";
				lastNameWithSpaces = " del   Toledo ";
				middleNameWithSpaces = " i  donte  knowe  Yete  ";
			}

			private void When()	// when a FullName is created with first, last, or midldle names having contiguous spaces
			{
				fullname = new FullName(firstNameWithSpaces, lastNameWithSpaces, middleNameWithSpaces);
			}

			[Fact]
			public void ThenSpacesShouldBeTrimmedFromTheNames()
			{
				Assert.Equal("Camille Joy", fullname.First);
				Assert.Equal("del Toledo", fullname.Last);
				Assert.Equal("i donte knowe Yete", fullname.Middle);
			}

			[Fact]
			public void ThenThisFullNameShouldBeEqualToOneWithProperlyFormattedNames()
			{
				string properlyFormattedFirstName = "Camille Joy";
				string properlyFormattedLastName = "del Toledo";
				string properlyFormattedMiddleName = "i donte knowe Yete";

				FullName properlyFormattedFullName = new FullName(properlyFormattedFirstName, properlyFormattedLastName, properlyFormattedMiddleName);

				Assert.True(fullname == properlyFormattedFullName);
			}
		}
	}
}