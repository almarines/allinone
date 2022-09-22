using Core.Contracts;

namespace Core.Extensions {
    public static class MailServiceExtension
    {
        public static void SendMailWithLogging(this IMailService mailService)
        {
            var result = mailService.SendMail("X", "Y", "", "");

            var loggingService = Container.Resolve<ILoggingService>();
            loggingService.Log("mail sent " + result);
        }
    }
}
