using BookStore.Models.Classes;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Models.DbContext
{
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}