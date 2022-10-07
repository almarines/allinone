using Core;
using LiteDbServer.DBContext;
using Microsoft.Extensions.DependencyInjection;

namespace LiteDbServer.Extensions
{
    public static class Extensions
    {
        public static void RegisterDatabase(this IServiceCollection services)
        {
            services.AddSingleton<LiteDBContext>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        }
    }
}
