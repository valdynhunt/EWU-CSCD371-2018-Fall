using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Runtime.InteropServices;

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

        [TestMethod]
        public void TimeValue_Struct_Not_Larger_Than_16_Bytes()
        {
            TimeValue tval = new TimeValue(7, 41, 36);
            int structSize = Marshal.SizeOf(tval);
            Assert.AreEqual(structSize, 12);
        }

        [TestMethod]
        public void Schedule_Struct_Is_Larger_Than_16_Bytes()
        {
            DayOfWeek thisDay = DayOfWeek.Monday;
            Quarter thisQuarter = Quarter.Fall;
            TimeValue start = new TimeValue(7, 0, 0);
            TimeSpan dur = new TimeSpan(60);

            Schedule schedule = new Schedule(thisDay, thisQuarter, start, dur);

            int structSize = Marshal.SizeOf(schedule);
            Assert.AreEqual(structSize, 32);
        }

        [TestMethod]
        public void Changing_Passed_In_Struct_Does_Not_Change_Original()
        {

            MutableTimeValue mutableStruct = new MutableTimeValue(8, 45, 10);
            DoSomething(mutableStruct);

            void DoSomething(MutableTimeValue mStruct)
            {
                mStruct.Hour = 11;

                Assert.AreNotEqual(mStruct.Hour, mutableStruct.Hour);
            }

        }

        [TestMethod]
        public void Changing_Passed_In_Dog_Changes_Original()
        {
            Dog coco = new Dog("Coco", "black", "Angry Bird", 16);
            DoSomethingByRef(coco);

            void DoSomethingByRef(Dog doggie)
            {
                doggie.Toy = "Brother Bear";

                Assert.AreEqual(coco.Toy, doggie.Toy);
            }

        }

        [TestMethod]
        public void New_Instance_Of_Dog_Class_Changes_Original()
        {

            Dog coco = new Dog("Coco", "black", "Angry Bird", 16);
            DoSomethingByRef(coco);

            void DoSomethingByRef(Dog doggie)
            {
                doggie = new Dog("Lucy", "white", "bone", 23);

                Assert.AreNotEqual(coco, doggie);
            }

        }

        [TestMethod]
        public void Changing_Passed_In_Struct_Changes_Original()
        {

            MutableTimeValue mutableStruct = new MutableTimeValue(8, 45, 10);
            DoSomethingByRef(ref mutableStruct);

            void DoSomethingByRef(ref MutableTimeValue mStruct)
            {
                mStruct.Hour = mStruct.Second;

                Assert.AreEqual(mStruct.Hour, mutableStruct.Hour);
            }

        }

        [TestMethod]
        public void Interface_Passed_In_Changes_Will_Change_Original()
        {
            var MutableTimeValue = new MutableTimeValue (3, 4, 5);
            var myIface = (ITimeInterface) MutableTimeValue;
            DoSomething(myIface);

            void DoSomething(ITimeInterface myPassedInInterface)
            {
                myPassedInInterface.Hour = myPassedInInterface.Minute;

                Assert.AreEqual(myPassedInInterface.Hour, myPassedInInterface.Minute);
                Assert.AreEqual(myIface.Hour, myPassedInInterface.Hour);

            }
        }
    }
}