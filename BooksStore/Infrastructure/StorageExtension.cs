using BookStore.Models.Classes;
using Hanssens.Net;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BookStore.Infrastructure
{
    public static class StorageExtension
    {
        public static void AddBookToCartInLocalStorage(this LocalStorage storage, string userName, Book book, int quantity)
        {
            storage.Store(userName, new CartLine
            {
                UserName = userName,
                Book = book,
                Quantity = quantity
            });
        }
    }
}