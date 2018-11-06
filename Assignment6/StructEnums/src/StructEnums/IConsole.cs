using System;
using System.Collections.Generic;
using System.Text;

namespace StructEnums
{
    public interface IConsole
    {
        void WriteLine();
        void WriteLine(string line);
        string ReadLine();
     
    }
}
