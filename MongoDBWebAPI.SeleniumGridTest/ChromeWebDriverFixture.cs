using System;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;

namespace MongoDBWebAPI.SeleniumGridTest
{
    public class ChromeWebDriverFixture : IDisposable
    {
        private bool disposedValue;

        public IWebDriver Driver { get; private set; }

        public ChromeWebDriverFixture()
        {
            var hubUrl = "http://localhost:4446/";
            Driver = LocalDriverFactory.CreateInstance(BrowserType.Chrome, hubUrl);
        }

        public void SetImplicitWait()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Driver.Quit();
                    Driver.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

    }
}
