using System;

namespace _04._Train_The_Trainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfJury = int.Parse(Console.ReadLine());
            string nameOfPresentation = Console.ReadLine();
            int gradeCount = 0;
            double sumOfAllGrades = 0;

            while (nameOfPresentation != "Finish")
            {
                double sumOfGrades = 0;
                for (int i = 1; i <= numOfJury; i++)
                {
                    double grade = double.Parse(Console.ReadLine());
                    sumOfGrades += grade;
                    gradeCount++;
                    sumOfAllGrades += grade;
                }

                double averageForCurrentPresentation = sumOfGrades / numOfJury;
                Console.WriteLine($"{nameOfPresentation} - {averageForCurrentPresentation:f2}.");
                nameOfPresentation = Console.ReadLine();
            }

            double finalAverageGrade = sumOfAllGrades / gradeCount;
            Console.WriteLine($"Student's final assessment is {finalAverageGrade:f2}.");
        }
    }
}
