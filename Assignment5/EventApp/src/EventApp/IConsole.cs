﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EventApp
{
    public interface IConsole
    {
        void WriteLine();
        void WriteLine(string line);
        string ReadLine();
     
    }
}