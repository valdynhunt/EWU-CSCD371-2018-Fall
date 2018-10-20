using System;
using System.Collections.Generic;

namespace UniversityCourse
{

    public static class DisplayEvents
    {
        public static void DisplayEventCollection(List<Event> EventList)
        {

            foreach (Object @object in EventList)
            {
                Display(@object);
            }

        }

        public static void Display(Object @object)
        {
            switch (@object)
            {
                case Event ev:
                    if (ev.GetType().GetMethod("GetSummaryInformation") != null)
                    {
                        Console.WriteLine(ev.GetSummaryInformation());
                    }
                    else
                    {
                        Console.WriteLine(ev.ToString());
                    }
                    break;
                case null:
                    throw new ArgumentNullException(nameof(@object));
                default:
                    throw new ArgumentException("Unknown object type", nameof(@object));
            }
        }
    }
}

