﻿using ComicBookGalleryModel.Models;
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

                var serie1 = new Series
                {
                    Title = "The amazing Spider Man"
                };
                var serie2 = new Series
                {
                    Title = "The invincible Iron Man"
                };
                var artist1 = new Artist
                {
                    Name = "Stan Lee"
                };
                var artist2 = new Artist
                {
                    Name = "Steve Dikto"
                };
                var artist3 = new Artist
                {
                    Name = "Jack Kirby"
                };

                var role1 = new Role()
                {
                    Name = "Script"
                };
                var role2 = new Role()
                {
                    Name = "Pencil"
                };

                var comicBook1 = new ComicBook { 
                    Series =serie1,
                    IssueNumber = 1,
                    PublishedOn = DateTime.Today
                };

                comicBook1.AddArtist(artist1, role1);
                comicBook1.AddArtist(artist2, role2);


                var comicBook2 = new ComicBook
                {
                    Series = serie1,
                    IssueNumber = 2,
                    PublishedOn = DateTime.Today
                };
                comicBook2.AddArtist(artist1, role1);
                comicBook2.AddArtist(artist2, role2);


                var comicBook3 = new ComicBook
                {
                    Series = serie2,
                    IssueNumber = 1,
                    PublishedOn = DateTime.Today
                };
                comicBook3.AddArtist(artist1, role1);
                comicBook3.AddArtist(artist3, role2);


                context.ComicBooks.Add(comicBook1);
                context.ComicBooks.Add(comicBook2);
                context.ComicBooks.Add(comicBook3);

                context.SaveChanges();

                var comicsBooks = context.ComicBooks.
                    Include(cb => cb.Series).
                    Include(cb => cb.Artists.Select(a=> a.Artist)).
                    Include(cb => cb.Artists.Select(a=> a.Role)).
                    ToList();

                foreach(var comicBook in comicsBooks)
                {
                    //Console.WriteLine("Series Title: " + comicBook.Series.Title);
                    //Console.WriteLine("Issue Number: " + comicBook.IssueNumber);
                    //Console.WriteLine("Published on: " + comicBook.PublishedOn);
                    var artistRoleNames = comicBook.Artists.
                        Select(a => $"{a.Artist.Name} - {a.Role.Name}").ToList();
                    var artistRoleDisplayText = string.Join(", ", artistRoleNames);
                    Console.WriteLine(comicBook.DisplayText);
                    Console.WriteLine(artistRoleDisplayText);



                }

                Console.ReadLine();
            }
        }
    }
}
