using BlazorCusApp1.Server.Infrastructure.Models;

namespace BlazorCusApp1.Server.Infrastructure.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
    }
}