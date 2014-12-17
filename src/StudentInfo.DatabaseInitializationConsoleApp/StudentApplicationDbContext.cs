using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.SqlServer;
using StudentInfo.StudentApplication.Data.Entities;

namespace StudentInfo.DatabaseInitializationConsoleApp
{
	public class StudentApplicationDbContext : DbContext
	{
		public DbSet<Applicant> Applicants { get; set; }
		public DbSet<Application> Applications { get; set; }
		public DbSet<Course> Courses { get; set; }

		// from https://github.com/aspnet/Entropy/blob/dev/samples/Data.SqlServer/Program.cs
		protected override void OnConfiguring(DbContextOptions builder)
		{
			// NOTE: in Window 7 the database is created in C:\Users\<username> folder
			// The name for the automatic instance is MSSQLLocalDB - http://msdn.microsoft.com/en-us/library/hh510202.aspx 
			builder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=StudentApplication;Trusted_Connection=True;");

			//builder.UseInMemoryStore();
		}
	}
}