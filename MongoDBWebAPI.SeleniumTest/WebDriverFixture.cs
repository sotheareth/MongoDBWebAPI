using System;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace MongoDBWebAPI.SeleniumTest
{
    public class WebDriverFixture : IDisposable
    {
        public ChromeDriver ChromeDriver { get; private set; }

        public WebDriverFixture()
        {
            var driver = new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            this.ChromeDriver = new ChromeDriver();
        }

        public void SetImplicitWait()
        {
            ChromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public void Dispose()
        {
            ChromeDriver.Quit();
            ChromeDriver.Dispose();
        }
    }
}
