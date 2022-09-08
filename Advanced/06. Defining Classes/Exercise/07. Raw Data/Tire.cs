using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Tire
    {
        public Tire(int age, double pressure)
        {
            this.TireAge = age;
            this.TirePressure = pressure;
        }
        public int TireAge { get; set; }

        public double TirePressure { get; set; }
    }
}
