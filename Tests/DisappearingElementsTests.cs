using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Kpi_Lab5.Tests
{
    public class DisappearingElementsTests : BaseTest
    {
        [Test]
        public void DisappearingElements_CollectStats()
        {
            var p = new Pages.DisappearingElementsPage(driver);
            var counts = new Dictionary<string, int>();
            p.Open();

            for (int i = 0; i < 10; i++)
            {
                var items = p.MenuItems().Select(e => e.Text).ToList();
                foreach (var t in items)
                {
                    if (!counts.ContainsKey(t)) counts[t] = 0;
                    counts[t]++;
                }
                driver.Navigate().Refresh();
            }

            Assert.GreaterOrEqual(counts.Count, 1);
        }
    }
}
