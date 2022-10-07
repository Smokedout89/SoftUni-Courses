using System;

namespace SumofIntegers
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int sum = 0;

            foreach (var item in input)
            {
                int min = int.MinValue;
                int max = int.MaxValue;

                try
                {
                    bool isNum = long.TryParse(item, out long result);

                    if (!isNum)
                    {
                        throw new FormatException($"The element '{item}' is in wrong format!");
                    }

                    if (isNum && result <= min || result >= max)
                    {
                        throw new OverflowException($"The element '{result}' is out of range!");
                    }

                    sum += (int)result;
                }
                catch (OverflowException oe)
                {
                    Console.WriteLine(oe.Message);
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
                finally
                {
                    Console.WriteLine($"Element '{item}' processed - current sum: {sum}");
                }             
            }

            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}
