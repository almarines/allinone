using Core.Attributes;
using Core.Contracts;
using System.Threading.Tasks;

[assembly: AutoGenerate]
namespace MailService.AWS.SES {
    [Service(Contract = typeof(IMailService))]
    public class SESMailService : IMailService
    {
        public string Name =>  "SESMailService";

        public async Task<bool> SendMail(string sender, string receiver, string subject, string body)
        {
			return await Task.FromResult(true);
		}
    }
}
