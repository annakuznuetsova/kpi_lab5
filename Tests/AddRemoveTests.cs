using NUnit.Framework;
using Kpi_Lab5.Pages;

namespace Kpi_Lab5.Tests
{
    public class AddRemoveTests : BaseTest
    {
        [Test]
        public void AddAndRemoveElements()
        {
            var page = new AddRemovePage(driver);
            page.Open();

            for (int i = 0; i < 5; i++) page.ClickAdd();
            Assert.That(page.GetDeleteButtons().Count, Is.EqualTo(5), "Повинно бути 5 Delete кнопок.");

            page.ClickDelete(1);
            Assert.That(page.GetDeleteButtons().Count, Is.EqualTo(4), "Після видалення має бути 4 кнопки.");
        }
    }
}
