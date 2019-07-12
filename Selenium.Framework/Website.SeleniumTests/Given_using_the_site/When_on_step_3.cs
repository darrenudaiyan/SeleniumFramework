using NUnit.Framework;
using System;
using Website.PageObjects;
using Website.SeleniumTests.Helpers;

namespace Website.SeleniumTests.Given_using_the_site
{
    [TestFixture]
    public class When_on_step_3
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
                            .Step3
                            .TitleText, Is.EqualTo("Udaiyan Protein Predictor - Wizard 3"));
        }

        [Test]
        public void Navigation_to_Step_1_should_work()
        {
            Assert.That(webSite
                            .Step3
                            .ClickLinkStep1()
                            .TitleText, Is.EqualTo("Udaiyan Protein Predictor - Wizard 1"));
        }

        [Test]
        public void The_selected_protein_should_be_correct()
        {
            //arrange
            var selectedProtein = "Protein Sample 3";

            //act
            var Step3 = webSite
                         .Index
                         .SelectDropDownByText(selectedProtein)
                         .ClickLinkStep2()
                         .ClickLinkStep3();

            //assert
            Assert.That(Step3.SelectedProteinText, Is.EqualTo(selectedProtein));
        }

        [Test]
        public void The_selected_ml_should_be_correct()
        {
            //arrange
            var selectedML = "A3C";

            //act
            var Step3 = webSite
                         .Index
                         .ClickLinkStep2()
                         .SelectDropDownByText(selectedML)
                         .ClickLinkStep3();

            //assert
            Assert.That(Step3.SelectedMLText, Is.EqualTo(selectedML));
        }

        [Test]
        public void The_selected_protein_and_ml_should_be_correct()
        {
            //arrange
            var selectedProtein = "Protein Sample 2";
            var selectedML = "A3C";

            //act
            var step3 = webSite
                         .Index
                         .SelectDropDownByText(selectedProtein)
                         .ClickLinkStep2()
                         .SelectDropDownByText(selectedML)
                         .ClickLinkStep3();

            //assert
            Assert.That(step3.SelectedProteinText, Is.EqualTo(selectedProtein));
            Assert.That(step3.SelectedMLText, Is.EqualTo(selectedML));
        }

        [Test]
        public void There_should_be_4_columns_in_the_protein_data_table()
        {
            var proteinData = webSite.Step3.GetproteinData();
            Assert.That(proteinData[1].Count, Is.EqualTo(4));
        }

        [Test]
        public void There_should_be_13_rows_in_the_protein_data_table()
        {
            var proteinData = webSite.Step3.GetproteinData();
            Assert.That(proteinData.Count, Is.EqualTo(13));
        }

        [TestCaseSource("MolWeightTests")]
        public void The_mol_weight_should_be_correct_within_tolerance(string selectedProtein, string selectedML, double expectedValue, double tolerance)
        {
            var proteinData = webSite
                                .Index
                                .SelectDropDownByText(selectedProtein)
                                .ClickLinkStep2()
                                .SelectDropDownByText(selectedML)
                                .ClickLinkStep3()
                                .GetproteinData();
            Assert.That(Convert.ToDouble(proteinData[4][1]), Is.EqualTo(expectedValue).Within(tolerance));
        }

        public static object[] MolWeightTests()
        {
            return TestData.MolWeightTests();
        }

        [TestCaseSource("ProteinLengthTests")]
        public void The_protein_length_should_be_correct_within_tolerance(string selectedProtein, string selectedML, double expectedValue, double tolerance)
        {
            var proteinData = webSite
                                .Index
                                .SelectDropDownByText(selectedProtein)
                                .ClickLinkStep2()
                                .SelectDropDownByText(selectedML)
                                .ClickLinkStep3()
                                .GetproteinData();
            Assert.That(Convert.ToDouble(proteinData[4][2]), Is.EqualTo(expectedValue).Within(tolerance));
        }

        public static object[] ProteinLengthTests()
        {
            return TestData.ProteinLengthTests();
        }

    }
}
