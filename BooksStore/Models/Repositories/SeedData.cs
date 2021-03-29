using System.Linq;
using BookStore.Models.Classes;
using BookStore.Models.DbContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Models.Repositories
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder applicationBuilder)
        {
            var context = applicationBuilder.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();

            if (context.Books.Any())
                return;

            context.Books.AddRange(
                new Book
                {
                    Author = "Author 1",
                    Category = "Category 1",
                    CoverType = "Cover Type 1",
                    Description = "Description 1",
                    Language = "Language 1",
                    Name = "Book 1",
                    PagesCount = 1000,
                    Price = 1000M,
                    Publisher = "Publisher 1",
                    Year = "1991"
                },
                new Book
                {
                    Author = "Author 2",
                    Category = "Category 2",
                    CoverType = "Cover Type 2",
                    Description = "Description 2",
                    Language = "Language 2",
                    Name = "Book 2",
                    PagesCount = 2000,
                    Price = 2000M,
                    Publisher = "Publisher 2",
                    Year = "1992"
                },
                new Book
                {
                    Author = "Author 3",
                    Category = "Category 3",
                    CoverType = "Cover Type 3",
                    Description = "Description 3",
                    Language = "Language 3",
                    Name = "Book 3",
                    PagesCount = 3000,
                    Price = 3000M,
                    Publisher = "Publisher 3",
                    Year = "1993"
                }
            );

            context.SaveChanges();

        }
    }
}