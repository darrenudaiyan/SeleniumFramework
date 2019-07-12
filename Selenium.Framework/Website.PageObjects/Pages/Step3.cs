using OpenQA.Selenium;
using System.Collections.Generic;
using Website.PageObjects.Controls;

namespace Website.PageObjects
{
    /// <summary>
    /// Step3 page Object
    /// </summary>
    public class Step3 : BasePage
    {
        private readonly IWebDriver webDriver;
        private readonly string PageName = "/step3.html";

        private IWebElement LinkStep1 => webDriver.FindElement(By.Id("LinkStep1"));
        private IWebElement SelectedProtein => webDriver.FindElement(By.Id("SelectedProtein"));
        private IWebElement SelectedML => webDriver.FindElement(By.Id("SelectedML"));
        private IWebElement ProteinSizerData => webDriver.FindElement(By.Id("ProteinSizerData"));
        private IWebElement Regenerate => webDriver.FindElement(By.Id("Regenerate"));

        private readonly ProteinDataTable proteinDataTable;

        public Step3(IWebDriver webDriver) : base(webDriver)
        {
            this.webDriver = webDriver;
            PODriver.GotoURL(webDriver, PageName);
            proteinDataTable = new ProteinDataTable(ProteinSizerData);
        }

        //properties
        public string LinkStep1text { get { return LinkStep1.GetAttribute("innerText"); } }
        public string SelectedProteinText { get { return SelectedProtein.GetAttribute("innerText"); } }
        public string SelectedMLText { get { return SelectedML.GetAttribute("innerText"); } }
        public ProteinDataTable ProteinDataTable { get { return proteinDataTable; } }

        //methods
        public Index ClickLinkStep1()
        {
            LinkStep1.Click();
            return new Index(webDriver);
        }

        public Step3 ClickRegenerate()
        {
            Regenerate.Click();
            return this;
        }

        public List<List<string>> GetproteinData()
        {
            return ProteinDataTable.GetTableContents();
        }
    }
}
