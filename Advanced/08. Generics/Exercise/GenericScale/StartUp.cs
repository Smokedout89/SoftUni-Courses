using System;

namespace GenericScale
{
    public class Program
    {
        static void Main(string[] args)
        {
            EqualityScale<string> asd = new EqualityScale<string>("gogi e lich" , "gogi e pich");

            Console.WriteLine(asd.AreEqual());
        }
    }
}
