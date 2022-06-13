using System;
using System.Collections.Generic;
using System.Linq;

namespace P03._Articles_2._0
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

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ");
                string title = input[0];
                string content = input[1];
                string author = input[2];

                //Article article = new Article(title, content, author);
                //articles.Add(article);

                articles.Add(new Article(title, content, author));
            }

            string typeToSort = Console.ReadLine();

            if (typeToSort == "title")
            {
                articles = articles.OrderBy(t => t.Title).ToList();
            }
            else if (typeToSort == "content")
            {
                articles = articles.OrderBy(c => c.Content).ToList();
            }
            else if (typeToSort == "author")
            {
                articles = articles.OrderBy(a => a.Author).ToList();
            }

            foreach (Article article in articles)
            {
                Console.WriteLine(article);
            }

        }
    }
}
