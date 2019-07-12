using NUnit.Framework;
using Website.PageObjects;

namespace Website.SeleniumTests.Given_using_the_site
{
    [TestFixture]
    public class When_on_step_2
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
                            .Step2
                            .TitleText, Is.EqualTo("Udaiyan Protein Predictor - Wizard 2"));
        }

        [Test]
        public void The_selected_protein_should_be_correct()
        {
            //arrange
            var selectedProtein = "Protein Sample 2";

            //act
            var step2 = webSite
                         .Index
                         .SelectDropDownByText(selectedProtein)
                         .ClickLinkStep2();
             
            //assert
            Assert.That(step2.SelectedProteinText, Is.EqualTo(selectedProtein));
        }

        [Test]
        public void Navigation_to_Step_3_should_work()
        {
            Assert.That(webSite
                            .Index
                            .ClickLinkStep2()
                            .ClickLinkStep3()
                            .TitleText, Is.EqualTo("Udaiyan Protein Predictor - Wizard 3"));
        }

        [Test]
        public void Changing_the_ml_selector_should_work()
        {
            //arrange + act
            string expectedValue = "PCA";
            string selectText = "Principal Component Analysis";
            var step2 = webSite.Step2.SelectDropDownByText(expectedValue);

            //assert
            Assert.That(step2.SelectedMLText, Is.EqualTo("Selected: " + expectedValue));
        }

        [Test]
        public void Changing_the_ml_selector_twice_should_work()
        {
            //arrange
            string firstValue = "PCA";
            string expectedValue = "SVM";
            var step2 = webSite.Step2.SelectDropDownByText(firstValue);

            //act
            step2.DropDown.ChangeDropDownValue(expectedValue);

            //assert
            Assert.That(step2.SelectedMLText, Is.EqualTo("Selected: " + expectedValue));
        }

    }
}
