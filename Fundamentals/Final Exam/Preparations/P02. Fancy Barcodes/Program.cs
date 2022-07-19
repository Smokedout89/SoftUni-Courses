using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Fancy_Barcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string barcode = Console.ReadLine();
                Regex pattern = new Regex(@"@#+[A-Z][a-zA-Z0-9]{4,}[A-Z]@#+");

                if (pattern.IsMatch(barcode))
                {
                    string group = string.Empty;

                    char[] digits = barcode.Where(ch => char.IsDigit(ch)).ToArray();

                    if (digits.Length == 0)
                    {
                        Console.WriteLine("Product group: 00");
                    }
                    else
                    {
                        Console.WriteLine($"Product group: {string.Join("", digits)}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
