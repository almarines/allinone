
using Core.Attributes;
using Core.Contracts;
using System;
using System.Composition;

[assembly: AutoGenerate]
namespace MailService.AzureEmailService
{
    [Service(Contract = typeof(IMailServce))]
    public class AzureEmailService : IMailServce
    {
        public string Name => "AzureEmailService";

        public string SendMail(string sender, string receiver, string subject, string body)
        {

            return "From Azure EMail Service";
        }
    }
}