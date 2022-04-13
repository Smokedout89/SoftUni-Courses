using System;

namespace _08._Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();           
            int group = 1;
            double gradeSum = 0;
            int failCounter = 0;
            while (group <= 12)
            {
                double grade = double.Parse(Console.ReadLine());                         
                if (grade < 4)
                {
                    failCounter++;
                    if (failCounter == 2)
                    {
                        Console.WriteLine($"{name} has been excluded at {group} grade");
                        break;
                    }
                    continue;
                }               
                     gradeSum += grade;            
                     group++;
            }
            double averageGrade = gradeSum / 12;
            if (failCounter < 2)
            {
                Console.WriteLine($"{name} graduated. Average grade: {averageGrade:f2}");
            }
            
        }
    }
}
