using Core.Attributes;
using Core.Contracts;

[assembly: AutoGenerate]
namespace MailService.Azure {

	[Service(Contract = typeof(IMailServce))]
	public class AzureMailService : IMailServce {
		public string Name => "AzureMailService";

		public string SendMail(string sender, string receiver, string subject, string body) {
			return "From Azure Mail Service";
		}
	}
}