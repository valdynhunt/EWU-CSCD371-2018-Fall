using System;
using System.Text;

namespace UniversityCourse
{
    public class UniversityCourse : Event
    {
       

        private int _Crn;
        public int Crn 
        {
            get
            {
                return _Crn;
            }
            set
            {
                if (value < 10000)
                {
                    throw new ArgumentException(nameof(Name), "CRN's are five digits.");
                }
                
                _Crn = value;
            }
        }

        private int _CourseNumber;
        public int CourseNumber 
        {
            get
            {
                return _CourseNumber;
            }
            set
            {
                if ((value < 50) || (value > 699))
                {
                    throw new ArgumentException(nameof(Name), "CRN is out of range.");
                }
                
                _CourseNumber = value;
            }
        }

        public int SectionNumber { get; set; }


        private string _DeptPrefix;
        public string DeptPrefix 
        {
            get
            {
                return _DeptPrefix;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(Name), "DeptPrefix cannot be null.");
                }

                if (value.Length != 4) 
                {
                    throw new ArgumentException(nameof(Name), "DeptPrefix must be four letters.");
                }

                if (value.Equals("")) 
                {
                    throw new ArgumentException(nameof(Name), "DeptPrefix cannot be empty.");
                }

                _DeptPrefix = value;
            }
        }

        private string _Instructor;
        public string Instructor
        {
            get
            {
                return _Instructor;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(Name), "DeptPrefix cannot be null.");
                }

                if (value.Equals(""))
                {
                    throw new ArgumentException(nameof(Name), "DeptPrefix cannot be empty.");
                }

                _Instructor = value;
            }
        }

        private string _Building;
        public string Building
        {
            get
            {
                return _Building;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(Name), "DeptPrefix cannot be null.");
                }

                if (value.Equals(""))
                {
                    throw new ArgumentException(nameof(Name), "DeptPrefix cannot be empty.");
                }

                _Building = value;
            }
        }

        public int RemainingSeats
        {
            get { return Capacity - Registered; }
        }

        private int _RoomNumber;

        public int RoomNumber
        {
            get
            {
                return _RoomNumber;
            }
            set
            {
                if ((value < 100) || (value > 999))
                {
                    throw new ArgumentException(nameof(RoomNumber), "RoomNumbers are 3 digits.");
                }

                if (value.Equals(""))
                {
                    throw new ArgumentException(nameof(RoomNumber), "RoomNumber cannot be empty.");
                }

                _RoomNumber = value;
            }
        }

        private int _Credits;
        public int Credits
        {
            get
            {
                return _Credits;
            }
            set
            {

                if (value.Equals(""))
                {
                    throw new ArgumentException(nameof(Credits), "Credits cannot be empty.");
                }

                if (value < 0)
                {
                    throw new ArgumentException(nameof(Credits), "Credits cannot be less than 0.");
                }

                if (value > 16)
                {
                    throw new ArgumentException(nameof(Credits), "Credits cannot be greater than 16.");
                }

                _Credits = value;
            }
        }

        private int _Registered;
        public int Registered
        {
            get
            {
                return _Registered;
            }
            set
            {

                if (value.Equals(""))
                {
                    throw new ArgumentException(nameof(Registered), "Registered cannot be empty.");
                }

                if (value < 0)
                {
                    throw new ArgumentException(nameof(Registered), "Registered cannot be less than 0.");
                }

                if (value > Capacity)
                {
                    throw new ArgumentException(nameof(Registered), "Registered cannot be greater than the capacity.");
                }

                _Registered = value;
            }
        }

        // string name, string schedule, string description, string location, int capacity, 
        // int crn, string deptPrefix, int courseNumber, int sectionNumber
        // string instructor, string building, int roomNumber, int credits, int registered, int remainingSeats (calculated)

        public UniversityCourse(
            string name, string schedule, string description, string location, 
            int capacity, int crn, string deptPrefix, int courseNumber, 
            int sectionNumber, string instructor, string building, int roomNumber, 
            int credits, int registered)
        : base(name, schedule, description, location, capacity)
        {
            Crn = crn;
            DeptPrefix = deptPrefix;
            CourseNumber = courseNumber;
            SectionNumber = sectionNumber;
            Instructor = instructor;
            Building = building;
            RoomNumber = roomNumber;
            Credits = credits;
            Registered = registered;
        }


        public new virtual string GetSummaryInformation()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Environment.NewLine + "-----------University Course Summary ----------" + Environment.NewLine);
            sb.Append("Name: " + Name + Environment.NewLine);
            sb.Append("Schedule: " + Schedule + Environment.NewLine);
            sb.Append("Description: " + Description + Environment.NewLine);
            sb.Append("Location: " + Location + Environment.NewLine);
            sb.Append("Capacity: " + Capacity + Environment.NewLine);
            sb.Append("CRN: " + Crn + Environment.NewLine);
            sb.Append("Dept. Prefix: " + DeptPrefix + Environment.NewLine);
            sb.Append("Course Number: " + CourseNumber + Environment.NewLine);
            sb.Append("Section Number: " + SectionNumber + Environment.NewLine);
            sb.Append("Instructor: " + Instructor + Environment.NewLine);
            sb.Append("Building: " + Building + Environment.NewLine);
            sb.Append("Room Number: " + RoomNumber + Environment.NewLine);
            sb.Append("Credits: " + Credits + Environment.NewLine);
            sb.Append("Registered: " + Registered + Environment.NewLine);

            sb.Append(Environment.NewLine);

            return sb.ToString();
        }

        public virtual void Deconstruct(out string name, out string schedule, out string description, out string location, out int capacity, 
            out int crn, out string deptPrefix, out int courseNumber, out int sectionNumber, 
            out string instructor, out string building, out int roomNumber, out int credits, out int registered)
        {
            name = Name;
            schedule = Schedule;
            description = Description;
            location = Location;
            capacity = Capacity;
            crn = Crn;
            deptPrefix = DeptPrefix;
            courseNumber = CourseNumber;
            sectionNumber = SectionNumber;
            instructor = Instructor;
            building = Building;
            roomNumber = RoomNumber;
            credits = Credits;
            registered = Registered;
        }

        public static void Main(string[] args) {}
    }
}
