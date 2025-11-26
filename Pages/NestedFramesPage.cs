using OpenQA.Selenium;

namespace Kpi_Lab5.Pages
{
    public class NestedFramesPage
    {
        private IWebDriver _driver;
        public NestedFramesPage(IWebDriver driver) { _driver = driver; }
        public void Open() => _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/nested_frames");

        public string GetFrameBodyText(string[] pathToFrame)
        {
            _driver.SwitchTo().DefaultContent();
            foreach (var p in pathToFrame)
            {
                if (int.TryParse(p, out int idx))
                {
                    _driver.SwitchTo().Frame(idx);
                }
                else
                {
                    _driver.SwitchTo().Frame(p);
                }
            }
            var text = _driver.FindElement(By.TagName("body")).Text;
            _driver.SwitchTo().DefaultContent();
            return text;
        }
    }
}
