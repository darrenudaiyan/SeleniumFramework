
namespace Website.PageObjects.Helpers
{
    /// <summary>
    /// PODriverOptions - class to hold driver options
    /// </summary>
    public class PODriverOptions
    {
        public string URL { get; private set; }
        public string BrowserType { get; private set; }
        public string HeadlessMode { get; private set; }

        public PODriverOptions(string url, string browser, string headless)
        {
            URL = url;
            BrowserType = browser;
            HeadlessMode = headless;
        }
    }
}
