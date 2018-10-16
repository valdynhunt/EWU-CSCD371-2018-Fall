namespace LoginStuff.Tests
{
    public class Person
    {
        public string UserName;
        private string Password;

        public string LastName { get; set; }



        private string _FirstName;
        public string FirstName {
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
            UserName = $"{firstName}.{lastName}";
            Password = password;
        }

    }
}