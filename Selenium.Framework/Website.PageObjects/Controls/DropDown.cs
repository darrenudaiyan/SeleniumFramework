using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Website.PageObjects.Controls
{
    /// <summary>
    /// Dropdown control object model
    /// </summary>
    public class DropDown
    {
        private readonly IWebDriver _webDriver;
        private readonly IWebElement _options;

        public DropDown(IWebElement options, IWebDriver webDriver)
        {
            _options = options;
            _webDriver = webDriver;
        }

        /// <summary>
        /// ChangeDropDownValue - changes the dropdown
        /// </summary>
        public void ChangeDropDownValue(string byText)
        {
            var selectElement = new SelectElement(_options);
            var wait = new WebDriverWait(_webDriver, new TimeSpan(0, 0, 30));
            var element = wait.Until(o => _webDriver.FindElement(By.Id(_options.GetAttribute("id"))));
            selectElement.SelectByValue(byText);
        }
    }
}
