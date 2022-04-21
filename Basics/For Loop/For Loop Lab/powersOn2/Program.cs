using System;

namespace powersOn2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            //int num = 1;
            //for (int i = 0; i <= n; i+=2)
            //{              
            //    Console.WriteLine(num);
            //    num = num * 2 * 2;
            //}
            for (int power = 0; power <= n; power+=2)
            {
                Console.WriteLine(Math.Pow(2, power));
            }
         }
    }
}
