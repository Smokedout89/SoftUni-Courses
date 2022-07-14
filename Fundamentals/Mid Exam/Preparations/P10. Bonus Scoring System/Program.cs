using System;

namespace Problem_10___Bonus_Scoring_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int students = int.Parse(Console.ReadLine());
            int numOfLectures = int.Parse(Console.ReadLine());
            int bonus = int.Parse(Console.ReadLine());
            
            double maxBonus = 0;
            int bestStudentLectures = 0;

            for (int i = 0; i < students; i++)
            {
                int currStudentAttendance = int.Parse(Console.ReadLine());

                double currBonus = (double)currStudentAttendance / numOfLectures * (5 + bonus);

                if (currBonus > maxBonus)
                {
                    maxBonus = currBonus;
                    bestStudentLectures = currStudentAttendance;
                }
            }

            Console.WriteLine($"Max Bonus: {Math.Ceiling(maxBonus)}.");
            Console.WriteLine($"The student has attended {bestStudentLectures} lectures.");
        }
    }
}
