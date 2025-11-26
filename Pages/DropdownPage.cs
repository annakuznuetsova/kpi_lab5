using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace Kpi_Lab5.Pages
{
    public class DropdownPage
    {
        private readonly IWebDriver _driver;
        private readonly By _select = By.Id("dropdown");

        public DropdownPage(IWebDriver driver) { _driver = driver; }
        public void Open() => _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dropdown");

        public IList<IWebElement> Options()
        {
            var s = new SelectElement(_driver.FindElement(_select));
            return s.Options;
        }

        public void SelectByText(string text)
        {
            new SelectElement(_driver.FindElement(_select)).SelectByText(text);
        }

        public string SelectedValue()
        {
            return new SelectElement(_driver.FindElement(_select)).SelectedOption.Text;
        }

        public void SelectByValue(string value)
        {
            new SelectElement(_driver.FindElement(_select)).SelectByValue(value);
        }

        public void SelectByIndex(int index)
        {
            new SelectElement(_driver.FindElement(_select)).SelectByIndex(index);
        }
    }
}
