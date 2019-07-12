
namespace Website.SeleniumTests.Helpers
{
    public static class TestData
    {
        public static object[] NavigationTests()
        {
            object[] TestCases =
            {
                new object[]  { "/index.html", "Udaiyan Protein Predictor - Wizard 1" },
                new object[] { "/Step2.html", "Udaiyan Protein Predictor - Wizard 2"},
                new object[] { "/Step3.html", "Udaiyan Protein Predictor - Wizard 3"},
            };
            return TestCases;
        }

        public static object[] MolWeightTests()
        {
            object[] TestCases =
            {
                new object[]  { "Protein Sample 2", "Naive Bayes", 64, 0.5},
                new object[] { "Protein Sample 3", "PCA", 64, 1},
                new object[] { "Protein Sample 1", "SVM", 64, 5},
                new object[] { "Protein Sample 2", "A3C", 64, 1},
            };
            return TestCases;
        }

        public static object[] ProteinLengthTests()
        {
            object[] TestCases =
            {
                new object[]  { "Protein Sample 2", "Naive Bayes", 595, 0.5},
                new object[] { "Protein Sample 3", "PCA", 595, 1},
                new object[] { "Protein Sample 1", "SVM", 595, 5},
                new object[] { "Protein Sample 2", "A3C", 595, 1},
            };
            return TestCases;
        }
    }
}
