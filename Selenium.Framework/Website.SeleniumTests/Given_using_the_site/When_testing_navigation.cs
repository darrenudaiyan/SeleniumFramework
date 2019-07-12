using NUnit.Framework;
using Website.PageObjects;
using Website.SeleniumTests.Helpers;

namespace Website.SeleniumTests.Given_using_the_site
{
    [TestFixture]
    public class When_testing_navigation
    {
        private WebSite webSite;

        [SetUp]
        public void Setup()
        {
            webSite = new WebSite(Connection.driverOptions);
        }

        [TearDown]
        public void TearDown()
        {
            webSite.Quit();
        }

        [TestCaseSource("NavigationTests")]
        public void Navigation_Works(string pageName, string expectedTitle)
        {
            var page = webSite.GotoPage(pageName);
            Assert.That(page.TitleText, Is.EqualTo(expectedTitle));
        }

        public static object[] NavigationTests()
        {
            return TestData.NavigationTests();
        }
    }
}
