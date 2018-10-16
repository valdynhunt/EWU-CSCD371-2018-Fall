
namespace LoginStuff.Tests
{
    public class Person
    {
        private string _UserName;
        public string UserName
        {
            get
            {
                return $"{FirstName}.{LastName}";
            }
            set
            {
                string[] parts = value.Split(".");
                FirstName = parts[0];
                LastName = parts[1];
            }
        }

        private string Password;

        public string LastName { get; set; }

        private int _Age;
        public int Age
        {
            get { return _Age; }
            set { _Age = value; }
        }

        private string _FirstName;
        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                _FirstName = value;
            }
        }


        public Person(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public Person(string firstName, string lastName, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Password = password;
        }

    }
}