using ComicBookGalleryModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {
                context.ComicBooks.Add(new ComicBook()
                {
                    SeriesTitle = "The amazing Spider Man",
                    IssueNumber = 1,
                    PublishedOn = DateTime.Today
                });
                context.SaveChanges();

                var comicsBooks = context.ComicBooks.ToList();

                foreach(var comicBook in comicsBooks)
                {
                    Console.WriteLine("Series Title: " + comicBook.SeriesTitle);
                    Console.WriteLine("Issue Number: " + comicBook.IssueNumber);
                    Console.WriteLine("Published on: " + comicBook.PublishedOn);
                }

                Console.ReadLine();
            }
        }
    }
}
