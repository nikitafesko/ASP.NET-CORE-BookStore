using System.Linq;
using BookStore.Models.Classes;
using BookStore.Models.DbContext;
using BookStore.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Models.Repositories
{
    // ReSharper disable once InconsistentNaming
    public class EFOrderRepository : IOrderRepository
    {
        private ApplicationDbContext context;

        public EFOrderRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Order> Orders =>
            context.Orders.Include(order => order.Lines).ThenInclude(line => line.Book);

        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(line => line.Book));
            if (order.OrderId == 0)
                context.Orders.Add(order);
            context.SaveChanges();
        }
    }
}