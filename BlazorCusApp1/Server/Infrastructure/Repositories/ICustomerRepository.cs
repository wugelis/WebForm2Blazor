using BlazorCusApp1.Server.Infrastructure.Models;

namespace BlazorCusApp1.Server.Infrastructure.Repositories
{
    /// <summary>
    /// Customer 基本資料存取介面
    /// </summary>
    public interface ICustomerRepository
    {
        /// <summary>
        /// 新增 Customer
        /// </summary>
        /// <param name="customer"></param>
        void Add(Customer customer);
        /// <summary>
        /// 修改 Customer
        /// </summary>
        /// <param name="customer"></param>
        void Edit(Customer customer);
        /// <summary>
        /// 查詢所有 Customers
        /// </summary>
        /// <returns></returns>
        IEnumerable<Customer> GetAllCustomers();
        /// <summary>
        /// 使用 CustomerID 取得聯絡人名稱
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        string GetCustomerByCustomerID(string customerId);
    }
}
