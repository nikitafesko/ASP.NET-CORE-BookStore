using BookStore.Models.Classes;
using Hanssens.Net;

namespace BookStore.Models.ViewModels
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}