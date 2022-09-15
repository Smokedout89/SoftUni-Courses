using System;
using System.Collections;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class Lake : IEnumerable<int>
    {
        private readonly List<int> numbers;

        public Lake(List<int> numbers)
        {
            this.numbers = numbers;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (i % 2 == 0)
                {
                    yield return numbers[i];
                }
            }

            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return numbers[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
