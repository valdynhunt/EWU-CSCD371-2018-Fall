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

            Assert.IsTrue(ev is Event);
            Assert.IsTrue(ev is UniversityCourse);

        }

        [TestMethod]
        public void Implicit_Cast_of_UniversityCourse_Gives_Event()
        {
            UniversityCourse course = new UniversityCourse("Programming 1", "MWF 9a - 10a", "An intro to programming using Python.",
                "Cheney, WA", 45, 13254, "CSCD", 211, 1, "Steiner", "Computing and Engineering Bldg.", 107, 5, 0);

            Event ev = course;

            Assert.IsTrue(ev is Event);
            Assert.IsTrue(ev is UniversityCourse);
            Assert.AreEqual(ev, course);

        }

        [TestMethod]
        public void Explicit_Cast_of_UniversityCourse_Equals_Implicit_Use_Of_is()
        {
            UniversityCourse course = new UniversityCourse("Programming 1", "MWF 9a - 10a", "An intro to programming using Python.",
    "Cheney, WA", 45, 13254, "CSCD", 211, 1, "Steiner", "Computing and Engineering Bldg.", 107, 5, 0);

            Object ev = (Object)course;

            Assert.IsTrue(ev is Event);
            Assert.IsTrue(course is Event);
            Assert.IsTrue(course is UniversityCourse);
            Assert.IsTrue(ev is UniversityCourse);
            Assert.IsTrue((Object)course is UniversityCourse);
            Assert.AreEqual(ev, course);


        }


        [TestMethod]
        public void TypeCasting_UniversityCourse_With_is_Similar_To_TypeCasting_With_as()
        {
            UniversityCourse course = new UniversityCourse("Programming 1", "MWF 9a - 10a", "An intro to programming using Python.",
"Cheney, WA", 45, 13254, "CSCD", 211, 1, "Steiner", "Computing and Engineering Bldg.", 107, 5, 0);

            Object ev = course;

            Assert.IsTrue(ev is UniversityCourse);
            Assert.IsTrue((Object)course is UniversityCourse);
            Assert.AreEqual(ev as Event, course as Object);
            Assert.AreEqual(ev as Object, course as Event);
            Assert.AreEqual(ev as UniversityCourse, course as Object);
            Assert.AreEqual(ev as Object, course as UniversityCourse);
            Assert.AreEqual(ev as UniversityCourse, course as UniversityCourse);

        }
    }
}
