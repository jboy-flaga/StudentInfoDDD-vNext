using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;
using StudentInfo.StudentApplication.Data;
using StudentInfo.StudentApplication.Core.Interfaces;
using StudentInfo.StudentApplication.Data.Repositories;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Routing;

/// <summary>
/// NOTE: The comments/explanation on this class came from http://bitoftech.net/2014/11/18/getting-started-asp-net-5-mvc-6-web-api-entity-framework-7/
/// </summary>

namespace StudentInfo.Web
{
	/* This is the class which is responsible for adding the components needed in our pipeline - http://bitoftech.net/2014/11/18/getting-started-asp-net-5-mvc-6-web-api-entity-framework-7/ */
	public class Startup
	{
		public static IConfiguration Configuration { get; set; }

		// The constructor for this class is responsible to read the settings in the configuration file “config.json” 
		// that we’ve defined earlier, currently we have only the connection string. 
		// So the static object “Configuration” contains this setting which we’ll use in the coming step.
		public Startup(IHostingEnvironment env)
		{
			// Setup configuration sources.
			Configuration = new Configuration()
				.AddJsonFile("config.json")
				.AddEnvironmentVariables();
		}


		// This method gets called by the runtime.
		// The method “ConfigureServices” accepts parameter of type “IServiceCollection”, this method is called automatically 
		// when starting up the project, as well this is the core method responsible to register components in our pipeline
        public void ConfigureServices(IServiceCollection services)
		{
			// Add EF services to the services container.
			//// Add “EntityFramework” using SQL Server as our data provider for the database context named “StudentApplicationDbContext”.
			//services
			//	.AddEntityFramework()
			//	.AddSqlServer()
			//	.AddDbContext<StudentApplicationDbContext>(options =>
			//	{
			//		options.UseSqlServer(Configuration.Get("Data:DefaultConnection:ConnectionString"));
			//	});

			// Add “EntityFramework” using InMemory Store as our data provider for the database context named “StudentApplicationDbContext”.
            services
				.AddEntityFramework()
				.AddInMemoryStore()
				.AddDbContext<StudentApplicationDbContext>(options =>
				{
					options.UseInMemoryStore();
				});

			// Add the MVC component to our pipeline so we can use MVC and Web API.
			services.AddMvc();

			// Resolve dependency injection
			// Lastly and one of the nice out of the box features which has been added to ASP.NET 5 is Dependency Injection 
			// without using any external IoC containers, notice how we are creating scoped instance of our 
			// “IApplicantRepository” by calling  services.AddScoped<IApplicantRepository, ApplicantRepository>();. 
			// This instance will be available for the life time of the request.
			// There is a nice post about ASP.NET 5 dependency injection can be read here (http://www.khalidabuhakmeh.com/asp-vnext-dependency-injection-lifecycles). 
			// (Update by Nick Nelson to use Scoped injection instead of using Singleton instance because DbContext is not thread safe).
			services.AddScoped<IApplicantRepository, ApplicantRepository>();
		}

		// The method “Configure” accepts parameter of type “IApplicationBuilder”, this method configures the pipeline to 
		// use MVC and show the welcome page.
        public void Configure(IApplicationBuilder app)
		{
			// For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940

			app.UseMvc(); // ?Uses default route like the one below?
			//app.UseMvc(routes =>
			//{
			//	routes.MapRoute(
			//		name: "default",
			//		template: "{controller}/{action}/{id?}",
			//		defaults: new { controller = "Home", action = "Index" });
			//});

			//app.UseWelcomePage();
		}


		/**
		Explaination why we have to call “AddMvc” and “UseMvc” and what is the difference between both 
			- http://bitoftech.net/2014/11/18/getting-started-asp-net-5-mvc-6-web-api-entity-framework-7/
			
		Oron Ben Zvi says
			AddMvc is like requiring the assembly,
			UseMvc is putting the Mvc in the pipeline actually making requests coming through your controllers.


		Yishai Galatzer (@yigalatz) says
			The reason you call UseMvc separately than AddMvc is that AddMvc is where the MVC core services are added to the Dependency Injection system, and UseMvc is where MVC (specifically the routing middleware) is added to the pipeline.

			Since DI registration has to be completed before services can be consumed, the registration is broken into two steps.
		*/

	}
}
