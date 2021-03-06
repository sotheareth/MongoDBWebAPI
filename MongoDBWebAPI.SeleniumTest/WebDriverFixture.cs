using System;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace MongoDBWebAPI.SeleniumGridTest
{
    public class WebDriverFixture : IDisposable
    {
        private bool disposedValue;
        public ChromeDriver ChromeDriver { get; private set; }

        public WebDriverFixture()
        {
            //var driver = new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            this.ChromeDriver = new ChromeDriver();
        }

        public void SetImplicitWait()
        {
            ChromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    ChromeDriver.Quit();
                    ChromeDriver.Dispose();
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
