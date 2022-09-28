using System;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string type = Console.ReadLine();

                if (type == "Beast!")
                {
                    break;
                }

                string[] cmdInput = Console.ReadLine().Split();
                string name = cmdInput[0];
                int age = int.Parse(cmdInput[1]);

                if (age < 0)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                Animal animal = default;

                if (type == "Cat")
                {
                    animal = new Cat(name, age, cmdInput[2]);
                }
                else if (type == "Dog")
                {
                    animal = new Dog(name, age, cmdInput[2]);
                }
                else if (type == "Frog")
                {
                    animal = new Frog(name, age, cmdInput[2]);
                }
                else if (type == "Tomcat")
                {
                    animal = new Tomcat(name, age);
                }
                else if (type == "Kitten")
                {
                    animal = new Kitten(name, age);
                }

                Console.WriteLine(animal.ToString());
            }
        }
    }
}
