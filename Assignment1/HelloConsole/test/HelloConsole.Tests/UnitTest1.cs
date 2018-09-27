using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelloConsole.Tests
{
    [TestClass]
    public class ConsoleGreetingTest
    {
        [TestMethod]
        public void TestInitialGreeting()
        {
            string expectedOutput = @">>Hello from your friendly neighborhood console!
>>What is your first name?
<<Alfred
>>Thanks Alfred! What is your last name?
<<Newman
>>Excellent! Greetings to you, Sir Alfred Newman!
>>I hope this day finds you well and productive.";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, HelloConsole.Greeting.Main);
        }
    }
}
