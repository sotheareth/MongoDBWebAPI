using AutoFixture.Xunit2;
using MongoDBWebAPI.SeleniumTest.DTO.Requests;
using MongoDBWebAPI.SeleniumTest.Helpers;
using OpenQA.Selenium;
using System;
using Xunit;
using Xunit.Abstractions;

namespace MongoDBWebAPI.SeleniumTest
{
    public class SeleniumWithContext : IClassFixture<WebDriverFixture>
    {
        private readonly ITestOutputHelper testOutputHelper;
        private readonly WebDriverFixture webDriverFixture;

        public SeleniumWithContext(WebDriverFixture webDriverFixture, ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
            this.webDriverFixture = webDriverFixture;
        }

        //[Fact]
        //public void Test1()
        //{
        //    Console.WriteLine("First test");
        //    testOutputHelper.WriteLine("First test");

        //    webDriverFixture.ChromeDriver.Navigate().GoToUrl("www.google.com");

        //}

        [Theory]
        [InlineData("test@yahoo.com", "123456")]
        public void FillData(string userName, string password)
        {
            var driver = webDriverFixture.ChromeDriver;
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
            Assert.False(errorElement.Text.CompareTo("Invalid password. Please try again") == 0);

        }

        [Theory, AutoData]
        public void FillAutoData(Credential credential)
        {
            var driver = webDriverFixture.ChromeDriver;
            driver
                .Navigate()
                .GoToUrl("https://login.yahoo.com/");

            var emailElement = driver.FindElement(By.Id("login-username"));

            credential.Email = "test@yahoo.com";
            emailElement.SendKeys(credential.Email);

            driver.FindElement(By.Id("login-signin")).Click();

            var name = driver.FindWaitElement(By.Id("login-passwd"));
            name.SendKeys(credential.Password);

            driver.FindWaitElement(By.Id("login-signin")).Click();

            var errorElement = driver.FindWaitElement(By.ClassName("error-msg"));
            Assert.True(errorElement.Text.CompareTo("Invalid password. Please try again") == 0);

        }


    }
}

