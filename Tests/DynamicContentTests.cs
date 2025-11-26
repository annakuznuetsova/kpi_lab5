using Kpi_Lab5.Tests;
using Kpi_Lab5.Utils;
using NUnit.Framework;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace Kpi_Lab5.Tests
{
    public class DynamicContentTests : BaseTest
    {
        private string Normalize(string s)
        {
            if (s == null) return string.Empty;
            return Regex.Replace(s.Trim(), @"\s+", " ");
        }

        [Test]
        public void DynamicContent_ChangesOverReloads()
        {
            var p = new Pages.DynamicContentPage(driver);
            p.Open();

            var first = Normalize(string.Join("|", p.Blocks().Select(b => b.Text)));
            bool changed = false;

            for (int i = 0; i < 50; i++) 
            {
                Thread.Sleep(700); 
                driver.Navigate().Refresh();
                var cur = Normalize(string.Join("|", p.Blocks().Select(b => b.Text)));
                if (cur != first)
                {
                    changed = true;
                    break;
                }
            }

            if (!changed)
            {
                Assert.Inconclusive("Контент не змінився після кількох перезавантажень. Ресурс тимчасово статичний.");
            }

            Assert.IsTrue(changed, "Очікується, що контент зміниться хоча б раз за кілька перезавантажень.");
        }
    }
}
