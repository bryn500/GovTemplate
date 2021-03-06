using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Edge;
using Microsoft.Edge.SeleniumTools;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace DfESurveyTool.UITests
{
    public class BaseTest
    {
        /// <summary>
        /// Config for variables
        /// </summary>
        public IConfiguration Config { get; set; }

        /// <summary>
        /// Url used for testing - set locally or through env variable
        /// </summary>
        public string AppURL { get; set; }

        /// <summary>
        /// The driver used to control the browser
        /// </summary>
        public IWebDriver Driver { get; set; }

        /// <summary>
        /// List of browsers for tests to use
        /// Firefox and IE are currently quite slow
        /// </summary>
        public static object[] TestBrowsers
        {
            get => new[]
            {
                new object[] {"Chrome"},
                // edge fails currently, although was fine for previous project
                //new object[] {"Edge"},
                // these others are very slow...
                new object[] {"Firefox"},
                new object[] {"IE"}
            };
        }

        /// <summary>
        /// Set up config
        /// </summary>
        public BaseTest()
        {
            Config = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddEnvironmentVariables()
               .Build();

            AppURL = Config["TEST_HOST"];
        }

        /// <summary>
        /// Creates driver based on browser
        /// </summary>
        /// <param name="browser"></param>
        public void CreateDriver(string browser)
        {
            switch (browser)
            {
                case "Chrome":
                    Driver = new ChromeDriver(new ChromeOptions()
                    {
                    });
                    break;
                case "Firefox":
                    Driver = new FirefoxDriver(new FirefoxOptions
                    {
                        AcceptInsecureCertificates = true
                    });
                    break;
                case "IE":
                    Driver = new InternetExplorerDriver(new InternetExplorerOptions
                    {
                        IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                        IgnoreZoomLevel = true
                    });
                    Driver.Manage().Window.Maximize();
                    break;
                case "Edge":
                    Driver = new EdgeDriver(new EdgeOptions()
                    {
                        UseChromium = false
                    });
                    break;
                default:
                    Driver = new ChromeDriver(new ChromeOptions()
                    {
                    });
                    break;
            }

            // Navigate to app
            Driver.Navigate().GoToUrl(AppURL);
        }

        /// <summary>
        /// Called before every test
        /// </summary>
        [TestInitialize()]
        public void BaseTestInitialize()
        {
            // call test initialize, which can get overridden in each test case class
            TestInitialize();
        }

        /// <summary>
        /// Called after every test
        /// </summary>
        [TestCleanup()]
        public void BaseTestCleanup()
        {
            // call test cleanup, which can get overridden in each test case class
            TestCleanup();

            // universal cleanup: close & quit driver
            Driver.Close();
            Driver.Quit();
        }

        protected virtual void TestInitialize()
        {
            // override this method in your test class & write initialize steps
        }

        protected virtual void TestCleanup()
        {
            // override this method in your test class & write additional cleanup steps
        }
    }
}
