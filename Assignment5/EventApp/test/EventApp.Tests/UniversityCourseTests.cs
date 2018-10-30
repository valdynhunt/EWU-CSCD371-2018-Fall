using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EventApp.Tests
{
    [TestClass]
    public class UniversityCourseTests
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Crn_AssignToSmall_Throws()
        {
            UniversityCourse course = new UniversityCourse("Programming 1", "MWF 9a - 10a", "An intro to programming using Python.", 
                "Cheney, WA", 45, 1325, "CSCD", 811, 1, "Steiner", "Computing and Engineering Bldg.", 107, 5, 0);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeptPrefix_AssignNull_Throws()
        {
            UniversityCourse course = new UniversityCourse(null, "MWF 9a - 10a", "An intro to programming using Python.", 
                "Cheney, WA", 45, 13254, null, 811, 1, "Steiner", "Computing and Engineering Bldg.", 107, 5, 0);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeptPrefix_AssignEmpty_Throws()
        {
            UniversityCourse course = new UniversityCourse("Programming 1", "MWF 9a - 10a", "An intro to programming using Python.", 
                "Cheney, WA", 45, 13254, "", 811, 1, "Steiner", "Computing and Engineering Bldg.", 107, 5, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeptPrefix_AssignTooShort_Throws()
        {
            UniversityCourse course = new UniversityCourse("Programming 1", "MWF 9a - 10a", "An intro to programming using Python.", 
                "Cheney, WA", 45, 13254, "CSC", 811, 1, "Steiner", "Computing and Engineering Bldg.", 107, 5, 0);
        }

// string name, string schedule, string description, string location, int capacity, 
// int crn, string deptPrefix, int courseNumber, int sectionNumber
// string instructor, string building, int roomNumber, int credits, int registered, int remainingSeats (calculated)

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CourseNumber_AssignTooLarge_Throws()
        {
            UniversityCourse course = new UniversityCourse("Programming 1", "MWF 9a - 10a", "An intro to programming using Python.", 
                "Cheney, WA", 45, 13254, "CSCD", 811, 1, "Steiner", "Computing and Engineering Bldg.", 107, 5, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CourseNumber_AssignTooSmall_Throws()
        {
            UniversityCourse course = new UniversityCourse("Programming 1", "MWF 9a - 10a", "An intro to programming using Python.", 
                "Cheney, WA", 45, 13254, "CSCD", 49, 1, "Steiner", "Computing and Engineering Bldg.", 107, 5, 0);
        }

        //====================

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Instructor_AssignNull_Throws()
        {
            UniversityCourse course = new UniversityCourse(null, "MWF 9a - 10a", "An intro to programming using Python.", 
                "Cheney, WA", 45, 13254, "CSCD", 211, 1, null, "Computing and Engineering Bldg.", 107, 5, 0);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Instructor_AssignEmpty_Throws()
        {
            UniversityCourse course = new UniversityCourse("Programming 1", "MWF 9a - 10a", "An intro to programming using Python.", 
                "Cheney, WA", 45, 13254, "CSCD", 211, 1, "", "Computing and Engineering Bldg.", 107, 5, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Building_AssignNull_Throws()
        {
            UniversityCourse course = new UniversityCourse("Programming 1", "MWF 9a - 10a", "An intro to programming using Python.",
                "Cheney, WA", 45, 13254, "CSCD", 211, 1, "Steiner", null, 107, 5, 0);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Building_AssignEmpty_Throws()
        {
            UniversityCourse course = new UniversityCourse("Programming 1", "MWF 9a - 10a", "An intro to programming using Python.",
                "Cheney, WA", 45, 13254, "CSCD", 211, 1, "Steiner", "", 107, 5, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RoomNumber_AssignTooLarge_Throws()
        {
            UniversityCourse course = new UniversityCourse("Programming 1", "MWF 9a - 10a", "An intro to programming using Python.",
                "Cheney, WA", 45, 13254, "CSCD", 211, 1, "Steiner", "Computing and Engineering Bldg.", 1070, 5, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RoomNumber_AssignTooSmall_Throws()
        {
            UniversityCourse course = new UniversityCourse("Programming 1", "MWF 9a - 10a", "An intro to programming using Python.",
                "Cheney, WA", 45, 13254, "CSCD", 211, 1, "Steiner", "Computing and Engineering Bldg.", 17, 5, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Credits_AssignTooLarge_Throws()
        {
            UniversityCourse course = new UniversityCourse("Programming 1", "MWF 9a - 10a", "An intro to programming using Python.",
                "Cheney, WA", 45, 13254, "CSCD", 211, 1, "Steiner", "Computing and Engineering Bldg.", 107, 17, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Credits_AssignTooSmall_Throws()
        {
            UniversityCourse course = new UniversityCourse("Programming 1", "MWF 9a - 10a", "An intro to programming using Python.",
                "Cheney, WA", 45, 13254, "CSCD", 211, 1, "Steiner", "Computing and Engineering Bldg.", 107, -3, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Registered_AssignOverCapacity_Throws()
        {
            UniversityCourse course = new UniversityCourse("Programming 1", "MWF 9a - 10a", "An intro to programming using Python.",
                "Cheney, WA", 45, 13254, "CSCD", 211, 1, "Steiner", "Computing and Engineering Bldg.", 107, 51, 151);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Registered_AssignTooSmall_Throws()
        {
            UniversityCourse course = new UniversityCourse("Programming 1", "MWF 9a - 10a", "An intro to programming using Python.",
                "Cheney, WA", 45, 13254, "CSCD", 211, 1, "Steiner", "Computing and Engineering Bldg.", 107, 5, -1);
        }

        [TestMethod]
        public void RemainingSeats_Return_Capacity_Minus_Registered()
        {
            UniversityCourse course = new UniversityCourse("Programming 1", "MWF 9a - 10a", "An intro to programming using Python.",
                "Cheney, WA", 45, 13254, "CSCD", 211, 1, "Steiner", "Computing and Engineering Bldg.", 107, 5, 0);

            int expected = course.Capacity - course.Registered;
            Assert.AreEqual(expected, course.RemainingSeats);
        }

        [TestMethod]
        public void Create_UniversityCourse_Success() 
        {
            UniversityCourse course = new UniversityCourse("Programming 1", "MWF 9a - 10a", "An intro to programming using Python.", 
                "Cheney, WA", 45, 13254, "CSCD", 211, 1, "Steiner", "Computing and Engineering Bldg.", 107, 5, 0);

            Assert.AreEqual(course.Crn, 13254);
            Assert.AreEqual(course.DeptPrefix, "CSCD");
            Assert.AreEqual(course.CourseNumber, 211);
            Assert.AreEqual(course.SectionNumber, 1);

            Assert.AreEqual(course.Instructor, "Steiner");
            Assert.AreEqual(course.Building, "Computing and Engineering Bldg.");
            Assert.AreEqual(course.RoomNumber, 107);
            Assert.AreEqual(course.Credits, 5);
            Assert.AreEqual(course.Registered, 0);

        }

        [TestMethod]
        public void Create_UniversityCourse_Increments_Instances()
        {
            int before = Event.NumInstances;
            UniversityCourse course = new UniversityCourse("Programming 1", "MWF 9a - 10a", "An intro to programming using Python.",
                "Cheney, WA", 45, 13254, "CSCD", 211, 1, "Steiner", "Computing and Engineering Bldg.", 107, 5, 0);
            int after = Event.NumInstances;
            Assert.AreEqual(1, after - before);
        }

        [TestMethod]
        public void GetSummaryInformation_Returns_Instance_Info()
        {
            UniversityCourse course = new UniversityCourse("Programming 1", "MWF 9a - 10a", "An intro to programming using Python.",
                "Cheney, WA", 45, 13254, "CSCD", 211, 1, "Steiner", "Computing and Engineering Bldg.", 107, 5, 0);
            string expected = $@"
-----------University Course Summary ----------
Name: {course.Name}
Schedule: {course.Schedule}
Description: {course.Description}
Location: {course.Location}
Capacity: {course.Capacity}
CRN: {course.Crn}
Dept. Prefix: {course.DeptPrefix}
Course Number: {course.CourseNumber}
Section Number: {course.SectionNumber}
Instructor: {course.Instructor}
Building: {course.Building}
Room Number: {course.RoomNumber}
Credits: {course.Credits}
Registered: {course.Registered}

";

            
            


            Assert.AreEqual(expected, course.GetSummaryInformation());
        }

        [TestMethod]
        public void Deconstruct_Gives_Component_Parts()
        {
            UniversityCourse course = new UniversityCourse("Programming 1", "MWF 9a - 10a", "An intro to programming using Python.",
                            "Cheney, WA", 45, 13254, "CSCD", 211, 1, "Steiner", "Computing and Engineering Bldg.", 107, 5, 0);

            course.Deconstruct(out string name, out string schedule, out string description, out string location, out int capacity,
            out int crn, out string deptPrefix, out int courseNumber, out int sectionNumber,
            out string instructor, out string building, out int roomNumber, out int credits, out int registered);

            Assert.AreEqual(name, course.Name);
            Assert.AreEqual(schedule, course.Schedule);
            Assert.AreEqual(description, course.Description);
            Assert.AreEqual(location, course.Location);
            Assert.AreEqual(capacity, course.Capacity);
            Assert.AreEqual(crn, course.Crn);
            Assert.AreEqual(deptPrefix, course.DeptPrefix);
            Assert.AreEqual(courseNumber, course.CourseNumber);
            Assert.AreEqual(sectionNumber, course.SectionNumber);
            Assert.AreEqual(instructor, course.Instructor);
            Assert.AreEqual(building, course.Building);
            Assert.AreEqual(roomNumber, course.RoomNumber);
            Assert.AreEqual(credits, course.Credits);
            Assert.AreEqual(registered, course.Registered);
        }
    }
}
