using System;
using Xunit;
using Xunit.Abstractions;

namespace MongoDBWebAPI.SeleniumTest
{
    public class SeleniumWithouContext 
    {
        private readonly ITestOutputHelper testOutputHelper;        

        public SeleniumWithouContext(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;            
        }

        //[Fact]
        //public void Test1()
        //{
        //    Console.WriteLine("First test");
        //    testOutputHelper.WriteLine("First test");
        //}
    }
}
