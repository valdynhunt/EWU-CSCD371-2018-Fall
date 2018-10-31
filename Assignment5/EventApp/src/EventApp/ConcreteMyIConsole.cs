using System;
using System.Collections.Generic;
using System.Text;

namespace EventApp
{
    class ConcreteMyIConsole : IConsole
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
}
