using System;

namespace _07.Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] nameAdress = Console.ReadLine().Split();
            string fullName = $"{nameAdress[0]} {nameAdress[1]}";
            string address = nameAdress[2];

            string[] nameBeer = Console.ReadLine().Split();
            string name = nameBeer[0];
            int beer = int.Parse(nameBeer[1]);

            string[] numberInput = Console.ReadLine().Split();
            int intNum = int.Parse(numberInput[0]);
            double doubleNum = double.Parse(numberInput[1]);

            Tuple<string, string> firstTuple = new Tuple<string, string>(fullName, address);
            Tuple<string, int> secondTuple = new Tuple<string, int>(name, beer);
            Tuple<int, double> thirdTuple = new Tuple<int, double>(intNum, doubleNum);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
