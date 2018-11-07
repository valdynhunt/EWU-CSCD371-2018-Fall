using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StructEnums.Tests
{
    [TestClass]
    public class StructEnumsTests
    {
        [TestMethod]
        public void String_Sets_Enum_Single()
        {
            string specificDay = "Monday";
            DayOfWeek day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), specificDay);
            Assert.AreEqual(specificDay, day.ToString());
        }

        [TestMethod]
        public void String_Sets_Enum_Two_Days()
        {
            string specificDays = "MW";
            DayOfWeek days = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), specificDays);
            Assert.AreEqual(specificDays, days.ToString());
        }

        [TestMethod]
        public void String_Sets_Enum_Three_Days()
        {
            string specificDays = "MWF";
            DayOfWeek days = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), specificDays);
            Assert.AreEqual(specificDays, days.ToString());
        }

        [TestMethod]
        public void String_Sets_Enum_Weekend()
        {
            DayOfWeek weekend = DayOfWeek.Saturday | DayOfWeek.Sunday;
            string theWeekend = "Saturday, Sunday";
            DayOfWeek days = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), theWeekend);
            Assert.AreEqual(weekend, days);
        }

        [TestMethod]
        public void String_Sets_Enum_Weekdays()
        {
            DayOfWeek weekdays = DayOfWeek.MWF | DayOfWeek.TR;
            string theWeekdays = "Monday, Tuesday, Wednesday, Thursday, Friday";
            DayOfWeek days = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), theWeekdays);
            Assert.AreEqual(weekdays, days);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Incorrect_String_Throws()
        {
            string specificDay = "Funday";
            DayOfWeek days = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), specificDay);
        }

        [TestMethod]
        public void Default_Sets_Enum_To_None()
        {
            DayOfWeek notSet = DayOfWeek.None;
            string theDefault = default(DayOfWeek).ToString();
            DayOfWeek days = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), default(DayOfWeek).ToString());

            Assert.AreEqual(notSet, days);
            Assert.AreEqual(notSet.ToString(), theDefault);
        }

        [TestMethod]
        public void String_Sets_Enum_Quarter()
        {
            string nextQuarter = "Winter";
            Quarter nextQ = (Quarter)Enum.Parse(typeof(Quarter), nextQuarter);
            Assert.AreEqual(nextQuarter, nextQ.ToString());
        }

        [TestMethod]
        public void Default_Sets_Enum_Quarter_To_First_Value()
        {
            Quarter def =  Quarter.Spring;
            string theDefault = default(Quarter).ToString();
            Quarter days = (Quarter)Enum.Parse(typeof(Quarter), default(Quarter).ToString());

            Assert.AreEqual(def, days);
            Assert.AreEqual(def.ToString(), theDefault);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Incorrect_String_Parsing_Quarter_Throws()
        {
            string unknownQuarter = "Mid-Winter";
            DayOfWeek days = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), unknownQuarter);
        }

        [TestMethod]
        public void TimeValue_Struct_Create_Success()
        {
            int num = 7;
            TimeValue tval = new TimeValue(num, 41, 36);
            Assert.AreEqual(tval.Hour, num);
        }

        [TestMethod]
        public void TimeValue_Struct_Is_ReadOnly()
        {
            TimeValue tval = new TimeValue(7, 41, 36);

            Boolean canWriteHour = typeof(TimeValue).GetProperty("Hour").CanWrite;
            Boolean canWriteMinute = typeof(TimeValue).GetProperty("Minute").CanWrite;
            Boolean canWriteSecond = typeof(TimeValue).GetProperty("Second").CanWrite;

            Assert.AreEqual(canWriteHour, false);
            Assert.AreEqual(canWriteMinute, false);
            Assert.AreEqual(canWriteSecond, false);
        }

        [TestMethod]
        public void Schedule_Struct_Create_Success()
        {
            DayOfWeek thisDay = DayOfWeek.Monday;
            Quarter thisQuarter = Quarter.Fall;
            TimeValue start = new TimeValue(7, 0, 0);
            TimeSpan dur = new TimeSpan(60);

            Schedule schedule = new Schedule(thisDay, thisQuarter, start, dur);

            Assert.AreEqual(schedule.DayOfWeek, thisDay);
            Assert.AreEqual(schedule.Quarter, thisQuarter);
            Assert.AreEqual(schedule.StartTime, start);
            Assert.AreEqual(schedule.Duration, dur);

        }

        [TestMethod]
        public void Schedule_Struct_Is_ReadOnly()
        {
            DayOfWeek thisDay = DayOfWeek.Monday;
            Quarter thisQuarter = Quarter.Fall;
            TimeValue start = new TimeValue(7, 0, 0);
            TimeSpan dur = new TimeSpan(60);

            Schedule schedule = new Schedule(thisDay, thisQuarter, start, dur);

            Boolean canWriteDayOfWeek = typeof(Schedule).GetProperty("DayOfWeek").CanWrite;
            Boolean canWriteQuarter = typeof(Schedule).GetProperty("Quarter").CanWrite;
            Boolean canWriteStartTime = typeof(Schedule).GetProperty("StartTime").CanWrite;
            Boolean canWriteDuration = typeof(Schedule).GetProperty("Duration").CanWrite;

            Assert.AreEqual(canWriteDayOfWeek, false);
            Assert.AreEqual(canWriteQuarter, false);
            Assert.AreEqual(canWriteStartTime, false);
            Assert.AreEqual(canWriteDuration, false);
        }

    }
}


/*
Coding Excercise (due 11/06/2018)

    Write unit tests that verify the following
    You are able to parse a string for multiple days of the week and it sets the enum properly (both single and combination)
    You are able to parse a single value string for Quarter and it sets the proper value
        Your structs are readonly
        Using Marshal.SizeOf, make sure your struct isn't larger than 16 bytes - Marshal.SizeOf() returns an integer stating how many bytes a value type is.

    Create a separate class and struct for performing the following tests 
    (this is needed because we aren't going to be following best practices for the struct in these tests).
        
        Create a struct and class that has some read/write properties
        Write tests that show the following behavior
            When passing a struct to a method and changing a property value, the passed in struct is not changed in the original calling method
            When passing a class to a method and changing a property value, the passed in class is changed in the original calling method
            When passing a struct to a method and changing a property value, the passed in struct is changed in the original calling method
            When passing a class to a method and creating a new instance of that class, the passed in class is changed in the original calling method
            When casting a struct to an interface, then passing that interface to a method that changes a property value, show that the interface 
            after the method call has the property value changed in the original calling method

    Create a flags enum for the days of the week

    Create an enum for the quarters (Spring, Summer, Fall, Winter) in a school year

    Create a struct that will store only a Time value (hour, minute, second)

    Create a struct called Schedule that has the following properties
        DayOfWeek
        Quarter
        StartTime
        Duration (this will be of type TimeSpan)
     */
