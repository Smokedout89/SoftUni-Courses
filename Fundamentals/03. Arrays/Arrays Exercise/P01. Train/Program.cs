using System;

namespace P01._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int n = int.Parse(Console.ReadLine());
                //int[] passengers = new int[n];
                //int sum = 0;

                //for (int i = 0; i < n; i++)
                //{
                //    int currPass = int.Parse(Console.ReadLine());
                //    sum += currPass;
                //    passengers[i] = currPass;
                //}

                //Console.WriteLine(string.Join(' ', passengers));
                //Console.WriteLine(sum);

                int[] currArr = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
                string minOrMax = Console.ReadLine();
                string oddOrEven = Console.ReadLine();

                int index = -1;
                int min = int.MaxValue;
                int max = int.MinValue;

                int resultOddEven = 1;

                if (oddOrEven == "even") resultOddEven = 0;

                for (int currentIndex = 0; currentIndex < currArr.Length; currentIndex++)
                {
                    if (currArr[currentIndex] % 2 == resultOddEven)
                    {
                        if (minOrMax == "min" && min >= currArr[currentIndex])
                        {
                            min = currArr[currentIndex];
                            index = currentIndex;
                        }
                        else if (minOrMax == "max" && max <= currArr[currentIndex])
                        {
                            max = currArr[currentIndex];
                            index = currentIndex;
                        }
                    }
                }

                Console.WriteLine($"Min: {min} Max: {max} Index : {index}");
        }
    }
}
