using System;
using System.Collections.Generic;

namespace UniversityCourse
{

    public static class DisplayCourse
    {
        public static string DisplayEvents(List<Event> EventList)
	    {

            // uses polymorphism to retrieve the summary information for
            // a collection of events/courses

            // use switch statement with pattern matching to call GetSummaryInformation()
            // method if it exists or call ToString() if it doesn't
            // The invocation of GetSummaryInformation() should be polymorphic

            foreach (Object @object in EventList)
            {
                Display(@object);
            }
            return "";
	    }

        public static string Display(Object @object)
        {
            return "";
        }
    }


}
