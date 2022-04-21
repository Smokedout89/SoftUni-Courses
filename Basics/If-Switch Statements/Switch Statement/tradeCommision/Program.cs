using System;

namespace tradeCommision
{
    class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine();
            double sales = double.Parse(Console.ReadLine());

            double commision = 0;

            switch (town)
            {
                case "Sofia":
                    if (0 <= sales && sales <= 500)
                    {
                        commision = 0.05;
                    }
                    else if (sales > 500 && sales <= 1000)
                    {
                        commision = 0.07;
                    }
                    else if (sales > 1000 && sales <= 10000)
                    {
                        commision = 0.08;
                    }
                    else if (sales > 10000)
                    {
                        commision = 0.12;
                    }
                    break;

                case "Varna":
                    if (0 <= sales && sales <= 500)
                    {
                        commision = 0.045;
                    }
                    else if (sales > 500 && sales <= 1000)
                    {
                        commision = 0.075;
                    }
                    else if (sales > 1000 && sales <= 10000)
                    {
                        commision = 0.1;
                    }
                    else if (sales > 10000)
                    {
                        commision = 0.13;
                    }
                    break;

                case "Plovdiv":
                    if (0 <= sales && sales <= 500)
                    {
                        commision = 0.055;
                    }
                    else if (sales > 500 && sales <= 1000)
                    {
                        commision = 0.08;
                    }
                    else if (sales > 1000 && sales <= 10000)
                    {
                        commision = 0.12;
                    }
                    else if (sales > 10000)
                    {
                        commision = 0.145;
                    }
                    break;           
            }

            double total = sales * commision;

            if (sales < 0 || town != "Sofia" && town != "Varna" && town != "Plovdiv")
            {
                Console.WriteLine("error");
            }
            else
            {
                Console.WriteLine($"{total:f2}");
            }
        }
    }

}
