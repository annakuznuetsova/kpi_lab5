using NUnit.Framework;

namespace Kpi_Lab5.Tests
{
    public class DropdownTests : BaseTest
    {
        [Test]
        public void Dropdown_SelectOptions()
        {
            var p = new Pages.DropdownPage(driver);
            p.Open();

            var opts = p.Options();
            Assert.GreaterOrEqual(opts.Count, 2);

            p.SelectByText("Option 1");
            Assert.That(p.SelectedValue(), Is.EqualTo("Option 1"));

            p.SelectByValue("2");
            Assert.That(p.SelectedValue(), Is.EqualTo("Option 2"));

            p.SelectByIndex(1);
            Assert.IsNotNull(p.SelectedValue());
        }
    }
}
