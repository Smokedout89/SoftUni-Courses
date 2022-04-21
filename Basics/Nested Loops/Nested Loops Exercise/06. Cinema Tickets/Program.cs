using System;

namespace _06._Cinema_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int totalStudentTickets = 0;
            int totalStandartTickets = 0;
            int totalKidsTickets = 0;
            int totalTickets = 0;
            while (input != "Finish")
            {
                    int studentTickets = 0;
                    int standartTickets = 0;
                    int kidsTickets = 0;
                    int freeSpaces = int.Parse(Console.ReadLine());

                for (int i = 0; i < freeSpaces; i++)
                {
                    string ticketType = Console.ReadLine();
                    if (ticketType == "End")
                    {
                        break;
                    }
                    switch (ticketType)
                    {
                        case "student":
                            studentTickets++;
                            break;
                        case "standard":
                            standartTickets++;
                            break;
                        case "kid":
                            kidsTickets++;
                            break;                  
                    }
                }

                totalStudentTickets += studentTickets;
                totalStandartTickets += standartTickets;
                totalKidsTickets += kidsTickets;
                double percantageFull = (studentTickets + standartTickets + kidsTickets) / (double) freeSpaces * 100;
                Console.WriteLine($"{input} - {percantageFull:f2}% full.");
                input = Console.ReadLine();
            }

            totalTickets = totalStudentTickets + totalStandartTickets + totalKidsTickets;
            Console.WriteLine($"Total tickets: {totalTickets}");
            double percentageStudent = totalStudentTickets / (double)totalTickets * 100;
            double percentageStandart = totalStandartTickets / (double)totalTickets * 100;
            double percentageKids = totalKidsTickets / (double)totalTickets * 100;
            Console.WriteLine($"{percentageStudent:f2}% student tickets.");
            Console.WriteLine($"{percentageStandart:f2}% standard tickets.");
            Console.WriteLine($"{percentageKids:f2}% kids tickets.");
        }
    }
}
