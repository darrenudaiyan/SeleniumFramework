using OpenQA.Selenium;
using Website.PageObjects.Controls;

namespace Website.PageObjects
{
    /// <summary>
    /// Index page Object
    /// </summary>
    public class Index : BasePage
    {
        private readonly IWebDriver webDriver;
        private readonly string PageName = "/index.html";

        private IWebElement LinkStep2 => webDriver.FindElement(By.Id("LinkStep2"));
        private IWebElement ProteinOptions => webDriver.FindElement(By.Id("ProteinOptions"));
        private IWebElement SelectedProtein => webDriver.FindElement(By.Id("SelectedProtein"));

        private readonly DropDown dropDown;
        
        public Index(IWebDriver webDriver) : base(webDriver)
        {
            this.webDriver = webDriver;
            PODriver.GotoURL(webDriver, PageName);
            dropDown = new DropDown(ProteinOptions, webDriver);
        }

        //properties
        public string LinkStep2Text { get { return LinkStep2.GetAttribute("innerText"); } }
        public string SelectedProteinText { get { return SelectedProtein.GetAttribute("innerText"); } }
        public DropDown DropDown { get { return dropDown; } }

        //methods
        public Step2 ClickLinkStep2()
        {
            LinkStep2.Click();
            return new Step2(webDriver);
        }

        public Index SelectDropDownByText(string byText)
        {
            dropDown.ChangeDropDownValue(byText);
            return this;
        }
    }
}
