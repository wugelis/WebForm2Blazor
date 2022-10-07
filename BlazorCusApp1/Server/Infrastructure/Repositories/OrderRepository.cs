using BlazorCusApp1.Server.Application;
using BlazorCusApp1.Server.Infrastructure.Models;

namespace BlazorCusApp1.Server.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public OrderRepository(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IEnumerable<Order> GetOrders()
        {
            return _applicationDbContext.Orders.ToList();
        }
    }
}
