using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNUnitTests.model
{
    class Vehicle
    {
        public String color { get; set; }

        public int wheels { get; set; }

        public Vehicle(String c, int w)
        {
            color = c;
            wheels = w;
        }

        public Boolean isValidColor(String color)
        {
            List<String> validColors = new List<String> { "green", "blue", "white", "black"};
            if (validColors.Contains(color))
                return true;
            return false; 
        }

        public Boolean isValidNumberOfWheels(int wheelCount)
        {
            int wheelMinimum = 2;
            int wheelMaximum = 18;

            if ((wheelCount >= wheelMinimum) && (wheelCount <= wheelMaximum))
                return true; 

            return false; 
        }
    }
}
