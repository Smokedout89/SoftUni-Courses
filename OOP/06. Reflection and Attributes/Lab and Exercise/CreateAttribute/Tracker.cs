using System;
using System.Linq;
using System.Reflection;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type type = typeof(StartUp);

            foreach (var method in type.GetMethods((BindingFlags)(60)))
            {
                object[] attributes = method.GetCustomAttributes(false);

                foreach (var attribute in attributes)
                {
                    AuthorAttribute authorAttributes = attribute as AuthorAttribute;

                    if (authorAttributes != null)
                    {
                        Console.WriteLine($"{method.Name} is written by {authorAttributes.Name}");
                    }
                }
            }

            //MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

            //foreach (var method in methods)
            //{
            //    if (method.CustomAttributes.Any(n => n.AttributeType == typeof(AuthorAttribute)))
            //    {
            //        var attributes = method.GetCustomAttributes(false);

            //        foreach (AuthorAttribute attribute in attributes)
            //        {
            //            Console.WriteLine($"{0} is written by {1}", method.Name, attribute.Name);
            //        }
            //    }
            //}
        }
    }
}