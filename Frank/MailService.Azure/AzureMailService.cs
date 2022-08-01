using Core.Attributes;
using Core.Contracts;
using System;
using System.Composition;

[assembly: AutoGenerate]
namespace MailService.SMTP
{
    [Service(Contract = typeof(IMailServce))]
    public class AzureMailService : IMailServce
    {
        public string Name => "AzureMailService";

        public string SendMail(string sender, string receiver, string subject, string body)
        {
            return "From Azure Mail Service";
        }
    }
}
