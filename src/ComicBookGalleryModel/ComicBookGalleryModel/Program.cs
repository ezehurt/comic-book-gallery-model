using ComicBookGalleryModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ComicBookGalleryModel
{
    class Program
    {
        static void Main(string[] args)
        {
            
            using (var context = new Context())
            {

                var serie = new Series
                {
                    Title = "The amazing Spider Man"
                };
                context.ComicBooks.Add(new ComicBook()
                {
                    Series =serie,
                    IssueNumber = 1,
                    PublishedOn = DateTime.Today
                });
                context.ComicBooks.Add(new ComicBook()
                {
                    Series = serie,
                    IssueNumber = 2,
                    PublishedOn = DateTime.Today
                });
                context.SaveChanges();

                var comicsBooks = context.ComicBooks.
                    Include(cb => cb.Series).
                    ToList();

                foreach(var comicBook in comicsBooks)
                {
                    //Console.WriteLine("Series Title: " + comicBook.Series.Title);
                    //Console.WriteLine("Issue Number: " + comicBook.IssueNumber);
                    //Console.WriteLine("Published on: " + comicBook.PublishedOn);
                    Console.WriteLine(comicBook.DisplayText);

                }

                Console.ReadLine();
            }
        }
    }
}
