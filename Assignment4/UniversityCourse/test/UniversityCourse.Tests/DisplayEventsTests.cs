using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityCourse.Tests
{
    [TestClass]
    public class DisplayEventsTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Display_AssignNull_Throws()
        {
            DisplayEvents.Display(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Display_AssignOther_Throws()
        {
            Object @object = new object();
            DisplayEvents.Display(@object);
        }

        [TestMethod]
        public void Display_AssignEvent_Prints_GetSummaryInformation()
        {
            Event ev = new Event("Scrum Training", "Saturday, November 7th, 2018", "Intro to time-boxing, software estimation, and all things scrum.", "SIRTI - Spokane, WA", 175);
            string expected = ev.GetSummaryInformation();

            Assert.AreEqual(expected, DisplayEvents.Display(ev));
        }

        [TestMethod]
        public void DisplayEventCollection_Displays_GetSummaryInformation_For_Collection()
        {
            Event ev1 = new Event("Scrum Training", "Saturday, November 7th, 2018", "Intro to time-boxing, software estimation, and all things scrum.", "SIRTI - Spokane, WA", 175);
            Event ev2 = new Event("Scrum Training", "Saturday, November 7th, 2018", "Intro to time-boxing, software estimation, and all things scrum.", "SIRTI - Spokane, WA", 175);
            Event ev3 = new UniversityCourse("Programming 1", "MWF 9a - 10a", "An intro to programming using Python.",
                            "Cheney, WA", 45, 13254, "CSCD", 211, 1, "Steiner", "Computing and Engineering Bldg.", 107, 5, 0);

            //DisplayEvents.DisplayEventCollection(Event.EventList);

            StringBuilder sb = new StringBuilder();
            foreach (Event ev in Event.EventList)
            {
                sb.Append(DisplayEvents.Display(ev));
            }

            string expected = sb.ToString();

            Assert.AreEqual(expected, DisplayEvents.DisplayEventCollection(Event.EventList));
        }
    }
}
