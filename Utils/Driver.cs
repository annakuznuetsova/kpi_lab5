using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Kpi_Lab5.Utils
{
    public static class Driver
    {
        private static IWebDriver? _driver;

        public static IWebDriver GetDriver()
        {
            if (_driver != null) return _driver;

            try
            {
                var options = new ChromeOptions();
                options.AddArgument("--start-maximized");

                _driver = new ChromeDriver(options);
                return _driver;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Не вдалось ініціалізувати ChromeDriver.", ex);
            }
        }

        public static void QuitDriver()
        {
            try
            {
                if (_driver != null)
                {
                    _driver.Quit();
                    _driver.Dispose();
                    _driver = null;
                }
            }
            catch
            {
                _driver = null;
            }
        }
    }
}
