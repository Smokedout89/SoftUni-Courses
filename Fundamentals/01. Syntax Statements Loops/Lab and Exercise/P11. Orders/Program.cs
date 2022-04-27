using System;

namespace P11._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double total = 0;
            for (int i = 0; i < n; i++)
            {
                double pricePerCapsule = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int capsuleCount = int.Parse(Console.ReadLine());

                double price = ((days * capsuleCount) * pricePerCapsule);
                total += price;

                Console.WriteLine($"The price for the coffee is: ${price:f2}");
            }

            Console.WriteLine($"Total: ${total:f2}");
        }
    }
}
