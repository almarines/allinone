using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Options
{
    public class DbConfig
    {
        public string PathToDB { get; set; }

        public Logging Logging { get; set; }
    }
    public class Logging
    {
        public LogLevel LogLevel { get; set; }
    }

    public class LogLevel
    {
        public string Default { get; set; }

        public string Microsoft { get; set; }
    }
}
