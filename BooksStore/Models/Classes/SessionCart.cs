using System;
using BookStore.Infrastructure;
using Hanssens.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace BookStore.Models.Classes
{
    public class SessionCart : Cart
    {
        public static Cart GetCart(IServiceProvider services)
        {
            var session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var cart = session?.GetJson<SessionCart>("Cart") ?? new SessionCart();
            cart.Session = session;
            return cart;
        }

        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddItem(Book addBook, int quantity)
        {
            base.AddItem(addBook, quantity);
            Session.SetJson("Cart", this);
        }

        public override void RemoveLine(Book removingBook)
        {
            base.RemoveLine(removingBook);
            Session.SetJson("Cart", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}