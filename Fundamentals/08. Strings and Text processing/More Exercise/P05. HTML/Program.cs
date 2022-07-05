using System;

namespace P05._HTML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string articleTitle = Console.ReadLine();
            string articleContent = Console.ReadLine();
            string comments = Console.ReadLine();

            PrintTitle(articleTitle);
            PrintContent(articleContent);

            while (comments != "end of comments")
            {

                foreach (var comment in comments)
                {
                    PrintComment(comments);
                    break;
                }

                comments = Console.ReadLine();
            }
        }

        static void PrintTitle(string title)
        {
            Console.WriteLine("<h1>");
            Console.WriteLine($"\t {title}");
            Console.WriteLine("</h1>");
        }

        static void PrintContent(string content)
        {
            Console.WriteLine("<article>");
            Console.WriteLine($"\t {content}");
            Console.WriteLine("</article>");
        }

        static void PrintComment(string comment)
        {
            Console.WriteLine("<div>");
            Console.WriteLine($"\t {comment}");
            Console.WriteLine("</div>");
        }
    }
}
