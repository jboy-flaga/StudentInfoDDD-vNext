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
		public DbSet<Application> Applications { get; set; }
		public DbSet<Course> Courses { get; set; }

		// from https://github.com/aspnet/Entropy/blob/dev/samples/Data.SqlServer/Program.cs
		protected override void OnConfiguring(DbContextOptions builder)
		{
			// NOTE: in Window 7 the database is created in C:\Users\<username> folder
			builder.UseSqlServer(@"Server=(localdb)\v11.0;Database=StudentApplication;Trusted_Connection=True;");
		}
	}
}