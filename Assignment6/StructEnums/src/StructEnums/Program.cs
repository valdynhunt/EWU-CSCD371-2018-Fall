using System;

namespace StructEnums//StructEnums
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }


    [Flags]
    public enum DayOfWeek
    {
        Sunday = 1 << 0,	    // 0000001
        Monday = 1 << 1,	    // 0000010
        Tuesday = 1 << 2,	    // 0000100
        Wednesday = 1 << 3,	    // 0001000
        Thursday = 1 << 4,	    // 0010000
        Friday = 1 << 5,	    // 0100000
        Saturday = 1 << 6,	    // 1000000

        MW = Monday | Wednesday,
        TR = Tuesday | Thursday,
        MWF = Monday | Wednesday | Friday
    }

    enum Quarter
    {
        Spring,
        Summer,
        Fall,
        Winter
    }

    readonly struct TimeValue
    {
        public TimeValue(int hour, int minute, int second)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
        }

        public int Hour { get; }
        public int Minute { get; }
        public int Second { get; }
    }


    readonly struct Schedule
    {
        public Schedule(DayOfWeek dayOfWeek, Quarter quarter, TimeValue startTime, TimeSpan duration)
        {
            DayOfWeek = dayOfWeek;
            Quarter = quarter;
            StartTime = startTime;
            Duration = duration;
        }

        public DayOfWeek DayOfWeek { get; }
        public Quarter Quarter { get; }
        public TimeValue StartTime { get; }
        public TimeSpan Duration { get; }
    }


}

/*
Coding Excercise (due 11/06/2018)

    Create a flags enum for the days of the week

    Create an enum for the quarters (Spring, Summer, Fall, Winter) in a school year

    Create a struct that will store only a Time value (hour, minute, second)

    Create a struct called Schedule that has the following properties
        DayOfWeek
        Quarter
        StartTime
        Duration (this will be of type TimeSpan)

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

        example p406 on using [Flags]
        enums - (p399 - 404)
        structs - (p384 - 389)
*/
