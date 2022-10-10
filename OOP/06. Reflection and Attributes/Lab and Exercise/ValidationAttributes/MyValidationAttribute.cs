using System;

namespace ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class MyValidationAttribute : Attribute
    {
        public abstract bool IsValid(object obj);
    }
    
    public class MyRange : MyValidationAttribute
    {
        private readonly int min;
        private readonly int max;

        public MyRange(int min, int max)
        {
            this.min = min;
            this.max = max;
        }

        public override bool IsValid(object obj)
        {
            int currentValue = (int) obj;

            return currentValue >= min && currentValue <= max;
        }
    }

    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj) => obj != null;
    }
}