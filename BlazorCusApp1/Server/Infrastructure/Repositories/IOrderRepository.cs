using BlazorCusApp1.Server.Infrastructure.Models;

namespace BlazorCusApp1.Server.Infrastructure.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrders();
    }
}
