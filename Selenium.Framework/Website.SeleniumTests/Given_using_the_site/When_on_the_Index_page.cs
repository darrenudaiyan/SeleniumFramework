using NUnit.Framework;
using Website.PageObjects;

namespace Website.SeleniumTests.Given_using_the_site
{
    [TestFixture]
    public class When_on_the_Index_page
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

        [Test]
        public void The_title_should_be_correct()
        {
            Assert.That(webSite
                            .Index
                            .TitleText, Is.EqualTo("Udaiyan Protein Predictor - Wizard 1"));
        }

        [Test]
        public void Navigation_to_Step_2_should_work()
        {
            Assert.That(webSite
                            .Index
                            .ClickLinkStep2()
                            .TitleText, Is.EqualTo("Udaiyan Protein Predictor - Wizard 2"));
        }

        [Test]
        public void Changing_the_protein_selector_should_work()
        {
            //arrange + act
            string expectedValue = "Protein Sample 2";
            var indexPage = webSite.Index.SelectDropDownByText(expectedValue);

            //assert
            Assert.That(indexPage.SelectedProteinText, Is.EqualTo("Selected: " + expectedValue));
        }

        [Test]
        public void Changing_the_protein_selector_twice_should_work()
        {
            //arrange
            string firstValue = "Protein Sample 2";
            string expectedValue = "Protein Sample 3";
            var indexPage = webSite.Index.SelectDropDownByText(firstValue);

            //act
            indexPage.DropDown.ChangeDropDownValue(expectedValue);

            //assert
            Assert.That(indexPage.SelectedProteinText, Is.EqualTo("Selected: " + expectedValue));
        }

    }
}
