using System;

namespace _07._Trekking_Mania
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfGroups = int.Parse(Console.ReadLine());
            int group1 = 0;
            int group2 = 0;
            int group3 = 0;
            int group4 = 0;
            int group5 = 0;

            for (int i = 0; i < numberOfGroups; i++)
            {
                int climbersCount = int.Parse(Console.ReadLine());

                if (climbersCount < 6)
                {
                    group1 += climbersCount;
                }
                else if (climbersCount < 13)
                {
                    group2 += climbersCount;
                }
                else if (climbersCount < 26)
                {
                    group3 += climbersCount;
                }
                else if (climbersCount < 41)
                {
                    group4 += climbersCount;
                }
                else
                {
                    group5 += climbersCount;
                }
            }

            int totalPeople = group1 + group2 + group3 + group4 + group5;
            double percentsGroup1 = (double)group1 / totalPeople * 100;
            double percentsGroup2 = (double)group2 / totalPeople * 100;
            double percentsGroup3 = (double)group3 / totalPeople * 100;
            double percentsGroup4 = (double)group4 / totalPeople * 100;
            double percentsGroup5 = (double)group5 / totalPeople * 100;

            Console.WriteLine($"{percentsGroup1:f2}%");
            Console.WriteLine($"{percentsGroup2:f2}%");
            Console.WriteLine($"{percentsGroup3:f2}%");
            Console.WriteLine($"{percentsGroup4:f2}%");
            Console.WriteLine($"{percentsGroup5:f2}%");
        }
    }
}
