using System;

namespace StackAndQueue
{
    public class CustomStack
    {
        private const int INITIAL_CAPACITY = 4;
        private int[] data;

        public int Count { get; private set; }

        public CustomStack()
        {
            this.Count = 0;
            this.data = new int[INITIAL_CAPACITY];
        }

        // IMPLEMENTING FIRST METHOD PUSH
        public void Push(int element)
        {
            if (this.Count == data.Length)
            {
                this.ResizeStack();
            }
            this.data[this.Count] = element;
            Count++;
        }

        // IMPLEMENTING PEEK METHOD
        public int Peek()
        {
            CheckForElement();
            int number = data[Count - 1];
            return number;
        }

        // IMPLEMENTING POP METHOD
        public int Pop()
        {
            CheckForElement();
            int number = data[this.Count - 1];
            data[this.Count - 1] = default(int);
            Count--;
            return number;
        }

        public void Clear()
        {
            this.Count = 0;
            this.data = new int[INITIAL_CAPACITY];
        }

        public void ForEach(Action<int> action)
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                action(this.data[i]);
            }
        }

        private void CheckForElement()
        {
            if (this.data.Length == 0)
            {
                throw new ArgumentException("The Stack is empty");
            }
        }
        private void ResizeStack()
        {
            var newData = new int[this.data.Length * 2];
            for (int i = 0; i < this.data.Length; i++)
            {
                newData[i] = this.data[i];
            }

            this.data = newData;
        }
    }
}
