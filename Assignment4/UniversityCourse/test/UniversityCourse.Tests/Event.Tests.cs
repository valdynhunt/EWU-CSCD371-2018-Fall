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
            new Event(null, "December 3rd, 4p - 6p", "Learning how to do it all.", "Liberty Lake, WA", 85);
        }

        //Event event = new Event(null, "December 3rd, 4p - 6p", "Learning how to do it all.", "Liberty Lake, WA", 85);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Name_AssignEmpty_Throws()
        {
            new Event("", "December 3rd, 4p - 6p", "Learning how to do it all.", "Liberty Lake, WA", 85);
        }

        [TestMethod]
        public void Create_Event_Success()
        {
            new Event("Scrum Training", "Saturday, November 7th, 2018","Intro to time-boxing, software estimation, and all things scrum.", "SIRTI - Spokane, WA", 175);

            //             Event event = new Event("Scrum Training", "Saturday, November 7th, 2018",
            //"Intro to time-boxing, software estimation, and all things scrum.", "SIRTI - Spokane, WA", 175);
            //Assert.IsEqual("Scrum Training", event.name);

        }


    }
}

