using Core.Attributes;
using Core.Contracts;
using System;
using System.Composition;

[assembly: AutoGenerate]
namespace MailService.Azure
{
    [Service(Contract = typeof(IMailServce))]
    public class AzureMailService : IMailServce
    {
        public string Name => "SESMailService";

        public string SendMail(string sender, string receiver, string subject, string body)
        {
            // AWS .net SDS


            return "From AWS SES Service";
        }
    }
}
