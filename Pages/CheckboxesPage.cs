using System.Collections.Generic;
using OpenQA.Selenium;

namespace Kpi_Lab5.Pages
{
    public class CheckboxesPage
    {
        private readonly IWebDriver _driver;
        private readonly By _checkboxes = By.CssSelector("#checkboxes input[type='checkbox']");

        public CheckboxesPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IReadOnlyList<IWebElement> GetCheckboxes() => _driver.FindElements(_checkboxes);

        public bool IsChecked(int index)
        {
            return GetCheckboxes()[index].Selected;
        }

        public void Toggle(int index)
        {
            var box = GetCheckboxes()[index];
            box.Click();
        }

        public void Open() => _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/checkboxes");
    }
}
