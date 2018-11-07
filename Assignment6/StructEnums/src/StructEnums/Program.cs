using System;
using System.Runtime.InteropServices;

namespace StructEnums//StructEnums
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }


    [Flags]
    public enum DayOfWeek
    {
        None = 0 << 0,          // 0000000
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

    public enum Quarter
    {
        Spring,
        Summer,
        Fall,
        Winter
    }

    public readonly struct TimeValue
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


    public readonly struct Schedule
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

    public struct MutableTimeValue : ITimeInterface
    {
        public MutableTimeValue(int hour, int minute, int second)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
        }

        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }

    }

    public interface ITimeInterface
    {
        int Hour { get; set; }
        int Minute { get; set; }
    }
}
