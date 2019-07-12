using OpenQA.Selenium;
using System;
using System.IO;
using System.Reflection;
using Website.PageObjects.Helpers;
using PODriverOptions = Website.PageObjects.Helpers.PODriverOptions;

namespace Website.PageObjects
{
    /// <summary>
    /// Main website page object to open the other page objects
    /// </summary>
    public class WebSite
    {
        private readonly IWebDriver webDriver;

        public WebSite(PODriverOptions driverOptions)
        {
            CheckParams(driverOptions.URL);
            webDriver = PODriver.InitialiseWebDriver(driverOptions);
        }

        //properties
        public Index Index { get { return new Index(webDriver); } }
        public Step2 Step2 { get { return new Step2(webDriver); } }
        public Step3 Step3 { get { return new Step3(webDriver); } }
        
        //methods
        public BasePage GotoPage(string pageName)
        {
            PODriver.GotoURL(webDriver, pageName);
            return new BasePage(webDriver);
        }

        public void Quit() => webDriver.Quit();

        private void CheckParams(string URL)
        {
            if (string.IsNullOrEmpty(URL))
            {
                throw new ArgumentNullException(nameof(URL), ErrorStrings.URL_is_Null);
            }
        }
    }
}
