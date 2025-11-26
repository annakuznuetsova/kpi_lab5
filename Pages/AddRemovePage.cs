using System.Collections.Generic;
using OpenQA.Selenium;

namespace Kpi_Lab5.Pages
{
    public class AddRemovePage
    {
        private readonly IWebDriver _driver;
        private readonly By _addButton = By.XPath("//button[text()='Add Element']");
        private readonly By _deleteButtons = By.CssSelector(".added-manually");

        public AddRemovePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Open() => _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/add_remove_elements/");

        public void ClickAdd() => _driver.FindElement(_addButton).Click();

        public IReadOnlyList<IWebElement> GetDeleteButtons() => _driver.FindElements(_deleteButtons);

        public void ClickDelete(int index)
        {
            GetDeleteButtons()[index].Click();
        }
    }
}
