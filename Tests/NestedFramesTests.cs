using NUnit.Framework;

namespace Kpi_Lab5.Tests
{
    public class NestedFramesTests : BaseTest
    {
        [Test]
        public void ReadTextFromNestedFrames()
        {
            var p = new Pages.NestedFramesPage(driver);
            p.Open();

            var leftText = p.GetFrameBodyText(new[] { "frame-top", "frame-left" });
            Assert.IsNotEmpty(leftText);

            var middleText = p.GetFrameBodyText(new[] { "frame-top", "frame-middle" });
            Assert.IsNotEmpty(middleText);

            var bottomText = p.GetFrameBodyText(new[] { "frame-bottom" });
            Assert.IsNotEmpty(bottomText);
        }
    }
}
