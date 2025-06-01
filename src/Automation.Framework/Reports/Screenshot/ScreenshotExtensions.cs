using Automation.Framework.Exceptions;
using OpenQA.Selenium.Support.Extensions;

namespace Automation.Framework.Reports.Screenshot;

public static class ScreenshotExtensions
{
    public static string CaptureScreenshot(this IWebDriver Driver, string FileName, string FilePath)
    {
        string imagePath = string.Empty;

        try
        {
            var screenShot = Driver.TakeScreenshot();
            string screenShotFileName = $"{FileName}_{Guid.NewGuid()}.png";
            imagePath = Path.Combine(
                FilePath,
                screenShotFileName);
            screenShot.SaveAsFile(imagePath);
        }
        catch (Exception e)
        {
            Logger.Error($"{Messages.SCREENSHOT_EX_MESSAGE}\n{e.Message}\n");
        }

        return imagePath;
    }

    public static string ConvertImageToBase64(this string imagePath)
    {
        byte[] imageBytes = File.ReadAllBytes(imagePath);

        if (imageBytes == null || imageBytes.Length == 0)
        {
            throw new InvalidOperationException("Image file is empty or could not be read.");
        }

        return Convert.ToBase64String(imageBytes);
    }
}