using System;

namespace _05._Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            const int facebook = 150;
            const int instagram = 100;
            const int reddit = 50;

            int tabsOpen = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());

            for (int i = 0; i < tabsOpen; i++)
            {
                string currentTab = Console.ReadLine();
                if (currentTab == "Facebook")
                {
                    salary -= facebook;
                }
                else if (currentTab == "Instagram")
                {
                    salary -= instagram;
                }
                else if (currentTab == "Reddit")
                {
                    salary -= reddit;
                }
                if (salary <=0)
                {                   
                    break;
                }               
            }
            if (salary <= 0)
            {
                Console.WriteLine("You have lost your salary.");
            }
            else 
            { 
                Console.WriteLine(salary);
            }
                
        }
    }
}
