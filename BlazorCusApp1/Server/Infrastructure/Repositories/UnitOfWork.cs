using BlazorCusApp1.Server.Application;

namespace BlazorCusApp1.Server.Infrastructure.Repositories
{
    /// <summary>
    /// 控制交易、並維持交易的完整性
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public UnitOfWork(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public int Commit()
        {
            return _applicationDbContext.SaveChange();
        }
    }
}
