using Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BasicMocks
{
    public class Training
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Cost { get; set; }
    }

    public interface ITrainingData
    {

        Task<bool> Add(string name, string cost);

        Task<bool> Update(int id, string name);

        Task<bool> Delete(int id);
        Task<IEnumerable<Training>> GetAllTrainings();
    }

    public class TrainingDataContext : ITrainingData
    {
        private static IList<Training> list = new List<Training>();

        public TrainingDataContext()
        {
            list.Add(new Training() { Id = 1, Name = ". Net Core", Cost = "100$" });
        }
        public async Task<bool> Add(string name, string cost)
        {
            list.Add(new Training() { Id = list.Count + 1, Name = name, Cost = cost });
            return await Task.FromResult(true);
        }

        public async Task<bool> Delete(int id)
        {
            list.Remove(list.First(s => s.Id == id));
            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<Training>> GetAllTrainings()
        {
            return await Task.FromResult(list);
        }

        public async Task<bool> Update(int id, string name)
        {
            return await Task.FromResult(true);
        }
    }

    public class SMTPMailService : IMailService
    {
        public string Name => "SMTPMailService";

        public async Task<bool> SendMail(string sender, string target, string subject, string body)
        {
            try
            {
                SmtpClient client = new SmtpClient();
                client.Host = "<host>";
                client.Port = int.MaxValue;

                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("<username>", "<password>");

                MailMessage message = CreateMailMessage(sender, subject, body);
                client.Send(message);
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private MailMessage CreateMailMessage(string to, string subject, string body)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("<registered mail id>");
            mailMessage.To.Add(to);
            mailMessage.Body = body;
            mailMessage.Subject = subject;
            return mailMessage;
        }
    }

    public class NamingService : INamingService
    {
        public bool Validate(string identifier)
        {
            if (string.IsNullOrEmpty(identifier))
            {
                return false;
            }          

            return true;
        }
    }
}
