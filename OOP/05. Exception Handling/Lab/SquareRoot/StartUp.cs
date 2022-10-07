using System;

namespace SquareRoot
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            try
            {
                if (n < 0)
                {
                    throw new ArgumentException();
                }
                else
                {
                    Console.WriteLine(Math.Sqrt(n));
                }

            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid number.");
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}
