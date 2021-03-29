using System.Linq;
using BookStore.Models.Classes;

namespace BookStore.Models.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }
        void SaveOrder(Order order);
    }
}