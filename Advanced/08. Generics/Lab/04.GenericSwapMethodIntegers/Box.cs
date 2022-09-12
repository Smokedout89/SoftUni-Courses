using System.Collections.Generic;
using System.Text;

namespace _04.GenericSwapMethodIntegers
{
    public class Box<T>
    {
        public Box(T element)
        {
            Element = element;
        }

        public Box(List<T> elementsList)
        {
            Elements = elementsList;
        }

        public T Element { get; }

        public List<T> Elements { get; }

        public void Swap(List<T> elements, int indexOne, int indexTwo)
        {
            T firstElement = elements[indexOne];
            elements[indexOne] = elements[indexTwo];
            elements[indexTwo] = firstElement;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var element in Elements)
            {
                sb.AppendLine($"{element.GetType()}: {element}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
