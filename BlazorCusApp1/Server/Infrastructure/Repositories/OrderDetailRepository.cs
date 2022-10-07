using BlazorCusApp1.Server.Application;
using BlazorCusApp1.Server.Infrastructure.Models;

namespace BlazorCusApp1.Server.Infrastructure.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public OrderDetailRepository(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<OrderDetail> GetOrderDetails()
        {
            return _applicationDbContext.OrderDetails.ToList();
        }
    }
}
