using System;
using System.Linq;
using System.Collections.Generic;

namespace Birthday_Celebration
{
    internal class BirthdayCelebration
    {
        static void Main(string[] args)
        {
            List<int> guests = new List<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> plates = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int wastedGrams = 0;

            while (plates.Count > 0 && guests.Count > 0)
            {
                int currentGuest = guests[0];
                int currentPlate = plates.Pop();

                if (currentPlate >= currentGuest)
                {
                    wastedGrams += currentPlate - currentGuest;
                    guests.RemoveAt(0);
                }
                else
                {
                    guests[0] -= currentPlate;
                }
            }

            if (guests.Count > 0)
            {
                Console.WriteLine($"Guests: {string.Join(' ', guests)}");
            }
            else
            {
                Console.WriteLine($"Plates: {string.Join(' ', plates)}");
            }

            Console.WriteLine($"Wasted grams of food: {wastedGrams}");
        }
    }
}
