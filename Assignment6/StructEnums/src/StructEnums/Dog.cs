using System;
using System.Collections.Generic;
using System.Text;

namespace StructEnums
{
    public class Dog
    {
        public Dog(string name, string color, string toy, int weight)
        {
            Name = name;
            Color = color;
            Weight = weight;
            Toy = toy;
        }

        public string Name { get; set; }
        public string Color { get; set; }
        public string Toy { get; set; }
        public int Weight { get; set; }


    }

}
