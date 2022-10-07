using Core;
using MailService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailService.Extensions {
	public static class SMTPMailServiceExtensions {
		public static void RegisterMailService(this IServiceCollection services) {
			services.AddScoped<IMailService, SMTPMailService>();
		}
	}
}
