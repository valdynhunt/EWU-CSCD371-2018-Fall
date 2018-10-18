using System;

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
// string name, string schedule, string description, string location, int capacity, 
// int crn, string deptPrefix, int courseNumber, int sectionNumber

        public UniversityCourse(string name, string schedule, string description, string location, int capacity, int crn, string deptPrefix, int courseNumber, int sectionNumber)
        : base(name, schedule, description, location, capacity)
        {   
            Crn = crn;
            DeptPrefix = deptPrefix;
            CourseNumber = courseNumber;
            SectionNumber = sectionNumber;
        }

        public static void Main(string[] args) { }
    }
}
