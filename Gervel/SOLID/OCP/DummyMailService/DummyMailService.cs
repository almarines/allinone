using Core;
using Core.Attributes;
using Core.Contracts;
using System;
using System.Threading.Tasks;

[assembly: AutoGenerate]
namespace DummyMailService {
	[Service(Contract = typeof(IMailService))]
	public class SMTPMailService : IMailService {
		private readonly ILoggingService logger;

		public string Name => "Dummy Mail Service";

		public SMTPMailService() {
			logger = Container.Resolve<ILoggingService>();
		}

		public Task<bool> SendMail(string to, string subject, string body) {
			try {
				logger.Log($"Sending dummy email: \n\t[To]${to}, \n\t[Subject]${subject}, \n\t[Buddy]{body}");

				return Task.FromResult(true);
			} catch (Exception ex) {
				Console.WriteLine(ex.Message);
				return Task.FromResult(false);
			}
		}
	}
}