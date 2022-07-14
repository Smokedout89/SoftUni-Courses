using System;
using System.Linq;

namespace Problem_8___Array_Modifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] token = input.Split();

                if (token[0] == "swap")
                {
                    int indexOne = int.Parse(token[1]);
                    int indexTwo = int.Parse(token[2]);
                    int firstNum = numbers[indexOne];
                    int secondNum = numbers[indexTwo];

                    numbers[indexOne] = secondNum;
                    numbers[indexTwo] = firstNum;
                }
                else if (token[0] == "multiply")
                {
                    int indexOne = int.Parse(token[1]);
                    int indexTwo = int.Parse(token[2]);
                    int firstNum = numbers[indexOne];
                    int secondNum = numbers[indexTwo];
                    int newNum = firstNum * secondNum;
                    numbers[indexOne] = newNum;
                }
                else if (token[0] == "decrease")
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        numbers[i]--;
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
