using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Articles_2._0
{
    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
        public void Edit(string newContent)
        {
            this.Content = newContent;
        }
        public void ChangeAuthor(string newAuthor)
        {
            this.Author = newAuthor;
        }
        public void Rename(string newTitle)
        {
            this.Title = newTitle;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Article> articles = new List<Article>();
            int numberOfArticles = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfArticles; i++)
            {
                string[] command = Console.ReadLine().Split(", ");
                Article article = new Article();
                article.Title = command[0];
                article.Content = command[1];
                article.Author = command[2];
                articles.Add(article);
            }
            string filter = Console.ReadLine();
            List<Article> orderedArticles = new List<Article>();
            switch (filter)
            {
                case "title":
                    orderedArticles = articles.OrderBy(article => article.Title).ToList();
                    break;
                case "content":
                    orderedArticles = articles.OrderBy(article => article.Content).ToList();
                    break;
                case "author":
                    orderedArticles = articles.OrderBy(article => article.Author).ToList();
                    break;
            }
            foreach (Article article in articles)  //Changed because changing the condition in Judge. Use orderedSrticles if they change it again. 
            {
                Console.WriteLine($"{article}");
            }
        }
    }
}
