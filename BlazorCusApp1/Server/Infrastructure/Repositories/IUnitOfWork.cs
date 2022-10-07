namespace BlazorCusApp1.Server.Infrastructure.Repositories
{
    public interface IUnitOfWork
    {
        int Commit();
    }
}
