using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace Kpi_Lab5.Utils
{
    public static class ScreenshotHelper
    {
        public static string SaveScreenshot(IWebDriver driver, string namePrefix = "screenshot")
        {
            try
            {
                var takes = driver as ITakesScreenshot;
                if (takes == null) return null!;

                var ss = takes.GetScreenshot();
                var dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports", "Screenshots");
                Directory.CreateDirectory(dir);

                var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss_fff");
                var fileName = $"{namePrefix}_{timestamp}.png";
                var path = Path.Combine(dir, fileName);

                ss.SaveAsFile(path);
                return path;
            }
            catch
            {
                return null!;
            }
        }
    }
}
