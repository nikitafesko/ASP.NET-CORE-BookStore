using System.Linq;
using BookStore.Models.Classes;

namespace BookStore.Infrastructure
{
    public static class OrderByExtension
    {
        public static IQueryable<Book> ParametrizeOrderBy(this IQueryable<Book> listQueryableBooks, string sortType)
        {
            if (string.IsNullOrEmpty(sortType))
                return listQueryableBooks.OrderBy(book => book.BookId);

            return sortType switch
            {
                "byName" => listQueryableBooks.OrderBy(book => book.Name),
                "byNameDesc" => listQueryableBooks.OrderByDescending(book => book.Name),
                "byAuthor" => listQueryableBooks.OrderBy(book => book.Author),
                "byAuthorDesc" => listQueryableBooks.OrderByDescending(book => book.Author),
                "byPublisher" => listQueryableBooks.OrderBy(book => book.Publisher),
                "byPublisherDesc" => listQueryableBooks.OrderByDescending(book => book.Publisher),
                "byYear" => listQueryableBooks.OrderBy(book => book.Year),
                "byYearDesc" => listQueryableBooks.OrderByDescending(book => book.Year),
                "byPrice" => listQueryableBooks.OrderBy(book => book.Price),
                "byPriceDesc" => listQueryableBooks.OrderByDescending(book => book.Price),
                _ => listQueryableBooks.OrderBy(book => book.BookId)
            };
        }
    }
}