using System;
using System.Diagnostics;
using EventApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EventApp.Tests
{
    [TestClass]
    public class MainEventTests
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

        [TestMethod]
        public void Failed_Conversion_With_as_Fails_Gracefully()

        {
            UniversityCourse course = new UniversityCourse("Programming 1", "MWF 9a - 10a", "An intro to programming using Python.",
"Cheney, WA", 45, 13254, "CSCD", 211, 1, "Steiner", "Computing and Engineering Bldg.", 107, 5, 0);

            Object ob = course;
            Object ob2 = "foo";

            Assert.AreEqual(ob, ob as UniversityCourse);
            Assert.AreEqual(ob2 as UniversityCourse, null);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Failed_Conversion_With_is_Throws()
        {
            UniversityCourse course = new UniversityCourse(null, "MWF 9a - 10a", "An intro to programming using Python.",
                "Cheney, WA", 45, 13254, null, 811, 1, "Steiner", "Computing and Engineering Bldg.", 107, 5, 0);

            Object ob = "foo";
            Assert.AreEqual(ob is UniversityCourse, null);
            Assert.IsTrue(ob is UniversityCourse myCourse && myCourse.Credits == 5);

        }

        //[TestMethod]
        //public void PrintGreeting_Sends_Greeting_To_Console()
        //{

        //    MockConsole myConsole = new MockConsole();
        //    MainEvent myClass = new MainEvent(myConsole);

           
        //    myClass.Konsole = myConsole;
        //    string expectedOutput = $@"

        //>>1. Enter a new event.
        //>>2. Print out a list of upcoming events.
        //>>3. Quit.

        //>>Please enter your choice: 
        //";

        //    IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, MainEvent.Main);

        //}
    }
}

/*
[TestMethod]
public void TestMethod1()
{
    MockConsole myConsole = new MockConsole();
    myConsole.InputValue.Add("Hello World");
    myConsole.InputValue.Add("Hello World 2");

    var myClass = new Program();
    myClass.MyConsole = myConsole;

    var myTuple = myClass.SetTime();

    Assert.AreEqual("Hello World", myTuple.firstValue);
    Assert.AreEqual("Hello World 2", myTuple.secondValue);
}


        private void PrintGreeting(IConsole konsole)
{

    konsole.WriteLine();
    konsole.WriteLine("1. Enter a new event.");
    konsole.WriteLine("2. Print out a list of upcoming events.");
    konsole.WriteLine("3. Quit.");
    konsole.WriteLine();
    konsole.WriteLine("Please enter your choice: ");

}
*/

