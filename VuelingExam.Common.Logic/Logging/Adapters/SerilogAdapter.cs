using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuelingExam.Common.Logic.Logging.Adapters
{
    public class SerilogAdapter : Interfaces.ILogger
    {

        private static readonly string logPath = "serilog_log.txt";

        public string Message { get; set; }

        public SerilogAdapter()
        {
            Log.Logger = new LoggerConfiguration()
                    .WriteTo.File(logPath,
                        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                        .MinimumLevel.Verbose()
                    .CreateLogger();
        }

        public void Info(string message)
        {
            Log.Information(message);
        }

        public void Warn(string message)
        {
            Log.Warning(message);
        }

        public void Debug(string message)
        {
            Log.Debug(message);
        }

        public void Error(string message)
        {
            Log.Error(message);
        }

    }
}
