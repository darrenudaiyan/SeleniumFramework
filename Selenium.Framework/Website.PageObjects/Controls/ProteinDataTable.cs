using OpenQA.Selenium;
using System.Collections.Generic;

namespace Website.PageObjects.Controls
{
    /// <summary>
    /// proteinDataTable object model
    /// </summary>
    public class ProteinDataTable
    {
        private readonly IWebElement _table;

        public ProteinDataTable(IWebElement table)
        {
            _table = table;
        }

        /// <summary>
        /// GetTableContents method to extract table data and return a list<list<string>></string>
        /// </summary>
        public List<List<string>> GetTableContents()
        {
            var data = new List<List<string>>();
            List<IWebElement> allRows = new List<IWebElement>(_table.FindElements(By.TagName("tr")));
            foreach (var Row in allRows)
            {
                List<IWebElement> cells = new List<IWebElement>(Row.FindElements(By.TagName("td")));
                var cellList = new List<string>();
                foreach (var cell in cells)
                {
                    cellList.Add(cell.Text);
                }

                data.Add(cellList);
            }
            return data;
        }
    }
}
