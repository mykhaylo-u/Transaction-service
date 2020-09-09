using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;

namespace transaction_service.web.Logger
{
    public static class Logger
    {

        private static readonly string LOG_CONFIG_FILE = @"log4net.config";

        private static readonly ILog Log = GetLogger(typeof(Logger));

        public static ILog GetLogger(Type type)
        {
            return LogManager.GetLogger(type);
        }

        public static void Debug(object message)
        {
            ConfigureLog4Net();
            Log.Debug(message);
        }

        private static void ConfigureLog4Net()
        {
            XmlDocument log4NetConfig = new XmlDocument();
            log4NetConfig.Load(File.OpenRead(LOG_CONFIG_FILE));

            var repo = LogManager.CreateRepository(
                Assembly.GetEntryAssembly(), repositoryType: typeof(log4net.Repository.Hierarchy.Hierarchy));

            log4net.Config.XmlConfigurator.Configure(repo, log4NetConfig["log4net"]);
        }
    }
}
