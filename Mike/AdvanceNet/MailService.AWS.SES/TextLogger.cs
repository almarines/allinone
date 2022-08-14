﻿using Core.Attributes;
using Core.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MailService.AWS.SES
{
    [Service(Contract = typeof(ILoggingService))]
    public class TextLogger : ILoggingService
    {
        public string Name => "TextLogger";

        public void Log(string message)
        {
            var executableLocation = Assembly.GetEntryAssembly().Location;
            var path = Path.Combine(Path.GetDirectoryName(executableLocation), "WriteLines.txt");

            File.WriteAllLines(path, new List<string> { message });
        }
    }
}
