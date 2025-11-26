using NUnit.Framework;
using OpenQA.Selenium;
using System.Linq;
using Kpi_Lab5.Utils;

namespace Kpi_Lab5.Tests
{
    public class HoverTests : BaseTest
    {
        [Test]
        public void Hover_ShouldRevealCaption()
        {
            var p = new Pages.HoverPage(driver);
            p.Open();

            var figs = p.Figures();
            Assert.GreaterOrEqual(figs.Count, 1);

            var first = figs.First();
            p.HoverOver(first);

            var caption = first.FindElement(By.CssSelector(".figcaption"));
            Assert.IsTrue(caption.Displayed);
            Assert.IsNotEmpty(caption.Text);
        }
    }
}
