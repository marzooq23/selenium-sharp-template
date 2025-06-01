namespace SeleniumSharpTemplate.Utilities.Reports.Extent.Logger;

public static class ExtentLogger
{
    public static void LogScreenshot(this ExtentTest extentTest , string info, string image) =>
        extentTest.Info(info, MediaEntityBuilder.CreateScreenCaptureFromBase64String(image).Build());
}
