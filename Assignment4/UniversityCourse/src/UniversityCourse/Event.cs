using System;

namespace UniversityCourse {

    public class Event {
        public Event(string name, string schedule, string description, string location, int capacity)
        {
            Name = name;
            Schedule = schedule;
            Description = description;
            Location = location;
            Capacity = capacity;
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

        public string Schedule { get; private set; }
        public string Description { get; private set; }
        public string Location { get; private set; }
        public int Capacity { get; private set; }

    }
}


