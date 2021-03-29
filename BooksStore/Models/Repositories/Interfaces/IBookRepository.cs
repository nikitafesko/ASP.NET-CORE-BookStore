using System.Linq;
using BookStore.Models.Classes;

namespace BookStore.Models.Repositories.Interfaces
{
    public interface IBookRepository
    {
        public IQueryable<Book> Books { get; }

        void SaveBook(Book book);

        Book DeleteBook(int bookId);
    }
}