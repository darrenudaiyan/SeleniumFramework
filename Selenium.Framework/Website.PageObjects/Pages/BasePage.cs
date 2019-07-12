using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Website.PageObjects
{
    /// <summary>
    /// BasePage base page where other pages inherit from 
    /// </summary>
    public class BasePage
    {
        private readonly IWebDriver webDriver;
        
        private IWebElement Title => webDriver.FindElement(By.Id("Title"));
        
        public BasePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        //properties
        public string TitleText { get { return Title.GetAttribute("innerText"); } }
    }
}
