using Core.Attributes;
using Core.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MailService.Mine
{
    [Service(Contract = typeof(ILoggingService))]
    public class MyTextLogger : ILoggingService
    {
        public string Name => "MyTextLogger";

        public void Log(string message)
        {
            var executableLocation = Assembly.GetEntryAssembly().Location;
            var path = Path.Combine(Path.GetDirectoryName(executableLocation), "MyTextLogs.txt");

            File.WriteAllLines(path, new List<string> { message });
        }
    }
}
