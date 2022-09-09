using System;
using System.Collections.Generic;

namespace LinkedList
{
    public class CustomDoublyLinkedList<T>
    {
        public Node<T> Head { get; set; }

        public Node<T> Tail { get; set; }

        public void ForEach(Action<Node<T>> action)
        {
            var node = Head;

            while (node != null)
            {
                action(node);
                node = node.Next;
            }
        }

        public Node<T>[] ToArray()
        {
            List<Node<T>> list = new List<Node<T>>();
            var node = Head;

            while (node != null)
            {
                list.Add(node);
                node = node.Next;
            }

            return list.ToArray();
        }

        public void AddFirst(Node<T> node)
        {
            if (!CheckIfFirstElement(node))
            {
                Node<T> previousHead = Head;
                Head = node;
                previousHead.Previous = Head;
                Head.Next = previousHead;
            }
        }

        public void AddLast(Node<T> node)
        {
            if (!CheckIfFirstElement(node))
            {
                Node<T> previousTail = Tail;
                Tail = node;
                previousTail.Next = Tail;
                Tail.Previous = previousTail;
            }
        }

        public Node<T> RemoveFirst()
        {
            if (Head == null)
            {
                return null;
            }

            var previous = Head;
            var next = Head.Next;

            if (next != null)
            {
                next.Previous = null;
            }
            else
            {
                Tail = null;
            }
            Head = next;

            return previous;
        }

        public Node<T> RemoveLast()
        {
            if (Tail == null)
            {
                return null;
            }

            var previous = Tail;
            var next = Tail.Previous;

            if (next != null)
            {
                next.Next = null;
            }
            else
            {
                Head = null;
            }
            Tail = next;

            return previous;
        }

        private bool CheckIfFirstElement(Node<T> node)
        {
            if (Head == null)
            {
                Head = node;
                Tail = node;
                return true;
            }
            return false;
        }
    }
}
