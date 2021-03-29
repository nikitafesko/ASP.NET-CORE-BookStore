using System.Linq;
using BookStore.Models.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BookStore.Models.Classes;
using BookStore.Models.ViewModels;

namespace BookStore.Controllers
{
    public class CartController : Controller
    {
        private readonly IBookRepository repository;
        private readonly Cart cart;

        public CartController(IBookRepository repository, Cart cartService)
        {
            this.repository = repository;
            this.cart = cartService;
        }

        public ViewResult Index(string returnUrl) =>
            View(new CartIndexViewModel
            {
                Cart = this.cart,
                ReturnUrl = returnUrl
            });

        public RedirectToActionResult AddToCart(int bookId, string returnUrl)
        {
            var book = repository.Books
                .FirstOrDefault(item => item.BookId == bookId);
            if (book == null) return RedirectToAction("Index", new {returnUrl});
            
            this.cart.AddItem(book, 1);

            return RedirectToAction("Index", new {returnUrl});
        }

        public RedirectToActionResult RemoveFromCart(int bookId, string returnUrl)
        {
            var book = repository.Books
                .FirstOrDefault(item => item.BookId == bookId);
            if (book == null) return RedirectToAction("Index", new {returnUrl});
            
            this.cart.RemoveLine(book);

            return RedirectToAction("Index", new {returnUrl});
        }
    }
}