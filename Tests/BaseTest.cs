using System;
using Kpi_Lab5.Utils;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Kpi_Lab5.Tests
{
    public abstract class BaseTest
    {
        protected IWebDriver driver;
        protected bool KeepBrowserOpenForDebug = false;

        [SetUp]
        public void BaseSetUp()
        {
            driver = Driver.GetDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }

        [TearDown]
        public void BaseTearDown()
        {
            try
            {
                var result = TestContext.CurrentContext.Result.Outcome.Status;

                var screenshotPathAlways = Utils.ScreenshotHelper.SaveScreenshot(driver, $"{TestContext.CurrentContext.Test.Name}_end");
                if (!string.IsNullOrEmpty(screenshotPathAlways))
                {
                    TestContext.AddTestAttachment(screenshotPathAlways, "Final screenshot");
                    Console.WriteLine("Saved final screenshot: " + screenshotPathAlways);
                }

                if (result == NUnit.Framework.Interfaces.TestStatus.Failed ||
                    result == NUnit.Framework.Interfaces.TestStatus.Inconclusive)
                {
                    var path = Utils.ScreenshotHelper.SaveScreenshot(driver, $"{TestContext.CurrentContext.Test.Name}_FAIL");
                    if (!string.IsNullOrEmpty(path))
                    {
                        TestContext.AddTestAttachment(path, "Failure screenshot");
                        Console.WriteLine("Saved failure screenshot: " + path);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Screenshot in TearDown failed: " + ex);
            }
            finally
            {
                if (driver != null)
                {
                    try
                    {
                        try { driver.Quit(); } catch {}
                        try { driver.Dispose(); } catch {}
                    }
                    catch
                    {
                    }
                    finally
                    {
                        driver = null!;
                    }
                }

                Driver.QuitDriver();

                if (KeepBrowserOpenForDebug)
                {
                    Console.WriteLine("KeepBrowserOpenForDebug = true, so browser left open for manual inspection.");
                }
            }
        }
    }
}
