using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleTester
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IConsole myConsole = new MockConsole();
            ((MockConsole)myConsole).InputValue = "Hello World 2";
            var myClass = new MyClass();

            Assert.AreEqual("Hello World 2", myClass.GetUserInput(myConsole));
        }
    }

    class MyClass
    {
        public string GetUserInput(IConsole console)
        {
            return console.ReadLine();
        }
    }

    interface IConsole
    {
        void WriteLine(string output);
        string ReadLine();
    }

    class ConcreteConsole : IConsole
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }
    }

    class MockConsole : IConsole
    {
        public string ConsoleValue { get; set; }
        public string InputValue {get; set;}
        public string ReadLine()
        {
            return InputValue;
        }

        public void WriteLine(string output)
        {
            ConsoleValue = output;
        }
    }
}
