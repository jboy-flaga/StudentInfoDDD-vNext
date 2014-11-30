using Microsoft.Data.Entity;
using StudentInfo.StudentApplication.Data.Entities;

namespace StudentInfo.StudentApplication.Data
{
    public class StudentApplicationDbContext : DbContext
    {
		public DbSet<Application> Applications { get; set; }
		public DbSet<Applicant> Applicants { get; set; }

		protected override void OnConfiguring(DbContextOptions builder)
		{
			// NOTE: in Window 7 the database is created in C:\Users\<username> folder
			builder.UseSqlServer(@"Server=(localdb)\v11.0;Database=StudentApplication;Trusted_Connection=True;");
		}
	}
}