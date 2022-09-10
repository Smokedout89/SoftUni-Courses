using System;

namespace StackAndQueue
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var list = new CustomList(3);

            // Second step to add to the list to implement •void Add(int element) 

            list.Add(5);
            Console.WriteLine($"Adding element {list[0]}");
            list.Add(6);
            Console.WriteLine($"Adding element {list[1]}");
            list.Add(69);
            Console.WriteLine($"Adding element {list[2]}");
            list.Add(6);
            Console.WriteLine($"Adding element {list[3]}");
            Console.WriteLine($"List initial count after adding elements {list.Count}");
            int removedItem = list.RemoveAt(2);
            Console.WriteLine($"Removed element {removedItem} at index 2");
            Console.WriteLine($"List count after removing element {list.Count}");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"current element {list[i]}");
            }

            Console.WriteLine($"is number 69 on the list {list.Contains(69)}");
            Console.WriteLine($"is number 6 on the list {list.Contains(6)}");

            Console.WriteLine($"Testing Clear method");
            list.Clear();
            Console.WriteLine($"List count after clear method {list.Count}");

            // TESTING THE INSERT METHOD
            var testInsert = new CustomList();
            testInsert.Add(1);
            testInsert.Add(2);
            testInsert.Insert(1, 5);
            Console.WriteLine($"Inserted number at index 1 is now {testInsert[1]}");
            for (int i = 0; i < testInsert.Count; i++)
            {
                Console.Write($"{testInsert[i]} ");
            }

            Console.WriteLine();

            // TESTING THE SWAP METHOD
            var swapTest = new CustomList();
            swapTest.Add(1);
            swapTest.Add(2);
            Console.WriteLine($"Swap test ELEMENTS");
            for (int i = 0; i < swapTest.Count; i++)
            {
                Console.Write($"{swapTest[i]} ");
            }

            Console.WriteLine();
            Console.WriteLine($"After Swap method");
            swapTest.Swap(0, 1);
            for (int i = 0; i < swapTest.Count; i++)
            {
                Console.Write($"{swapTest[i]} ");
            }

            Console.WriteLine();
            Console.WriteLine("TESTING OF STACK");
            Console.WriteLine();
            // ===================================STACK===========================
            Console.WriteLine("-----------------------------STACK-----------------------");
            var stack = new CustomStack();
            stack.Push(10);
            stack.Push(20);
            Console.WriteLine(stack.Count);
            Console.WriteLine(stack.Peek());
            int popedItem = stack.Pop();
            Console.WriteLine(popedItem);
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Count);

            var newStack = new CustomStack();
            for (int i = 0; i <= 10; i++)
            {
                newStack.Push(i);
            }

            newStack.ForEach(n => Console.WriteLine($"number: {n}"));
        }
    }
}
