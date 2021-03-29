using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Models.Classes
{
    public class Cart
    {
        private readonly List<CartLine> lineCollection = new List<CartLine>();

        public virtual void AddItem(Book buyingBook, int quantity)
        {
            var line = lineCollection
                .FirstOrDefault(book => book.Book.BookId == buyingBook.BookId);

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Book = buyingBook,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(Book removingBook) =>
            lineCollection.RemoveAll(book => book.Book.BookId == removingBook.BookId);

        public virtual decimal ComputeTotalValue() =>
            lineCollection.Sum(book => book.Book.Price * book.Quantity);

        public virtual void Clear() =>
            lineCollection.Clear();

        public virtual IEnumerable<CartLine> Lines =>
            lineCollection;
    }
}