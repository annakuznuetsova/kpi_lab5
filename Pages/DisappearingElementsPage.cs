using OpenQA.Selenium;
using System.Collections.Generic;

namespace Kpi_Lab5.Pages
{
    public class DisappearingElementsPage
    {
        private readonly IWebDriver _driver;
        private readonly By _menuItems = By.CssSelector(".example ul li a");

        public DisappearingElementsPage(IWebDriver driver) { _driver = driver; }
        public void Open() => _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/disappearing_elements");

        public IList<IWebElement> MenuItems() => _driver.FindElements(_menuItems);
    }
}
