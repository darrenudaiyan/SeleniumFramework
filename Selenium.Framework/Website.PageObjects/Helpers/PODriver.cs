using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;

namespace Website.PageObjects
{
    /// <summary>
    /// PODriver Class to drive Chome, Edge etc...
    /// </summary>
    public static class PODriver
    {
        public static string BaseUrl;

        /// <summary>
        /// GotoURL navigates to a page and waits for it to open
        /// </summary>
        public static void GotoURL(IWebDriver webDriver, string PageName)
        {
            webDriver.Navigate().GoToUrl(BaseUrl + PageName);
            var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 30));
            var element = wait.Until(o => webDriver.FindElement(By.Id("Title")));
        }

        /// <summary>
        /// InitialiseWebDriver returns webdriver for chrome, edge etc...
        /// </summary>
        public static IWebDriver InitialiseWebDriver(Helpers.PODriverOptions driverOptions)
        {
            IWebDriver webDriver;
            BaseUrl = driverOptions.URL;
            var driverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            switch (driverOptions.BrowserType)
            {
                case "Chrome":
                    if (driverOptions.HeadlessMode.ToLower() == "true")
                    {
                        var chromeOptions = new ChromeOptions();
                        chromeOptions.AddArgument("no-sandbox");
                        chromeOptions.AddArgument("headless");
                        webDriver = new ChromeDriver(driverPath, chromeOptions);
                    }
                    else
                    {
                        webDriver = new ChromeDriver(driverPath);
                    }
                    break;
                case "Edge":
                    webDriver = new EdgeDriver(driverPath);
                    break;
                default:
                    webDriver = new ChromeDriver(driverPath);
                    break;
            }

            return webDriver;
        }

    }
}
