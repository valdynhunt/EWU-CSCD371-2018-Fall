using System;
using System.Collections.Generic;
using System.Text;

namespace EventApp
{
    public interface IEvent
    {
        string GetSummaryInformation();
        int Capacity { get; }
    }
}
