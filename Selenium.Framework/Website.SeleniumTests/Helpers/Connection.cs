using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;
using Website.PageObjects.Helpers;

namespace Website.SeleniumTests
{
    public static class Connection
    {
        public static PODriverOptions driverOptions;

        static Connection()
        {
            var appConfig = new ConfigurationBuilder()
                .SetBasePath((Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
                .AddJsonFile("appsettings.json")
                .Build();
            driverOptions = new PODriverOptions(appConfig.GetSection("URL").Value,
                                                appConfig.GetSection("BrowserType").Value,
                                                appConfig.GetSection("Headless").Value);
        }
    }
}
