using System;

namespace EventApp
{


    class EventApp
    {
        static void Main(string[] args)
        {
            //IConsole console = new RealConsole();
            //var myClass = new MyClassToTest(console);
            //myClass.DoStuff();

            Event ev = new Event("Scrum Training", "Saturday, November 7th, 2018", "Intro to time-boxing, software estimation, and all things scrum.", "SIRTI - Spokane, WA", 175);
            IEvent ievent = ev;
            int piecesOfSwag = ievent.MyEventMethod();
            Console.WriteLine($"Event: {ev.Name}");
            Console.WriteLine($"Event capacity: {ev.Capacity}");
            Console.WriteLine($"Pieces of swag needed: {piecesOfSwag}");
            Console.WriteLine(Environment.NewLine);
            // Console.ReadLine();

            PrintGreeting();

            int response = 0;
            do
            {
                response = GetResponse();

            } while (response != 3);

            Console.WriteLine("That's all folks!");

        }

        private static int GetResponse()
        {
            string response = Console.ReadLine();
            return int.Parse(response);
        }

        private static void PrintGreeting()
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to the EventTrakker!");
            Console.WriteLine();
            Console.WriteLine("1. Enter a new event.");
            Console.WriteLine("2. Print out a list of upcoming events.");
            Console.WriteLine("3. Quit.");
            Console.WriteLine();
        }

        /*
         * 
        public IConsole MyConsole {get; set;}
        public (string firstValue, string secondValue) SetTime()
        {
            var firstValue = MyConsole.ReadLine();
            var secondValue = MyConsole.ReadLine();
            return (firstValue, secondValue);
        }
        */ 
    }
}




//public interface IProvideImperialSize
//{
//    double GetArea();
//}

//public interface IProvideMetricSize
//{
//    double Bounce();
//}

//public class Box : IProvideMetricSize, IProvideImperialSize
//{
//    public int Width { get; set; }
//    public int Height { get; set; }

//    double IProvideMetricSize.Bounce()
//    {
//        throw new NotImplementedException();
//    }

//    public double GetArea()
//    {
//        throw new NotImplementedException();
//    }
//}

