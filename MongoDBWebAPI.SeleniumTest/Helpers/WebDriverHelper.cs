using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace MongoDBWebAPI.SeleniumGridTest.Helpers
{
    public static class WebDriverHelper
    {
        public static IWebElement FindWaitElement(this WebDriver driver, By by)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.PollingInterval = TimeSpan.FromSeconds(5);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.Message = "Element is not found";

            try
            {
                var elementToBeDisplayed = driver.FindElement(by);
                if (elementToBeDisplayed.Displayed)
                {
                    return elementToBeDisplayed;
                }
                return null;
            }
            catch (StaleElementReferenceException)
            {
                return null;
            }
            catch (TimeoutException)
            {
                return null;
            }

            //return wait.Until<IWebElement>(ExpectedConditions.ElementExists(by));
        }
    }
}
