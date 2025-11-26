using Kpi_Lab5.Tests;
using Kpi_Lab5.Utils;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Kpi_Lab5.Tests
{
    public class StatusCodesTests : BaseTest
    {
        [Test]
        public void StatusPages_ShowStatusText()
        {
            var p = new Pages.StatusCodesPage(driver);
            p.Open();

            var links = p.GetLinks();
            Assert.GreaterOrEqual(links.Count, 1);

            foreach (var l in links)
            {
                var href = l.GetAttribute("href") ?? "";
                l.Click();

                var bodyText = driver.FindElement(By.TagName("body")).Text;
                Assert.IsTrue(bodyText.ToLower().Contains("this page returned") || bodyText.Contains("Status"),
                    $"Очікується текст про код статусу на сторінці {href}. Текст сторінки: {bodyText.Substring(0, Math.Min(200, bodyText.Length))}");

                driver.Navigate().Back();
            }
        }
    }
}
