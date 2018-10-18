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

    }
}


