using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UniversityCourse.Tests
{
    [TestClass]
    public class UniversityCourseTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Name_AssignNull_Throws()
        {
            UniversityCourse course = new UniversityCourse(null, "MWF 9a - 10a", "An intro to programming using Python.", "Cheney, WA", 45, 13254, "CSCD", 811, 1);
            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Name_AssignEmpty_Throws()
        {
            UniversityCourse course = new UniversityCourse("", "MWF 9a - 10a", "An intro to programming using Python.", "Cheney, WA", 45, 13254, "CSCD", 811, 1);
            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Crn_AssignToSmall_Throws()
        {
            UniversityCourse course = new UniversityCourse("Programming 1", "MWF 9a - 10a", "An intro to programming using Python.", "Cheney, WA", 45, 1325, "CSCD", 811, 1);
            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeptPrefix_AssignEmpty_Throws()
        {
            UniversityCourse course = new UniversityCourse("Programming 1", "MWF 9a - 10a", "An intro to programming using Python.", "Cheney, WA", 45, 13254, "", 811, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeptPrefix_AssignTooShort_Throws()
        {
            UniversityCourse course = new UniversityCourse("Programming 1", "MWF 9a - 10a", "An intro to programming using Python.", "Cheney, WA", 45, 13254, "CSC", 811, 1);
        }

// string name, string schedule, string description, string location, int capacity, 
// int crn, string deptPrefix, int courseNumber, int sectionNumber

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CourseNumber_AssignTooLarge_Throws()
        {
            UniversityCourse course = new UniversityCourse("Programming 1", "MWF 9a - 10a", "An intro to programming using Python.", "Cheney, WA", 45, 13254, "CSCD", 811, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CourseNumber_AssignTooSmall_Throws()
        {
            UniversityCourse course = new UniversityCourse("Programming 1", "MWF 9a - 10a", "An intro to programming using Python.", "Cheney, WA", 45, 13254, "CSCD", 49, 1);
        }

        [TestMethod]
        public void Create_UniversityCourse_Success() 
        {
            UniversityCourse course = new UniversityCourse("Programming 1", "MWF 9a - 10a", "An intro to programming using Python.", "Cheney, WA", 45, 13254, "CSCD", 211, 1);

            Assert.AreEqual(course.Crn, 13254);
            Assert.AreEqual(course.DeptPrefix, "CSCD");
            Assert.AreEqual(course.CourseNumber, 211);
            Assert.AreEqual(course.SectionNumber, 1);
            
        }
    }
}
