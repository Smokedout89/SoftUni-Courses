using System;

namespace P01._Extract_Person_Information
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                int firstIndex = input.IndexOf('@');
                int secondIndex = input.IndexOf('|');
                int firstLength = secondIndex - firstIndex - 1;
                int thirdIndex = input.IndexOf('#');
                int forthIndex = input.IndexOf('*');
                int secondLenght = forthIndex - thirdIndex - 1;

                string name = input.Substring(firstIndex + 1, firstLength);
                string age = input.Substring(thirdIndex + 1, secondLenght);

                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}
