using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EventApp.Tests
{
    [TestClass]
    public class EventAppTests
    {
        [TestMethod]
        public void Explicit_Cast_of_UniversityCourse_Gives_Event()
        {
            UniversityCourse course = new UniversityCourse("Programming 1", "MWF 9a - 10a", "An intro to programming using Python.",
                "Cheney, WA", 45, 13254, "CSCD", 211, 1, "Steiner", "Computing and Engineering Bldg.", 107, 5, 0);

            Event ev = (Event)course;
            Event ev2 = course;
            Object ev3 = (Object)course;


            Assert.IsTrue(ev is Event);
            Assert.IsTrue(ev2 is Event);
            Assert.IsTrue(ev is UniversityCourse);
            Assert.IsTrue(ev2 is UniversityCourse);



        }

        [TestMethod]
        public void Explicit_Cast_of_UniversityCourse_Equals_Implicit_Use_of_is()
        {
            UniversityCourse course = new UniversityCourse("Programming 1", "MWF 9a - 10a", "An intro to programming using Python.",
    "Cheney, WA", 45, 13254, "CSCD", 211, 1, "Steiner", "Computing and Engineering Bldg.", 107, 5, 0);

            Event ev = (Event)course;
            Event ev2 = course;
            Object ev3 = (Object)course;


            Assert.IsTrue((Event)course is Event);
            Assert.IsTrue((Event)course is UniversityCourse);

        }

        [TestMethod]
        public void Explicit_Cast_of_UniversityCourse_Equals_Implicit_Use_of_as()
        {
            UniversityCourse course = new UniversityCourse("Programming 1", "MWF 9a - 10a", "An intro to programming using Python.",
"Cheney, WA", 45, 13254, "CSCD", 211, 1, "Steiner", "Computing and Engineering Bldg.", 107, 5, 0);

            Event ev = (Event)course;
            Event ev2 = course;
            Object ev3 = (Object)course;

            Assert.AreEqual(ev.Description, course.Description);
            Assert.AreEqual(ev2.Description, course.Description);

        }

        [TestMethod]
        public void TypeCasting_UniversityCourse_With_is_Equals_TypeCasting_With_as()
        {
            UniversityCourse course = new UniversityCourse("Programming 1", "MWF 9a - 10a", "An intro to programming using Python.",
"Cheney, WA", 45, 13254, "CSCD", 211, 1, "Steiner", "Computing and Engineering Bldg.", 107, 5, 0);

            Event ev = (Event)course;
            Event ev2 = course;
            Object ev3 = course;

            Assert.IsTrue(course is Event);
            Assert.IsTrue(course is UniversityCourse);
            Assert.IsTrue(ev2 is Event);
            Assert.IsTrue(ev2 is UniversityCourse);
            Assert.IsTrue(ev3 is Event);
            Assert.IsTrue(ev3 is Object);
            Assert.IsTrue(ev3 is UniversityCourse);

            Assert.IsTrue(course is Event);
            Assert.IsTrue(course is UniversityCourse);
            Assert.IsTrue(ev2 is Event);
            Assert.IsTrue(ev2 is UniversityCourse);
            Assert.IsTrue(ev3 is Event);
            Assert.IsTrue(ev3 is Object);
            Assert.AreEqual(ev3 as Event, course as Object);
            Assert.AreEqual(ev3 as Object, course as UniversityCourse);
            Assert.AreEqual(ev3 as UniversityCourse, course as UniversityCourse);

        }
    }
}
