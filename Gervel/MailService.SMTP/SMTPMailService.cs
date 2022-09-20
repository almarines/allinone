﻿using Core.Attributes;
using Core.Contracts;
using System;
using System.Composition;

[assembly: AutoGenerate]
namespace MailService.SMTP
{
    [Service(Contract = typeof(IMailService))]
    public class SMTPMailService : IMailService
    {
        public string Name => "SMTPMailService";

        public string SendMail(string sender, string receiver, string subject, string body)
        {
            // SMTP Object/ TCP ip protocol


            return "From SMTP Mail Service";
        }
    }
}