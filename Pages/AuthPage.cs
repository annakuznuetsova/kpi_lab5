using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;
using System;

namespace Kpi_Lab5.Pages
{
    public class AuthPage
    {
        private readonly IWebDriver _driver;
        private readonly By _user = By.Id("username");
        private readonly By _pass = By.Id("password");
        private readonly By _login = By.CssSelector("button[type='submit']");
        private readonly By _flash = By.Id("flash");

        public AuthPage(IWebDriver driver) { _driver = driver; }
        public void Open() => _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");

        public void Login(string u, string p)
        {
            _driver.FindElement(_user).Clear();
            _driver.FindElement(_user).SendKeys(u);
            _driver.FindElement(_pass).Clear();
            _driver.FindElement(_pass).SendKeys(p);
            _driver.FindElement(_login).Click();
        }

        public string FlashText()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(_flash));

            int attempts = 0;
            while (attempts < 3)
            {
                try
                {
                    var el = _driver.FindElement(_flash);
                    return el.Text;
                }
                catch (StaleElementReferenceException)
                {
                    attempts++;
                    System.Threading.Thread.Sleep(150);
                }
            }

            try
            {
                return _driver.FindElement(By.TagName("body")).Text;
            }
            catch
            {
                return string.Empty;
            }
        }

        public void Logout()
        {
            _driver.FindElement(By.CssSelector("a.button")).Click();
        }
    }
}
