using BlazorCusApp1.Server.Application;

namespace BlazorCusApp1.Server.Infrastructure.Models
{
    public class ApplicationDbContext : NorthwindContext, IApplicationDbContext
    {
        public int SaveChange()
        {
            return base.SaveChanges();
        }
    }
}
