using Microsoft.Data.Entity;
using Microsoft.Data.Entity.InMemory;
using StudentInfo.StudentApplication.Data.Entities;

namespace StudentInfo.StudentApplication.Data
{
    public class StudentApplicationDbContext : DbContext
    {
		public DbSet<Applicant> Applicants { get; set; }

		// NOTE: we can put the configuration in the Startup class
		protected override void OnConfiguring(DbContextOptions builder)
		{
			// NOTE: in Window 7 the database is created in C:\Users\<username> folder
			// The name for the automatic instance is MSSQLLocalDB - http://msdn.microsoft.com/en-us/library/hh510202.aspx 
			//builder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=StudentApplication;Trusted_Connection=True;");

			//builder.UseInMemoryStore();
		}
	}
}