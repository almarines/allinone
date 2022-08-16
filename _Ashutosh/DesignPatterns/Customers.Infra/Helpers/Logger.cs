using Customers.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customers.Infra.Helpers
{
    public interface ILogger
    {
        void LogInfo(string message);
    }


    public class ConsoleLogger : ILogger
    {
        public void LogInfo(string message)
        {
            Console.WriteLine(message);
        }

    }

    public class TextLogger : ILogger
    {
        public void LogInfo(string message)
        {
            File.WriteAllLines("C:\\_Ashutosh\\Trainings\\log.txt", new List<string> { message });
        }

    }


    public class CloudLogger : ILogger
    {
        public void LogInfo(string message)
        {
            // log into cloud using cloud services
        }
    }

    public class XmlLogger : ILogger
    {
        public void LogInfo(string message)
        {
            // log into Ftp
        }
    }

    public class LiteDatabaseLogger : ILogger
    {
        private readonly LoggerDBContext _loggerDBContext;

        public LiteDatabaseLogger(LoggerDBContext loggerDBContext)
        {
            _loggerDBContext = loggerDBContext;
        }

        public void LogInfo(string message)
        {
            _loggerDBContext.InsertLog(new LogEntity() { Message = message, Type = LogType.Info });
        }
    }

    public class Logger
    {
        private static Logger instance;
        private static object lockObj = new object();

        public static Logger Instance
        {
            get
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new Logger();
                    }

                    return instance;
                }
            }
        }

        private static readonly IDictionary<Type, ILogger> observers = new Dictionary<Type, ILogger>();

        public void RegisterObserver(ILogger instance) => observers[instance.GetType()] = instance;

        public void Log(string message)
        {
            foreach (var item in observers.Values)
            {
                item.LogInfo(message);
            }
        }
    }
}
