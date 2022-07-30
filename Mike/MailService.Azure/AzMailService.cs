using Core.Attributes;
using Core.Contracts;

[assembly: AutoGenerate]
namespace MailService.Azure {
  [Service(Contract = typeof(IMailServce))]
  public class AzMailService: IMailServce {
    public string Name => "AzMailService";

    public string SendMail(string sender, string receiver, string subject, string body) {
      // AWS .net SDS


      return "From AZ Service";
    }
  }
}
