﻿using OpenQA.Selenium.Support.UI;

namespace Automation.Tests.Pages;

public class BasePage(IWebDriver driver)
{
    public readonly IWebDriver driver =
        driver ?? throw new ArgumentNullException(nameof(driver));

    public void WaitUntilTitleContains(string title)
    {
        WebDriverWait webDriverWait = new(driver, TimeSpan.FromSeconds(10));
        webDriverWait.Until(ExpectedConditions.TitleContains(title));
    }

    public void GoToUrl(string url)
    {
        try
        {
            driver.Navigate().GoToUrl(url);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void GoToUrl(Uri url)
    {
        try
        {
            driver.Navigate().GoToUrl(url);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public string CaptureScreenshot(string FileName, string? FilePath = null)
    {
        return driver.CaptureScreenshot(FileName, FilePath!);
    }
}