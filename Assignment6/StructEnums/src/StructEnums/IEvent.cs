using System;
using System.Collections.Generic;
using System.Text;

namespace StructEnums
{
    public interface IEvent
    {
        string GetSummaryInformation();
        int Capacity { get; }
    }
}
