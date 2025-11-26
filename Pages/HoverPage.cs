using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;

namespace Kpi_Lab5.Pages
{
    public class HoverPage
    {
        private readonly IWebDriver _driver;
        private readonly By _figures = By.CssSelector(".figure");
        public HoverPage(IWebDriver driver) { _driver = driver; }
        public void Open() => _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/hovers");

        public IList<IWebElement> Figures() => _driver.FindElements(_figures);

        public void HoverOver(IWebElement el)
        {
            new Actions(_driver).MoveToElement(el).Perform();
        }
    }
}
