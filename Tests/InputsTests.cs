using Kpi_Lab5.Tests;
using Kpi_Lab5.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace Kpi_Lab5.Tests
{
    public class InputsTests : BaseTest
    {
        [Test]
        public void Inputs_NumberAndArrows()
        {
            var p = new Pages.InputsPage(driver);
            p.Open();

            var el = WaitHelpers.WaitForElementVisible(driver, By.TagName("input"), 5);

            p.SetValue("5");
            Thread.Sleep(200); 
            Assert.That(p.GetValue(), Is.EqualTo("5"), "Після SetValue('5') очікуємо '5'.");

            p.SendArrowUp();
            Thread.Sleep(100);
            var afterArrow = p.GetValue(); 
            Assert.IsNotNull(afterArrow, "Після ArrowUp значення не повинно бути null.");

            p.SetValue("abc");
            Thread.Sleep(100);
            var afterAlpha = p.GetValue();
            Assert.IsNotNull(afterAlpha, "GetValue() має повертати рядок (можливо порожній).");
        }
    }
}
