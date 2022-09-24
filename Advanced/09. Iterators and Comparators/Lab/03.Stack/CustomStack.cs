﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class CustomStack<T> : IEnumerable<T>

    {
        private List<T> myStack;

        public CustomStack()
        {
            this.myStack = new List<T>();
        }

        public int Count { get; private set; } = 0;

        public void Push(T item)
        {
            myStack.Insert(0, item);
            Count++;
        }

        public void Pop()
        {
            if (Count == 0)
            {
                Console.WriteLine("No elements");
                return;
            }

            myStack.RemoveAt(0);
            Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in myStack)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}