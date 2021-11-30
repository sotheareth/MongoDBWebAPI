using OpenQA.Selenium;
using System;
using Xunit;
using Xunit.Abstractions;

namespace MongoDBWebAPI.SeleniumGridTest
{
    public class BugMessageHandler : TestMessageSink
    {
        private readonly IRunnerLogger logger;
        private readonly IWebDriver webDriver;

        public BugMessageHandler(IRunnerLogger logger, IWebDriver webDriver)
        {
            this.logger = logger;
            this.webDriver = webDriver;

            Execution.TestFailedEvent += HandleTestFailed;
            Execution.TestPassedEvent += HandleTestPassed;
        }

        protected virtual void HandleTestFailed(MessageHandlerArgs<ITestFailed> args)
        {
            var testFailed = args.Message;
            logger.LogImportantMessage("testFailed");

            if (testFailed.Messages?.Length > 0)
            {
                int index = testFailed.Messages[0].LastIndexOf("Expected");
                var bytes = Convert.FromBase64String(testFailed.Messages[0].Substring(0, index-1));

                MyJiraClient.AddIssue(testFailed, bytes);
            }

        }

        protected virtual void HandleTestPassed(MessageHandlerArgs<ITestPassed> args)
        {
            var testPassed = args.Message;

            Console.WriteLine(testPassed.ToString());
        }

    }
}
