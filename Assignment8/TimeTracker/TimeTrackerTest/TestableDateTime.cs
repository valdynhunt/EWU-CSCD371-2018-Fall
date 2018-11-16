using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeTracker;

namespace TimeTrackerTest
{

    public class TestableDateTime : IDateTime
    {
        

        public TestableDateTime()
        {
            Now = DateTime.Now;
        }

        public DateTime Now { get; }
        public DateTime SystemTime(DateTime? now)
        {
            return now.GetValueOrDefault(Now);
        }

        public void DidReturnSystemDateTimeNow()
        {
            DateTime dt = DateTime.Now;
            Assert.AreEqual(SystemTime(null), Now);
            Assert.AreEqual(SystemTime(new DateTime()), Now);
            Assert.AreNotEqual(SystemTime(new DateTime(2018, 11, 11)), Now);

        }
    }
}
