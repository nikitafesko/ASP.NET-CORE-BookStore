using System.Linq;
using BookStore.Models.Classes;
using BookStore.Models.DbContext;
using BookStore.Models.Repositories.Interfaces;

namespace BookStore.Models.Repositories
{
    // ReSharper disable once InconsistentNaming
    public class EFBookRepository : IBookRepository
    {
        private readonly ApplicationDbContext context;

        public EFBookRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Book> Books =>
            context.Books;

        public void SaveBook(Book book)
        {
            if (book.BookId == 0)
            {
                context.Books.Add(book);
            }
            else
            {
                var dbEntry = context.Books.FirstOrDefault(item => item.BookId == book.BookId);
                if (dbEntry == null) return;

                dbEntry.Name = book.Name;
                dbEntry.Author = book.Author;
                dbEntry.Publisher = book.Publisher;
                dbEntry.Year = book.Year;
                dbEntry.CoverType = book.CoverType;
                dbEntry.PagesCount = book.PagesCount;
                dbEntry.Language = book.Language;
                dbEntry.Description = book.Description;
                dbEntry.Category = book.Category;
                dbEntry.Price = book.Price;
            }

            context.SaveChanges();
        }

        public Book DeleteBook(int bookId)
        {
            var dbEntry = context.Books.FirstOrDefault(book => book.BookId == bookId);
            if (dbEntry == null) return null;

            context.Books.Remove(dbEntry);
            context.SaveChanges();

            return dbEntry;
        }
    }
}