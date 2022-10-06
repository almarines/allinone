using System;
using System.Linq;
using System.Threading.Tasks;

namespace SMTPMailServiceLib
{
    public interface IMailService
    {
        bool IsValid(string value);
        Task<bool> SendMail(string to, string subject, string body);
    }
}
