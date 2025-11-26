using NUnit.Framework;
using OpenQA.Selenium;
using Kpi_Lab5.Utils;

namespace Kpi_Lab5.Tests
{
    public abstract class BaseTest
    {
        protected IWebDriver driver;

        [SetUp]
        public void BaseSetUp()
        {
            driver = Driver.GetDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }

        [TearDown]
        public void BaseTearDown()
        {
            if (driver != null)
            {
                try
                {
                    driver.Quit();
                    driver.Dispose();
                }
                catch { }
                driver = null!;
            }
            Driver.QuitDriver(); 
        }
    }
}
