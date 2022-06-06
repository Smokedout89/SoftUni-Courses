using System;
using System.Linq;
using System.Collections.Generic;

namespace P10._SoftUni_Course_Planning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> initialLessons = Console.ReadLine().Split(", ").ToList();
            string[] cmdArgs = Console.ReadLine().Split(':').ToArray();

            while (cmdArgs[0] != "course start")
            {
                string command = cmdArgs[0];
                string lessonTitle = cmdArgs[1];

                if (command == "Add")
                {
                    if (!initialLessons.Contains(lessonTitle))
                    {
                        initialLessons.Add(lessonTitle);
                    }
                }
                else if (command == "Insert")
                {
                    int indexToInsert = int.Parse(cmdArgs[2]);

                    if (!initialLessons.Contains(lessonTitle))
                    {

                        if (indexToInsert < initialLessons.Count && indexToInsert >= 0)
                        {
                            initialLessons.Insert(indexToInsert, lessonTitle);
                        }
                    }
                }
                else if (command == "Remove")
                {
                    initialLessons.Remove(lessonTitle);
                    initialLessons.Remove($"{lessonTitle}-Exercise");
                }
                else if (command == "Swap")
                {
                    string lessonToSwapWith = cmdArgs[2];
                    int firstLessonIndex = initialLessons.IndexOf(lessonTitle);
                    int secondLessonIndex = initialLessons.IndexOf(lessonToSwapWith);

                    if (firstLessonIndex != -1 && secondLessonIndex != -1)
                    {
                        initialLessons[firstLessonIndex] = lessonToSwapWith;
                        initialLessons[secondLessonIndex] = lessonTitle;

                        if (firstLessonIndex + 1 < initialLessons.Count && initialLessons[firstLessonIndex + 1] == $"{lessonTitle}-Exercise")
                        {
                            initialLessons.RemoveAt(firstLessonIndex + 1);
                            firstLessonIndex = initialLessons.IndexOf(lessonTitle);
                            initialLessons.Insert(firstLessonIndex + 1, $"{lessonTitle}-Exercise");
                        }

                        if (secondLessonIndex + 1 < initialLessons.Count && initialLessons[secondLessonIndex + 1] == $"{lessonToSwapWith}-Exercise")
                        {
                            initialLessons.RemoveAt(secondLessonIndex + 1);
                            secondLessonIndex = initialLessons.IndexOf(lessonToSwapWith);
                            initialLessons.Insert(secondLessonIndex + 1, $"{lessonToSwapWith}-Exercise");
                        }
                    }
                }
                else if (command == "Exercise")
                {
                    int index = initialLessons.IndexOf(lessonTitle);

                    if (initialLessons.Contains(lessonTitle) && !initialLessons.Contains($"{lessonTitle}-Exercise"))
                    {
                        initialLessons.Insert(index + 1, $"{lessonTitle}-Exercise");
                    }
                    else if (!initialLessons.Contains(lessonTitle))
                    {
                        initialLessons.Add(lessonTitle);
                        initialLessons.Add($"{lessonTitle}-Exercise");
                    }
                }

                cmdArgs = Console.ReadLine().Split(':').ToArray();
            }

            for (int i = 0; i < initialLessons.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{initialLessons[i]}");
            }
        }
    }
}
