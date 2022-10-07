using BlazorCusApp1.Server.Application;
using BlazorCusApp1.Server.Infrastructure.Models;

namespace BlazorCusApp1.Server.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public EmployeeRepository(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _applicationDbContext.Employees.ToList();
        }
    }
}
