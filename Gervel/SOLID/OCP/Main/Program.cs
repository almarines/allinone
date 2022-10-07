using Core;
using Core.Contracts;
using System;

namespace main
{
    class Program
    {
        static void Main(string[] args)
        {
            var resolver = new Resolver();
            resolver.Resolve();

            //Container.AddSingelten(typeof(ILoggingService), new TextLogger.TextLogger());
            //Container.AddSingelten(typeof(IMailService), new SMTPMailService.SMTPMailService());

            var mailService = Container.Resolve<IMailService>();
            mailService.SendMail("finance@xyz.com", "Welcome", "Welcome To xyz");

            //var logService = Container.Resolve<ILoggingService>();
            //logService.Log("before sending mail");

            // How to access SMTPMail / AWS Service
            // IMailServce: Register Email Service [SMTP/AWS/ Azure]
            // var mailService = Container.Resolve<IMailService>();
            // mailService.SendMail("welcome@danaher.com", "Welcome", "Welcome to danaher");

            //logService.Log("after sending mail");

            Console.ReadLine();
        }
    }
}
