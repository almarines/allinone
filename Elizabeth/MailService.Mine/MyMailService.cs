using Core.Attributes;
using Core.Contracts;
using System;
using System.Composition;

[assembly : AutoGenerate]
namespace MailService.Mine
{
    [Service(Contract = typeof(IMailServce))]
    public class MyMailService : IMailServce
    {
        public string Name => "MyMailService";

        public string SendMail(string sender, string receiver, string subject, string body)
        {
            return "From My Mail Service";
        }
    }
}
