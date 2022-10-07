using Core;
using Microsoft.Extensions.DependencyInjection;

namespace DatabaseCore.Extensions {
	public static class DatabaseCoreExtensions {
		public static void RegisterDatabase(this IServiceCollection services) {
			services.AddSingleton<EmployeeDBContext>();
			services.AddScoped<IEmployeeRepository, EmployeeRepository>();
		}
	}
}
