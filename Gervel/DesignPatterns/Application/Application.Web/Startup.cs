using Application.Web.Middlewares;
using Domain.Customer.Repositories;
using Domain.Training.Repositories;
using Infrastructure.Common.Options;
using Infrastructure.Customer.Helpers;
using Infrastructure.Customer.Options;
using Infrastructure.Customer.Repositories;
using Infrastructure.Training.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Application.Web {
	public class Startup {
		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services) {
			services.AddControllers();
			services.AddSwaggerGen(c => {
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "DP_Example", Version = "v1" });
			});

			services.Configure<DbConfig>(Configuration);

			services.AddMediatR(Assembly.GetExecutingAssembly());

			services.AddSingleton<ILiteDBContext, LiteDBContext>();
			services.AddTransient<ICustomerRepository, CustomerRepository>();
			//services.AddTransient<ISupportRepository, SupportRepository>();


			// Exercise 1 - Training Domain
			services.Configure<CommonDbConfig>(Configuration);
			services.AddSingleton<ITrainingDBContext, TrainingDBContext>();
			services.AddTransient<ITrainingRepository, TrainingRepository>();

			// Behavior Pattern
			Logger.Instance.RegisterObserver(new ConsoleLogger());
			Logger.Instance.RegisterObserver(new TextLogger());
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
			if (env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));
			}

			app.UseHttpsRedirection();

			app.UseMiddleware<ErrorHandlingMiddleware>();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints => {
				endpoints.MapControllers();
			});
		}
	}
}
