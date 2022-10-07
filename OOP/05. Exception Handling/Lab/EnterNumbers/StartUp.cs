using System;
using System.Collections.Generic;

namespace EnterNumbers
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            numbers = ReadNumber(1, 100, numbers);

            Console.WriteLine(string.Join(", ", numbers));
        }

        public static List<int> ReadNumber(int start, int end, List<int> numbers)
        {
            int index = 0;

            while (numbers.Count != 10)
            {
                try
                {
                    int result = 0;

                    bool n = int.TryParse(Console.ReadLine(), out result);

                    if (!n)
                    {
                        throw new ArgumentException();
                    }

                    if (numbers.Count > 0)
                    {
                        if (result < numbers[index - 1])
                        {
                            throw new IndexOutOfRangeException();
                        }
                    }

                    if (result <= 1 || result >= 100)
                    {
                        throw new IndexOutOfRangeException();
                    }

                    numbers.Add(result);
                    index++;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid Number!");
                }
                catch (IndexOutOfRangeException)
                {
                    if (numbers.Count == 0)
                    {
                        Console.WriteLine($"Your number is not in range 1 - 100!");
                    }
                    else
                    {
                        Console.WriteLine($"Your number is not in range {numbers[index - 1]} - 100!");
                    }
                }
            }

            return numbers;
        }
    }
}
