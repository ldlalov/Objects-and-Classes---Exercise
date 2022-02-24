using System;

namespace _02._Articles
{
    class Article
    {
        public string Title  { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public void Edit(string newContent)
        {
             this.Content = newContent;
        }
        public void ChangeAuthor(string newAuthor)
        {
            this.Author = newAuthor;
        }
        public void Rename (string newTitle)
        {
            this.Title = newTitle;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
           string[] command = Console.ReadLine().Split(", ");
            int n = int.Parse(Console.ReadLine());
            Article article = new Article();
            article.Title = command[0];
            article.Content = command[1];
            article.Author = command[2];
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(": ");
                switch (input[0])
                {
                    case "Edit":
                        article.Edit(input[1]);
                        break;
                    case "ChangeAuthor":
                        article.ChangeAuthor(input[1]);
                        break;
                    case "Rename":
                        article.Rename(input[1]);
                        break;
                }
            }
            Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
        }
    }
}
