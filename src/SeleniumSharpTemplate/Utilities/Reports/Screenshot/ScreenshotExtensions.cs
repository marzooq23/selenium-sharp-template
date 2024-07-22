﻿namespace SeleniumSharpTemplate.Utilities.Reports.Screenshot
{
    public static class ScreenshotExtensions
    {
        public static string CaptureScreenshot(this IWebDriver Driver, string? FileName = null, string? FilePath = null)
        {
            string imagePath = string.Empty;

            try
            {
                var screenShot = Driver.TakeScreenshot();
                string screenShotFileName = $"{FileName ?? Contexts.GetStepText}_{Guid.NewGuid()}.png";
                imagePath = Path.Combine(
                    FilePath! ?? PathFinder.ScenarioTitleScreenshots,
                    screenShotFileName);
                screenShot.SaveAsFile(imagePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return imagePath;
        }
    }
}