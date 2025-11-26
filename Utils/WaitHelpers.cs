using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Kpi_Lab5.Utils
{
    public static class WaitHelpers
    {
        public static IWebElement WaitForElementVisible(IWebDriver driver, By locator, int seconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public static bool WaitForElementNotPresent(IWebDriver driver, By locator, int seconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            return wait.Until(d =>
            {
                try
                {
                    return d.FindElements(locator).Count == 0;
                }
                catch { return false; }
            });
        }
    }
}
