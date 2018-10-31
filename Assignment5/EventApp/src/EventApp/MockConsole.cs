using System;
using System.Collections.Generic;
using System.Text;

namespace EventApp
{
    class MockConsole : IConsole
    {
        private int readLineCount = 0;
        public string ConsoleValue { get; set; }
        public List<string> InputValue = new List<string>();
        public string ReadLine()
        {
            return InputValue[readLineCount++];
        }

        public void WriteLine(string output)
        {
            ConsoleValue = output;
        }

        public void WriteLine()
        {
            ConsoleValue = "";
        }
    }
}
