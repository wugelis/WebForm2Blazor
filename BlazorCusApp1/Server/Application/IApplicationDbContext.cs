using BlazorCusApp1.Server.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorCusApp1.Server.Application
{
    public interface IApplicationDbContext
    {
        DbSet<Customer> Customers { get; set; }

        DbSet<Order> Orders { get; set; }

        DbSet<Product> Products { get; set; }

        DbSet<OrderDetail> OrderDetails { get; set; }

        DbSet<Employee> Employees { get; set; }
        DbSet<Shipper> Shippers { get; }

        int SaveChange();
    }
}
