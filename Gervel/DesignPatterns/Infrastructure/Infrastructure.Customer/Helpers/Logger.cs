using System;
using System.Collections.Generic;
using System.IO;

namespace Infrastructure.Customer.Helpers {
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
            File.WriteAllLines("C:\\Source\\Workspace\\Training\\Logs\\log.txt", new List<string> { message });
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
