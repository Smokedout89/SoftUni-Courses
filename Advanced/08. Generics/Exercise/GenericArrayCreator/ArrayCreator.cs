namespace GenericArrayCreator
{
    public class ArrayCreator
    {
        public static T[] Create<T>(int length, T element)
        {
            var result = new T[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = element;
            }

            return result;
        }
    }
}
