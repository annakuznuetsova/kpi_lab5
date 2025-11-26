using NUnit.Framework;
using Kpi_Lab5.Pages;

namespace Kpi_Lab5.Tests
{
    public class CheckboxesTests : BaseTest
    {
        [Test]
        public void ToggleAllCheckboxes()
        {
            var page = new CheckboxesPage(driver);
            page.Open();

            var boxes = page.GetCheckboxes();
            Assert.That(boxes.Count, Is.EqualTo(2), "Очікується 2 чекбокси.");

            for (int i = 0; i < boxes.Count; i++)
            {
                var before = page.IsChecked(i);
                page.Toggle(i);
                Assert.That(page.IsChecked(i), Is.Not.EqualTo(before), $"Чекбокс {i} не змінив стан.");
            }
        }
    }
}
