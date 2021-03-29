using BookStore.Models.Classes;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Components
{
    [ViewComponent]
    public class CartSummary : ViewComponent
    {
        private readonly Cart cart;

        public CartSummary(Cart cartServices)
        {
            this.cart = cartServices;
        }

        public IViewComponentResult Invoke()
        {
            return View(this.cart);
        }
    }
}