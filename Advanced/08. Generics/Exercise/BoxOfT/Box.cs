using System;
using System.Collections.Generic;

namespace BoxOfT
{
    public class Box<T>
    {
        private readonly List<T> data;

        public Box()
        {
            data = new List<T>();
        }

        public void Add(T element)
        {
            data.Add(element);
        }

        public int Count => data.Count;

        public T Remove()
        {
            if (data.Count == 0)
            {
                throw new InvalidOperationException("The box is empty!");
            }

            var lastElement = data[data.Count - 1];
            data.RemoveAt(data.Count - 1);

            return lastElement;
        }
    }
}
