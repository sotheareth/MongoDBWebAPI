using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace MongoDBWebAPI.SeleniumGridTest
{
    public class MyMessageSink : TestMessageSink
    {
        public bool OnMessage(IMessageSinkMessage message)
        {
            // Do what you want to in response to events here.
            // 
            // Each event has a corresponding implementation of IMessageSinkMessage.
            // See examples here: https://github.com/xunit/abstractions.xunit/tree/master/src/xunit.abstractions/Messages
            Trace.WriteLine("start...");
            var isFailed = message is ITestFailed;
            if (isFailed)
            {
                // Beware that this message won't actually appear in the Visual Studio Test Output console.
                // It's just here as an example. You can set a breakpoint to see that the line is hit.
                var testResult = (ITestFailed)message;
                MyJiraClient.AddIssue(testResult, null);

                return false;
            }

            // Return `false` if you want to interrupt test execution.
            return true;
        }
    }
}
