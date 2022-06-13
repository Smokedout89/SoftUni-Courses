using System;

namespace P02._Articles
{
    class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public void Edit(string content)
        {
            Content = content;
        }

        public void ChangeAuthor(string author)
        {
            Author = author;
        }

        public void Rename(string title)
        {
            Title = title;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            int n = int.Parse(Console.ReadLine());

            string title = input[0];
            string content = input[1];
            string author = input[2];

            Article article = new Article(title, content, author);

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split(": ");

                string command = cmdArgs[0];
                string newArgs = cmdArgs[1];

                if (command == "Edit")
                {
                    article.Edit(newArgs);
                }
                else if (command == "ChangeAuthor")
                {
                    article.ChangeAuthor(newArgs);
                }
                else if (command == "Rename")
                {
                    article.Rename(newArgs);
                }
            }

            Console.WriteLine(article);
        }
    }
}
