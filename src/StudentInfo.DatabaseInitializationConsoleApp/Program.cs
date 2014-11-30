using System;
using System.Threading.Tasks;

namespace StudentInfo.DatabaseInitializationConsoleApp
{
	public class Program
	{
		public static async Task Main()	//public void Main(string[] args)
		{
			await CreateDatabase();

			Console.WriteLine("Database Created");
			Console.ReadLine();


			StudentApplicationDbContext db = new StudentApplicationDbContext();
			db.Courses.Add(new StudentApplication.Data.Entities.Course { Id = Guid.NewGuid(), Name = "New Course" });
			db.SaveChanges();


			StudentApplicationDbContext newDb = new StudentApplicationDbContext();
			foreach (var course in newDb.Courses)
			{
				Console.WriteLine(string.Format("{0} : {1}", course.Id, course.Name));
			}


			Console.ReadLine();
		}

		private static async Task CreateDatabase()
		{
			using (var db = new StudentApplicationDbContext())
			{
				await db.Database.EnsureCreatedAsync();
			}
		}
	}
}
