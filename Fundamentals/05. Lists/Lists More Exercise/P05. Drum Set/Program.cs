using System;
using System.Collections.Generic;
using System.Linq;

namespace P05._Drum_Set
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());
            List<double> drums = Console.ReadLine().Split().Select(double.Parse).ToList();
            string hitPower = Console.ReadLine();

            List<double> drumsInitial = new List<double>();
            drumsInitial.AddRange(drums);

            while (hitPower != "Hit it again, Gabsy!")
            {
                double power = double.Parse(hitPower);

                for (int i = 0; i < drums.Count; i++)
                {
                    drums[i] -= power;

                    if (drums[i] <= 0)
                    {
                        if (savings - (drumsInitial[i] * 3) >= 0)
                        {
                            savings -= drumsInitial[i] * 3;
                            drums[i] = drumsInitial[i];
                        }
                    }
                }

                for (int i = 0; i < drums.Count; i++)
                {
                    if (drums[i] <= 0)
                    {
                        drums.Remove(drums[i]);
                        drumsInitial.Remove(drumsInitial[i]);
                    }
                }

                hitPower = Console.ReadLine();
            }

            Console.WriteLine(string.Join(' ', drums));
            Console.WriteLine($"Gabsy has {savings:f2}lv.");
        }
    }
}
