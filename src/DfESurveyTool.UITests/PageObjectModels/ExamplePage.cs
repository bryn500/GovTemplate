using OpenQA.Selenium;

namespace DfESurveyTool.UITests.PageObjectModels
{
    public class ExamplePage
    {
        private readonly IWebDriver _driver;
        public readonly By SearchInput = By.ClassName("js-search-input");
        public readonly By SearchSubmit = By.ClassName("js-search-submit");
        public readonly By SearchResults = By.ClassName("js-search-results");

        public ExamplePage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public void EnterSearch(string value)
        {
            IWebElement element = _driver.FindElement(SearchInput);
            element.Clear();
            element.SendKeys(value);
        }

        public void SubmitSearch()
        {
            _driver.FindElement(SearchSubmit).Click();
        }

        public By GetDirectory(string directoryName)
        {
            return By.XPath("//button[@class='govuk-accordion__section-button' and contains(text(), '" + directoryName + "')]");
        }

        public void ExpandDirectory(string directoryName)
        {
            var directoryHeading = GetDirectory(directoryName);
            _driver.FindElement(directoryHeading).Click();
        }
    }
}
