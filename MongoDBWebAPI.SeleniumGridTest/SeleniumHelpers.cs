using OpenQA.Selenium;
using System;

namespace MongoDBWebAPI.SeleniumGridTest
{
    internal static class SeleniumHelpers
    {
        public static Screenshot TakeScreenshot(this IWebDriver driver)
        {
            var screenshotDriver = (driver as ITakesScreenshot);

            if (screenshotDriver == null)
                throw new InvalidOperationException(
                    $"The driver type '{driver.GetType().FullName}' does not support taking screenshots.");

            return screenshotDriver.GetScreenshot();
        }

    }
}
