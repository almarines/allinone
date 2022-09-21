﻿using Amazon;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using Core.Contracts;
using MimeKit;
using System;
using System.IO;
using System.Threading.Tasks;

namespace AWS.SES
{
    public class AWSSESMailService : IMailService
    {
        public async Task<bool> SendMail(string to, string subject, string body)
        {
            try
            {
                var emailMessage = BuildEmailHeaders(to, subject);
                var emailBody = new BodyBuilder() { TextBody = body };
                emailMessage.Body = emailBody.ToMessageBody();

                using var memoryStream = new MemoryStream();
                await emailMessage.WriteToAsync(memoryStream);

                var sendRequest = new SendRawEmailRequest { RawMessage = new RawMessage(memoryStream) };
                await Send(sendRequest);
                return true;
            }
            catch (Exception)
            {
                return false;
            }           
        }

        private async Task Send(SendRawEmailRequest sendRequest)
        {
            var endpoint = RegionEndpoint.GetBySystemName("us-east-2");
            var aws = new AmazonSimpleEmailServiceClient("<access key>", "<secret>", endpoint);

            var response = await aws.SendRawEmailAsync(sendRequest);
            Console.WriteLine($"The email with message Id {response.MessageId} sent successfully on {DateTime.UtcNow:O}");
        }

        private MimeMessage BuildEmailHeaders(string to, string subject)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Test System", "<register mail id>"));

            message.To.Add(new MailboxAddress("Test System", to));
            message.Subject = subject;
            return message;
        }
    }
}
