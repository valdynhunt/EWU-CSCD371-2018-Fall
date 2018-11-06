using System;
using System.Collections.Generic;

namespace StructEnums
{

    public static class DisplayEvents
    {
        public static string DisplayEventCollection(List<Event> EventList)
        {
            string evCollection = "";
            foreach (Object @object in EventList)
            {
                evCollection += Display(@object);
            }

            return evCollection;
        }

        public static string Display(Object @object)
        {
            switch (@object)
            {
                case Event ev:
                    if (ev.GetType().GetMethod("GetSummaryInformation") != null)
                    {
                        return ev.GetSummaryInformation();
                    }
                    else
                    {
                        return ev.ToString(); // both Event classes have the method....so no dice.
                    }
                case null:
                    throw new ArgumentNullException(nameof(@object));
                default:
                    throw new ArgumentException("Unknown object type", nameof(@object));
            }
        }
    }
}

