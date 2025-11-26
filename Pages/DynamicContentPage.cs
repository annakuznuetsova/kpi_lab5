using OpenQA.Selenium;
using System.Collections.Generic;

namespace Kpi_Lab5.Pages
{
    public class DynamicContentPage
    {
        private readonly IWebDriver _driver;
        private readonly By _contentBlocks = By.CssSelector("#content.row");

        public DynamicContentPage(IWebDriver driver) { _driver = driver; }
        public void Open() => _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_content");

        public IList<IWebElement> Blocks() => _driver.FindElements(_contentBlocks);
    }
}
