using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Topping
    {
        Dictionary<string, double> toppingModifiers = new Dictionary<string, double>()
        {
            { "meat", 1.2},
            { "veggies", 0.8},
            { "cheese", 1.1},
            { "sauce", 0.9}
        };

        private string toppingType;
        private double toppingWeight;

        public Topping(string toppingType, double toppingWeight)
        {
            ToppingType = toppingType;
            ToppingWeight = toppingWeight;
        }

        public string ToppingType
        {
            get { return toppingType; }

            private set
            {
                if (!toppingModifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                toppingType = value;
            }
        }

        public double ToppingWeight
        {
            get { return toppingWeight; }

            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{ToppingType} weight should be in the range [1..50].");
                }

                toppingWeight = value;
            }
        }

        public double Calories => 2 * ToppingWeight * toppingModifiers[ToppingType.ToLower()];
    }
}
