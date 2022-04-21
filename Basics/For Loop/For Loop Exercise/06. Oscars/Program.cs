using System;

namespace _06._Oscars
{
    class Program
    {
        static void Main(string[] args)
        {
            string actorName = Console.ReadLine();
            double pointsFromAcademy = double.Parse(Console.ReadLine());
            int numberOfEvaluators = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfEvaluators; i++)
            {
                string nameOfEvaluator = Console.ReadLine();
                double pointsFromEvaluator = double.Parse(Console.ReadLine());

                pointsFromAcademy += nameOfEvaluator.Length * pointsFromEvaluator / 2;

                if (pointsFromAcademy > 1250.5)
                {
                    break;
                }
            }
            double diff = Math.Abs(1250.5 - pointsFromAcademy);
            if (pointsFromAcademy > 1250.5)
            {
                Console.WriteLine($"Congratulations, {actorName} got a nominee for leading role with {pointsFromAcademy:f1}!");
            }
            else
            {
                Console.WriteLine($"Sorry, {actorName} you need {diff:f1} more!");
            }
        }
    }
}
