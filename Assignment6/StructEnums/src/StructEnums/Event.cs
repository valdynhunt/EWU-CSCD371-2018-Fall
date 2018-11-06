using System;
using System.Collections.Generic;
using System.Text;

namespace StructEnums {

        public static class MyExtensions
    {
        public static int MyEventMethod(this IEvent ev)
        {
             int piecesOfSwagNeeded = ev.Capacity * 3;
            return piecesOfSwagNeeded;
        }
    }

    public class Event : IEvent
    {

        public static int NumInstances { get; private set; } = 0;
        public Event(string name, string schedule, string description, string location, int capacity)
        {
            NumInstances++;
            EventList.Add(this);
            Name = name;
            Schedule = schedule;
            Description = description;
            Location = location;
            Capacity = capacity;
        }

        public void Deconstruct(out string name, out string schedule, out string description, out string location, out int capacity)
        {
            name = Name;
            schedule = Schedule;
            description = Description;
            location = Location;
            capacity = Capacity;
        }

        public string GetSummaryInformation()
        {
            StringBuilder sb = new StringBuilder();
            //sb.Append(Environment.NewLine);// + "-----------Event Summary ----------" + Environment.NewLine);
            sb.Append(Environment.NewLine);
            sb.Append("Name: " + Name + Environment.NewLine);
            sb.Append("Schedule: " + Schedule + Environment.NewLine);
            sb.Append("Description: " + Description + Environment.NewLine);
            sb.Append("Location: " + Location + Environment.NewLine);
            sb.Append("Capacity: " + Capacity);
            sb.Append(Environment.NewLine);

            return sb.ToString();
        }

        private string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(Name), "Name cannot be null.");
                }

                if (value.Equals(""))
                {
                    throw new ArgumentException(nameof(Name), "Name cannot be empty.");
                }

                _Name = value;
            }
        }

        private string _Schedule;
        public string Schedule
        {
            get
            {
                return _Schedule;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(Name), "Schedule cannot be null.");
                }

                if (value.Equals(""))
                {
                    throw new ArgumentException(nameof(Name), "Schedule cannot be empty.");
                }

                _Schedule = value;
            }
        }

        private string _Description;
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(Name), "Description cannot be null.");
                }

                if (value.Equals(""))
                {
                    throw new ArgumentException(nameof(Name), "Description cannot be empty.");
                }

                _Description = value;
            }
        }

        private string _Location;

        public string Location
        {
            get
            {
                return _Location;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(Name), "Location cannot be null.");
                }

                if (value.Equals(""))
                {
                    throw new ArgumentException(nameof(Name), "Location cannot be empty.");
                }

                _Location = value;
            }
        }

        public int Capacity { get; private set; }
        public static List<Event> EventList { get; } = new List<Event>();

    }
}


