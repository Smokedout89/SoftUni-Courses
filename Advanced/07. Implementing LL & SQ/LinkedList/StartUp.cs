using System;

namespace LinkedList
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            CustomDoublyLinkedList<int> list = new CustomDoublyLinkedList<int>();

            list.AddFirst(new Node<int>(1));
            list.AddFirst(new Node<int>(2));
            list.AddFirst(new Node<int>(3));
            list.AddLast(new Node<int>(1));
            list.AddLast(new Node<int>(2));
            list.AddLast(new Node<int>(3));

            list.ForEach(node =>
            {
                Console.WriteLine(node.Value);
            });

            Console.WriteLine($"Removed First: {list.RemoveFirst().Value}");
            Console.WriteLine($"Removed First: {list.RemoveFirst().Value}");

            Console.WriteLine($"Removed Last: {list.RemoveLast().Value}");
            Console.WriteLine($"Removed Last: {list.RemoveLast().Value}");

            Node<int> node = list.Head;

            while (node != null)
            {
                Console.WriteLine(node.Value);
                node = node.Next;
            }   
        }
    }
}
