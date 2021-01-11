using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DfESurveyTool.UITests
{
    [TestClass]
    public class HomeTest : BaseTest
    {
        public static object[] Browsers { get { return TestBrowsers; } }

        [TestMethod]
        [DynamicData("Browsers")]
        public void SearchTest(string browser)
        {
            CreateDriver(browser);

            Assert.IsTrue(true);
        }
    }
}
