﻿using OpenQA.Selenium.Support.Extensions;
using SeleniumSharpTemplate.Utilities.Exceptions;

namespace SeleniumSharpTemplate.Utilities.Reports.Screenshot
{
    public static class ScreenshotExtensions
    {
        public static string CaptureScreenshot(this IWebDriver Driver, string FileName, string? FilePath = null)
        {
            string imagePath = string.Empty;

            try
            {
                var screenShot = Driver.TakeScreenshot();
                string screenShotFileName = $"{FileName}_{Guid.NewGuid()}.png";
                imagePath = Path.Combine(
                    FilePath! ?? PathFinder.ScenarioTitleScreenshots,
                    screenShotFileName);
                screenShot.SaveAsFile(imagePath);
            }
            catch (Exception e)
            {
                Logger.Error($"{Messages.SCREENSHOT_EX_MESSAGE}\n{e.Message}\n");
            }

            return imagePath;
        }
    }
}