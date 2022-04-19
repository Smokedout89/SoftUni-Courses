using System;

namespace _04._Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfStudents = int.Parse(Console.ReadLine());

            double topStudents = 0;
            double averageStudents = 0;
            double lowerStudents = 0;
            double failedStudents = 0;
            double averageGradeCounter = 0;

            for (int i = 0; i < numOfStudents; i++)
            {
                double result = double.Parse(Console.ReadLine());
                averageGradeCounter += result;
                if (result >= 5.00)
                {
                    topStudents++;
                }
                else if (result >= 4 && result <= 4.99)
                {
                    averageStudents++;
                }
                else if (result >= 3 && result <= 3.99)
                {
                    lowerStudents++;
                }
                else
                {
                    failedStudents++;
                }
            }
            double averageGrade = averageGradeCounter / numOfStudents;
            double topPercentage = topStudents / numOfStudents * 100;
            double averagePercentage = averageStudents / numOfStudents * 100;
            double lowerPercentage = lowerStudents / numOfStudents * 100;
            double failedPercentage = failedStudents / numOfStudents * 100;

            Console.WriteLine($"Top students: {topPercentage:f2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {averagePercentage:f2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {lowerPercentage:f2}%");
            Console.WriteLine($"Fail: {failedPercentage:f2}%");
            Console.WriteLine($"Average: {averageGrade:f2}");
        }
    }
}
