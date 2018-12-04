using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace PatentDataAnalyzer.Tests
{
    [TestClass]
    public class PatentDataAnalyzerTests
    {

        [TestMethod]
        [DataRow("Russia", 0)]
        public void InventorNames_Country_Not_In_Data_List_Returns_Empty_List(string country, int expected)
        {
            Assert.AreEqual(expected, PatentDataAnalyzer.InventorNames(country).Count);
        }


        [TestMethod]
        [DataRow("USA", 6)]
        [DataRow("UK", 1)]
        public void InventorNames_Country_Returns_List_With_Correct_Count(string country, int expected)
        {
            Assert.AreEqual(expected, PatentDataAnalyzer.InventorNames(country).Count);
        }


        [TestMethod]
        [DataRow("Franklin")]
        [DataRow("Wright")]
        [DataRow("Morse")]
        [DataRow("Stephenson")]
        [DataRow("Michaelis")]
        [DataRow("Jacob")]
        public void InventorLastNames_Returns_List_Containing_Expected_Names(string name)
        {
            IEnumerable<string> lastNames = PatentDataAnalyzer.InventorLastNames();
            Assert.IsTrue(lastNames.Contains(name));
        }


        [TestMethod]
        public void InventorLastNames_Returns_List_Reverse_Order_By_Inventor_Id()
        {
            IEnumerable<string> lastNames = PatentDataAnalyzer.InventorLastNames();
            int id = PatentData.Inventors.Length - 1;
            foreach (string name in lastNames)
            {
                Assert.IsTrue(PatentData.Inventors[id].Name.Contains(name));
                id--;
            }
        }


        [TestMethod]
        public void LocationsWithInventors_Returns_Unique_Combinations()
        {
            string result = PatentDataAnalyzer.LocationsWithInventors();
            string[] locations = result.Split(", ");
            List<string> locList = new List<string>(locations);
            foreach (string location in locList)
            {
                Assert.IsTrue(locList.Where(
                    loc => loc != null 
                    && loc.Equals(location)).Count()
                    == 1);
            }
        }

        [TestMethod]
        public void Randomize_Returns_Unique_Order_Three_Times()
        {
            IEnumerable<Inventor> prevList = new List<Inventor>();
            for (int i = 0; i < 3; i++)
            {
                IEnumerable<Inventor> randomizedList =
                    Enumerable.Randomize<Inventor>(PatentData.Inventors);
                Assert.IsFalse(randomizedList.SequenceEqual(PatentData.Inventors));
                Assert.IsFalse(randomizedList.SequenceEqual(prevList));
                prevList = randomizedList;
            }
        }


    }
}
