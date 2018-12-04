using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatentDataAnalyzer
{
    public static class Enumerable
    {
        // Randomize: Write an IEnumerable<T> extension method on a class called Enumerable<T> 
        // that returns an IEnumerable<T> of the original items in random order. To test execute 
        // the method using LINQ and verify the order is not the same for at least 3 invocations.
        public static IEnumerable<T> Randomize<T>(this IEnumerable<T> collection)
        {
            List<T> items = collection.ToList();
            Random rand = new Random();

            while (items.Any())
            {
                int index = rand.Next(items.Count);
                T item = items[index];
                items.RemoveAt(index);
                yield return item;
            }

        }
    }
}
