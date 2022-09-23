using System;
using System.Linq;
using System.Collections.Generic;

namespace Scheduling
{
    internal class Scheduling
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            Queue<int> threads = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            int taskToKill = int.Parse(Console.ReadLine());
            bool taskKilled = false;
            int taskKiller = 0;

            while (!taskKilled)
            {
                int currentTask = tasks.Peek();
                int currentThread = threads.Peek();

                if (currentTask == taskToKill)
                {
                    taskKilled = true;
                    taskKiller = currentThread;
                    break;
                }

                if (currentThread >= currentTask)
                {
                    tasks.Pop();
                    threads.Dequeue();
                }
                else
                {
                    threads.Dequeue();
                }
            }

            Console.WriteLine($"Thread with value {taskKiller} killed task {taskToKill}");
            Console.WriteLine($"{string.Join(' ',threads)}");
        }
    }
}
