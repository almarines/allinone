using Customers.Domain.Repositories;
using Customers.Infra.Helpers;
using Customers.Infra.Options;
using Customers.Infra.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<DbConfig>(Configuration);
            var connectionString = Configuration.GetValue<string>("LoggerDBConnectionString");
            var loggerContext = new LoggerDBContext(connectionString);

            Customers.Infra.Helpers.Logger.Instance.RegisterObserver(new ConsoleLogger());
            Customers.Infra.Helpers.Logger.Instance.RegisterObserver(new TextLogger());
            Customers.Infra.Helpers.Logger.Instance.RegisterObserver(new CloudLogger());
            Customers.Infra.Helpers.Logger.Instance.RegisterObserver(new XmlLogger());
            Customers.Infra.Helpers.Logger.Instance.RegisterObserver(new LiteDatabaseLogger(loggerContext));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DP_Example", Version = "v1" });
            });

            

            ////var section = Configuration.GetSection("Logging.LogLevel");
            //services.Configure<Logging>(Configuration);
            //var section = Configuration.GetSection("Logging").Get<Logging>();
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddSingleton<ILiteDBContext, LiteDBContext>();
            services.AddSingleton<ILoggerDBContext>(loggerContext);
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ISupportRepository, SupportRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
