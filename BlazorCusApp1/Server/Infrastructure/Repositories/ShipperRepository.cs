using BlazorCusApp1.Server.Application;
using BlazorCusApp1.Server.Infrastructure.Models;

namespace BlazorCusApp1.Server.Infrastructure.Repositories
{
    public class ShipperRepository : IShipperRepository
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public ShipperRepository(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Shipper> GetShippers()
        {
            return _applicationDbContext.Shippers.ToList();
        }
    }
}
