using OpenQA.Selenium;
using System.Collections.Generic;

namespace Kpi_Lab5.Pages
{
    public class StatusCodesPage
    {
        private readonly IWebDriver _driver;
        private readonly By _links = By.CssSelector(".example a");

        public StatusCodesPage(IWebDriver driver) { _driver = driver; }
        public void Open() => _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/status_codes");

        public IList<IWebElement> GetLinks() => _driver.FindElements(_links);

        public string ClickAndGetBodyText(IWebElement link)
        {
            link.Click();
            return _driver.FindElement(By.CssSelector(".example p")).Text;
        }
    }
}
