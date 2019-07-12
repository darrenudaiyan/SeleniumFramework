using OpenQA.Selenium;
using Website.PageObjects.Controls;

namespace Website.PageObjects
{
    /// <summary>
    /// Step2 page Object
    /// </summary>
    public class Step2 : BasePage
    {
        private readonly IWebDriver webDriver;
        private readonly string PageName = "/step2.html";

        private IWebElement LinkStep3 => webDriver.FindElement(By.Id("LinkStep3"));
        private IWebElement MLOptions => webDriver.FindElement(By.Id("MLOptions"));
        private IWebElement SelectedProtein => webDriver.FindElement(By.Id("SelectedProtein"));
        private IWebElement SelectedML => webDriver.FindElement(By.Id("SelectedML"));
        private readonly DropDown dropDown;

        public Step2(IWebDriver webDriver) : base(webDriver)
        {
            this.webDriver = webDriver;
            PODriver.GotoURL(webDriver, PageName);
            dropDown = new DropDown(MLOptions,webDriver);
        }
        
        //properties
        public string LinkStep3text { get { return LinkStep3.GetAttribute("innerText"); } }
        public string SelectedProteinText { get { return SelectedProtein.GetAttribute("innerText"); } }
        public string SelectedMLText { get { return SelectedML.GetAttribute("innerText"); } }
        public DropDown DropDown { get { return dropDown; } }

        //methods
        public Step3 ClickLinkStep3()
        {
            LinkStep3.Click();
            return new Step3(webDriver);
        }

        public Step2 SelectDropDownByText(string byText)
        {
            dropDown.ChangeDropDownValue(byText);
            return this;
        }

    }
}
