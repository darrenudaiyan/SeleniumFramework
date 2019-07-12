using NUnit.Framework;
using Website.PageObjects;

namespace Website.SeleniumTests.Given_using_the_site
{
    [TestFixture]
    public class When_testing_performance
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

        [Test, MaxTime(20000)]
        public void Clicking_regenerate_100_times_should_take_less_than_20_seconds()
        {
            //arrange
            var selectedProtein = "Protein Sample 1";
            var selectedML = "SVM";
            var step3 = webSite
                         .Index
                         .SelectDropDownByText(selectedProtein)
                         .ClickLinkStep2()
                         .SelectDropDownByText(selectedML)
                         .ClickLinkStep3();

            //act
            for (int i = 0; i < 100; i++)
            {
                step3.ClickRegenerate();
            }
        }
    }
}
