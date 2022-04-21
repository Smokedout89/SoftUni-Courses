using System;

namespace _02._Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int badGrades = int.Parse(Console.ReadLine());
            int badGradesCounter = 0;
            string task = Console.ReadLine();
            string lastTask = "";
            double totalGrades = 0;
            double sumOfGrades = 0;

            while (task != "Enough")
            {
                int grade = int.Parse(Console.ReadLine());
                totalGrades ++;
                sumOfGrades += grade;
                if (grade <= 4)                   
                {
                    badGradesCounter++;
                    if (badGradesCounter == badGrades)
                    {
                        break;
                    }                   
                }                           
                lastTask = task;
                task = Console.ReadLine();
            }
            if (task == "Enough")
            {
                double averageGrade = sumOfGrades/totalGrades;
                Console.WriteLine($"Average score: {averageGrade:f2}");
                Console.WriteLine($"Number of problems: {totalGrades}");
                Console.WriteLine($"Last problem: {lastTask}");
            }
            else
            {
                Console.WriteLine($"You need a break, {badGradesCounter} poor grades.");
            }
        }
    }
}
