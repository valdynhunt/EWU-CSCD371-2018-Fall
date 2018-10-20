using System;
using System.Diagnostics;
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

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Name_AssignEmpty_Throws()
        {
            Event ev = new Event("", "December 3rd, 4p - 6p", "Learning how to do it all.", "Liberty Lake, WA", 85);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Schedule_AssignNull_Throws()
        {
            Event ev = new Event("Programming 1", null, "Learning how to do it all.", "Liberty Lake, WA", 85);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Schedule_AssignEmpty_Throws()
        {
            Event ev = new Event("Programming 1", "", "Learning how to do it all.", "Liberty Lake, WA", 85);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Description_AssignNull_Throws()
        {
            Event ev = new Event("Programming 1", "December 3rd, 4p - 6p", null, "Liberty Lake, WA", 85);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Description_AssignEmpty_Throws()
        {
            Event ev = new Event("Programming 1", "December 3rd, 4p - 6p", "", "Liberty Lake, WA", 85);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Location_AssignNull_Throws()
        {
            Event ev = new Event("Programming 1", "December 3rd, 4p - 6p", "Learning how to do it all.", null, 85);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Location_AssignEmpty_Throws()
        {
            Event ev = new Event("Programming 1", "December 3rd, 4p - 6p", "Learning how to do it all.", "", 85);
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
            Console.WriteLine(value: "instances: " + Event.NumInstances);
            Trace.WriteLine(ev.GetSummaryInformation());
        }

        [TestMethod]
        public void Create_Event_Increments_Instances()
        {
            int before = Event.NumInstances;
            Event ev = new Event("Scrum Training", "Saturday, November 7th, 2018", "Intro to time-boxing, software estimation, and all things scrum.", "SIRTI - Spokane, WA", 175);
            int after = Event.NumInstances;
            Assert.AreEqual(1, after - before);
        }

        [TestMethod]
        public void GetSummaryInformation_Returns_Instance_Info()
        {
            Event ev = new Event("Scrum Training", "Saturday, November 7th, 2018", "Intro to time-boxing, software estimation, and all things scrum.", "SIRTI - Spokane, WA", 175);
            string expected = $@"
-----------Event Summary ----------
Name: {ev.Name}
Schedule: {ev.Schedule}
Description: {ev.Description}
Location: {ev.Location}
Capacity: {ev.Capacity}

";
            Assert.AreEqual(expected, ev.GetSummaryInformation());
        }
    }
}

