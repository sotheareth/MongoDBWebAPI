using AutoFixture.Xunit2;
using MongoDBWebAPI.SeleniumGridTest.DTO.Requests;
using MongoDBWebAPI.SeleniumGridTest.Helpers;
using OpenQA.Selenium;
using System;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace MongoDBWebAPI.SeleniumGridTest
{
    public class SeleniumWithContext : IClassFixture<ChromeWebDriverFixture>
    {
        private readonly ChromeWebDriverFixture webDriverFixture;
        private readonly ITestOutputHelper testOutputHelper;

        public SeleniumWithContext(ChromeWebDriverFixture webDriverFixture, ITestOutputHelper testOutputHelper)
        {
            this.webDriverFixture = webDriverFixture;
            this.testOutputHelper = testOutputHelper;
        }

        [Theory]
        [InlineData("ham8086sotheareth@yahoo.com", "123456")]
        public void FillData(string userName, string password)
        {
            try
            {
                var driver = webDriverFixture.Driver;
                driver
                    .Navigate()
                    .GoToUrl("https://login.yahoo.com/");


                var emailElement = driver.FindElement(By.Id("login-username"));
                emailElement.SendKeys(userName);

                driver.FindElement(By.Id("login-signin")).Click();

                var name = driver.FindWaitElement(By.Id("login-passwd"));
                name.SendKeys(password);

                driver.FindWaitElement(By.Id("login-signin")).Click();

                var errorElement = driver.FindWaitElement(By.ClassName("error-msg"));

                Assert.True(errorElement.Text.CompareTo("Invalid password. Please try again") == 0);
            }
            catch (Exception ex)
            {
                var bytes = webDriverFixture.Driver.TakeScreenshot().AsBase64EncodedString;
                Assert.False(ex != null, bytes);
            }

        }

        [Theory, AutoData]
        public void FillAutoData(Credential credential)
        {
            var driver = webDriverFixture.Driver;
            try
            {                
                driver
                    .Navigate()
                    .GoToUrl("https://login.yahoo.com/");

                var emailElement = driver.FindElement(By.Id("login-username"));

                credential.Email = "ham8086sotheareth@yahoo.com";
                emailElement.SendKeys(credential.Email);

                driver.FindElement(By.Id("login-signin")).Click();

                var image64encode = driver.TakeScreenshot().AsBase64EncodedString;
                testOutputHelper.WriteLine(image64encode);
                var name = driver.FindWaitElement(By.Id("login-passwd"));
                name.SendKeys(credential.Password);

                driver.FindWaitElement(By.Id("login-signin")).Click();

                image64encode = driver.TakeScreenshot().AsBase64EncodedString;
                testOutputHelper.WriteLine(image64encode);
                var errorElement = driver.FindWaitElement(By.ClassName("error-msg"));
                
                Assert.True(errorElement.Text.CompareTo("Invalid password. Please try again2") == 0, image64encode);
            }
            catch
            {
                var image64encode = driver.TakeScreenshot().AsBase64EncodedString;
                testOutputHelper.WriteLine(image64encode);
            }
        }        

    }
}

