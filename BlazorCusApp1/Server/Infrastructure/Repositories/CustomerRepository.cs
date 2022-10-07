using BlazorCusApp1.Server.Application;
using BlazorCusApp1.Server.Infrastructure.Models;

namespace BlazorCusApp1.Server.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public CustomerRepository(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Add(Customer customer)
        {
            _applicationDbContext.Customers.Add(customer);
        }

        public void Edit(Customer customer)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 查詢所有 Customers
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Customer> GetAllCustomers()
        {
            return _applicationDbContext.Customers.ToList();
        }

        public string GetCustomerByCustomerID(string customerId)
        {
            var result = _applicationDbContext.Customers
                .Where(c => c.CustomerId.ToLower() == customerId.ToLower())
                .FirstOrDefault();

            string cusName = string.Empty;
            if(result != null)
            {
                cusName = result.ContactName ?? "";
            }
            return cusName;
        }
    }
}
