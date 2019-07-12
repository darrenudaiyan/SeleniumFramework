using NUnit.Framework;
using System;
using Website.PageObjects;
using Website.PageObjects.Helpers;
using Moq;

namespace Website.PageObjectsTests
{
    [TestFixture]
    public class PageObjectTests
    {
        [Test]
        public void Website_with_empty_url_should_return_correct_error()
        {
            //arrange
            var driverOptions = new Mock<PODriverOptions>("","Chrome","False");

            //act
            var ex = Assert.Throws<ArgumentNullException>(() => new WebSite(driverOptions.Object));

            //assert
            Assert.That(ex.Message.Contains(ErrorStrings.URL_is_Null));
        }
        
    }
}
