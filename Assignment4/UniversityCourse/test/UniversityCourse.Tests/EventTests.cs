using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UniversityCourse.Tests
{
    [TestClass]
    public class EventTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Name_AssignNull_Throws()
        {
            Event ev = new Event(null, "December 3rd, 4p - 6p", "Learning how to do it all.", "Liberty Lake, WA", 85);
        }

        //Event event = new Event(null, "December 3rd, 4p - 6p", "Learning how to do it all.", "Liberty Lake, WA", 85);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Name_AssignEmpty_Throws()
        {
            Event ev = new Event("", "December 3rd, 4p - 6p", "Learning how to do it all.", "Liberty Lake, WA", 85);
        }

        [TestMethod]
        public void Create_Event_Success()
        {
            Event ev = new Event("Scrum Training", "Saturday, November 7th, 2018","Intro to time-boxing, software estimation, and all things scrum.", "SIRTI - Spokane, WA", 175);
            Assert.AreEqual("Scrum Training", ev.Name);
            Assert.AreEqual("Saturday, November 7th, 2018", ev.Schedule);
            Assert.AreEqual("Intro to time-boxing, software estimation, and all things scrum.", ev.Description);
            Assert.AreEqual("SIRTI - Spokane, WA", ev.Location);
            Assert.AreEqual(175, ev.Capacity);
        }
    }
}

