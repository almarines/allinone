namespace Core.Contracts
{
    public interface IMailService : IService
    {
        string SendMail(string sender, string target, string subject, string body);
    }
}
