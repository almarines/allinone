using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMTPMailService
{
    public interface IMailService
    {
        bool IsValid(string value);
        Task<bool> SendMail(string to, string subject, string body);
    }
}
