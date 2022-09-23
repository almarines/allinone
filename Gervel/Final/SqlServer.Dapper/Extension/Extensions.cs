using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DataBaseCore.DBContext;

namespace DataBaseCore.Extensions
{
    public static class Extensions
    {
        public static void RegisterDatabase(this IServiceCollection services, string connectionstring)
        {
            services.AddSingleton<EmployeeDBDapperContext>();
        }
    }
}
