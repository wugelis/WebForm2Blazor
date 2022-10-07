using BlazorCusApp1.Server.Application;
using BlazorCusApp1.Server.Infrastructure.Models;

namespace BlazorCusApp1.Server.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public ProductRepository(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _applicationDbContext.Products.ToList();
        }
    }
}
