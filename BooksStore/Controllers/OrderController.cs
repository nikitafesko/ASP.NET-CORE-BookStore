using System.Collections.Generic;
using System.Linq;
using BookStore.Models.Classes;
using BookStore.Models.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{    
    public class OrderController : Controller
    {
        private readonly IOrderRepository repository;

        private readonly Cart cart;

        public OrderController(IOrderRepository repositoryService, Cart cartService)
        {
            this.repository = repositoryService;
            this.cart = cartService;
        }

        [Authorize]
        public ViewResult List()
        {
            if (User.IsInRole("storekeeper"))
                return View("ListForStorekeeper",
                    repository.Orders.Where(order => order.Status != OrderStatus.Delivered));
            return View("ListForUser", repository.Orders.Where(order => order.Name.Equals(User.Identity.Name)));
        }

        [HttpPost]
        [Authorize(Roles = "storekeeper")]
        public IActionResult MarkAdopted(int orderId)
        {
            var order = repository.Orders.FirstOrDefault(item => item.OrderId == orderId);
            if (order == null) return RedirectToAction(nameof(List));
            if (order.Lines.Any(orderLine => orderLine.Book.Count < orderLine.Quantity))
            {
                return RedirectToAction(nameof(List));
            }

            foreach (var orderLine in order.Lines)
            {
                orderLine.Book.Count -= (uint)orderLine.Quantity;
            }

            order.Status = OrderStatus.Adopted;
            repository.SaveOrder(order);

            return RedirectToAction(nameof(List));
        }

        [HttpPost]
        [Authorize]
        public IActionResult MarkRejected(int orderId)
        {
            var order = repository.Orders.FirstOrDefault(item => item.OrderId == orderId);
            if (order == null) return RedirectToAction(nameof(List));

            order.Status = OrderStatus.Rejected;
            repository.SaveOrder(order);

            return RedirectToAction(nameof(List));
        }

        [HttpPost]
        [Authorize]
        public IActionResult ReturnRequest(int orderId)
        {
            var order = repository.Orders.FirstOrDefault(item => item.OrderId == orderId);
            if (order == null) 
                return RedirectToAction(nameof(List));
            
            return View("ReturnRequest", order);
        }

        [HttpPost]
        [Authorize]
        public IActionResult ReturnRequestSubmit(int orderId, Dictionary<int, int> counts)
        {
            var order = repository.Orders.FirstOrDefault(item => item.OrderId == orderId);
            if (order == null)
                return RedirectToAction(nameof(List));

            foreach (var line in order.Lines)
            {
                if (line.Quantity < counts[line.Book.BookId])
                {
                    return null;
                }
            }
            return null;
        }

        public ViewResult Checkout() =>
            View(new Order());

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (!cart.Lines.Any())
                ModelState.AddModelError("", "Sorry, your cart is empty!");

            if (!ModelState.IsValid) return View(order);

            order.Lines = cart.Lines.ToArray();
            repository.SaveOrder(order);

            return RedirectToAction(nameof(Completed));
        }

        public ViewResult Completed()
        {
            cart.Clear();
            return View();
        }
    }
}