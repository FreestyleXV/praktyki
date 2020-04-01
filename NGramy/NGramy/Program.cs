using System;
using NGramy.BL;
using log4net;
using log4net.Config;
using System.IO;
using System.Reflection;

namespace NGramy.App
{
    public class Program
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

            log.Info("Aplikacja wystartowała");
            Sterowanie.Menu();
        }
    }
}