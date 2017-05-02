using ComicBookGalleryModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Diagnostics;

namespace ComicBookGalleryModel
{
    class Program
    {
        static void Main(string[] args)
        {
            
            using (var context = new Context())
            {

                context.Database.Log = (message) => Debug.WriteLine(message);

                var comicBookId = 1;
                var comicBook1 = context.ComicBooks.Find(comicBookId);
                var comicBook2 = context.ComicBooks.Find(comicBookId);





                //var comicsBooks = context.ComicBooks. 
                //    //Include(cb => cb.Series).
                //    //Include(cb => cb.Artists.Select(a => a.Artist)).
                //    //Include(cb => cb.Artists.Select(a => a.Role)).
                //    ToList();

                //foreach (var comicBook in comicsBooks)
                //{
                //    var artistRoleNames = comicBook.Artists.
                //        Select(a => $"{a.Artist.Name} - {a.Role.Name}").ToList();
                //    var artistRoleDisplayText = string.Join(", ", artistRoleNames);
                //    Console.WriteLine(comicBook.DisplayText);
                //    Console.WriteLine(artistRoleDisplayText);



                //}

                Console.ReadLine();
            }
        }
    }
}
