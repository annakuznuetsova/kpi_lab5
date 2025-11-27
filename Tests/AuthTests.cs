using NUnit.Framework;

namespace Kpi_Lab5.Tests
{
    public class AuthTests : BaseTest
    {
        [Test]
        public void Auth_InvalidAndValid()
        {
            var p = new Pages.AuthPage(driver);
            p.Open();

            p.Login("wrong", "wrong");
            Assert.IsTrue(p.FlashText().ToLower().Contains("invalid"), "Очікується помилка при неправильних даних.");

            p.Login("firstnamelastname", "Super_Secret_Password!");
            Assert.IsTrue(p.FlashText().ToLower().Contains("secure area") || driver.Url.Contains("/secure"), "Після логіну очікується успіх.");

            p.Logout();
            Assert.IsTrue(p.FlashText().ToLower().Contains("logged out") || driver.Url.Contains("/login"));
        }
    }
}
