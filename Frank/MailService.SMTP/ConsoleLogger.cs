﻿using Core.Attributes;
using Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailService.SMTP
{
    [Service(Contract = typeof(ILoggingService))]
    public class ConsoleLogger : ILoggingService
    {
        public string Name => nameof(ConsoleLogger);

        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
