using Core;
using Microsoft.Extensions.DependencyInjection;

namespace MailService.Extensions {
	public static class MailServiceExtension {
		public static void RegisterMailService(this IServiceCollection services) {
			services.AddScoped<IMailService, SMTPMailService>();
		}
	}
}
