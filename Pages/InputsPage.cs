using OpenQA.Selenium;

namespace Kpi_Lab5.Pages
{
    public class InputsPage
    {
        private readonly IWebDriver _driver;
        private readonly By _input = By.TagName("input");

        public InputsPage(IWebDriver driver) { _driver = driver; }
        public void Open() => _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/inputs");

        public void SetValue(string value)
        {
            var el = _driver.FindElement(_input);
            el.Clear();
            el.SendKeys(value);
        }

        public string GetValue()
        {
            return _driver.FindElement(_input).GetAttribute("value")!;
        }

        public void SendArrowUp()
        {
            _driver.FindElement(_input).SendKeys(Keys.ArrowUp);
        }

        public void SendArrowDown()
        {
            _driver.FindElement(_input).SendKeys(Keys.ArrowDown);
        }
    }
}
