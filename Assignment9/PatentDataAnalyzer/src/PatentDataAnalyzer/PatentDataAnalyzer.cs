using System;
using System.Collections.Generic;
using System.Linq;

namespace PatentDataAnalyzer
{
    public static class PatentDataAnalyzer
    {

        // InventorNames: Return a list of the inventor names from the specified country 
        // where the country is specified as a parameter.
        public static List<string> InventorNames(string country)
        {
            if (country == null) throw new ArgumentNullException(nameof(country));

            IEnumerable<string> inventors =
                from inventor in PatentData.Inventors
                where inventor.Country.Equals(country)
                select inventor.Name;
            return new List<string>(inventors);
        }


        // InventorLastNames: Returns the only the last name of each of the inventor 
        // sorted in reverse order by inventor Id.       
        public static IEnumerable<string> InventorLastNames()
        {
            IEnumerable<string> inventorLastNames =
                from inventor in PatentData.Inventors
                let lastName = inventor.Name.Split().Last()
                orderby inventor.Id descending
                select lastName;
            return inventorLastNames;
        }


        // LocationsWithInventors: Returns a single comma separated list of all the 
        // unique "-" (where you list the unique state and country combinations with 
        // a dash between the state and the country) strings for each inventor. The 
        // result should be a scalar value of type string, not a collection (other than 
        // the fact that a string is a collection of characters). E.g. NC-USA, PA-USA, NY, etc.
        public static string LocationsWithInventors()
        {
            return string.Join(", ",
                (from inventor in PatentData.Inventors
                select $"{inventor.State}-{inventor.Country}")
                .Distinct());
        }


        public static void Main(string[] args)
        {
            
        }
    }
}
