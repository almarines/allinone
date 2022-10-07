using Core;
using DatabaseCore;
using Microsoft.Extensions.DependencyInjection;

namespace DatabaseCore.Extensions {
	public static class DatabaseCoreExtensions {
		public static void RegisterDatabase(this IServiceCollection services) {
			services.AddDbContext<EmployeeDBContext>();
			services.AddScoped<IEmployeeRepository, EmployeeRepository>();
		}
	}
}
