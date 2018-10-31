using System;


namespace EventApp
{


    class EventApp
    {
        static void Main(string[] args)
        {
            IConsole konsole = new ConcreteMyIConsole();
            //var myClass = new MyClassToTest(console);
            //myClass.DoStuff();

            Event ev = new Event("Scrum Training", "Saturday, November 7th, 2018", "Intro to time-boxing, software estimation, and all things scrum.", "SIRTI - Spokane, WA", 175);
            IEvent ievent = ev;
            int piecesOfSwag = ievent.MyEventMethod();
            konsole.WriteLine($"Event: {ev.Name}");
            konsole.WriteLine($"Event capacity: {ev.Capacity}");
            konsole.WriteLine($"Pieces of swag needed: {piecesOfSwag}");
            konsole.WriteLine(Environment.NewLine);

            konsole.WriteLine();
            konsole.WriteLine("Welcome to the EventTrakker!");

            int response = 0;
            do
            {
                PrintGreeting(konsole);

                response = GetResponse();
                if (response == 1) EnterEvent(konsole);
                else if (response == 2)
                {
                    string show = DisplayEvents.DisplayEventCollection(Event.EventList);
                    konsole.WriteLine(show);
                }

            } while (response != 3);

            konsole.WriteLine("That's all folks!");

        }

        private static void ListEvents()
        {
            throw new NotImplementedException();
        }

        private static void EnterEvent(IConsole konsole)
        {
            konsole.WriteLine("To enter a new event, you will need to enter the event name, schedule, description, location, and capatiy.");
            konsole.WriteLine("Please enter the name of your event: ");
            string name = konsole.ReadLine();
            konsole.WriteLine("Please enter the schedule of your event: ");
            string schedule = konsole.ReadLine();
            konsole.WriteLine("Please enter the description of your event: ");
            string description = konsole.ReadLine();
            konsole.WriteLine("Please enter the location of your event: ");
            string location = konsole.ReadLine();
            konsole.WriteLine("Please enter the capacity for your event: ");
            string capacity = konsole.ReadLine();
            Event ev = new Event(name, schedule, description, location, int.Parse(capacity));


        }

        private static int GetResponse()
        {
            string response = Console.ReadLine();
            return int.Parse(response);
        }

        private static void PrintGreeting(IConsole konsole)
        {

            konsole.WriteLine();
            konsole.WriteLine("1. Enter a new event.");
            konsole.WriteLine("2. Print out a list of upcoming events.");
            konsole.WriteLine("3. Quit.");
            konsole.WriteLine();
            konsole.WriteLine("Please enter your choice: ");

        }
    }
}