using BlazorCusApp1.Server.Infrastructure.Models;
using BlazorCusApp1.Server.Infrastructure.Repositories;
using Cus.Services.Interface;
using Cus.ViewModels;

namespace BlazorCusApp1.Server.Application
{
    /// <summary>
    /// 由於在這裡無法注入 net451 的 DbContext，所以只好用這種方式來重新實作相關聯的 interfaces
    /// </summary>
    public class CRM: ICustomersService, IEmployeesService, IOrdersService, IProductsService, IShippersService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IProductRepository _productRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IShipperRepository _shipperRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CRM(
            ICustomerRepository customerRepository, 
            IOrderRepository orderRepository, 
            IOrderDetailRepository orderDetailRepository,
            IProductRepository productRepository,
            IEmployeeRepository employeeRepository,
            IShipperRepository shipperRepository,
            IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _productRepository = productRepository;
            _employeeRepository = employeeRepository;
            _shipperRepository = shipperRepository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<CustomerViewModel> GetCustomerList()
        {
            var result = from cus in _customerRepository.GetAllCustomers()
                         select new CustomerViewModel()
                         {
                             CustomerID = cus.CustomerId,
                             ContactName = cus.ContactName,
                             CompanyName = cus.CompanyName,
                             Region = cus.Region,
                             Address = cus.Address,
                             City = cus.City,
                             ContactTitle = cus.ContactTitle,
                             Country = cus.Country,
                             Phone = cus.Phone
                         };

            return result;
        }

        public IEnumerable<CusOrderViewModel> GetOrderByCusID(string id)
        {
            var result = from order in _orderRepository.GetOrders()
                         join detail in _orderDetailRepository.GetOrderDetails()
                             on order.OrderId equals detail.OrderId
                         join pro in _productRepository.GetProducts()
                             on detail.ProductId equals pro.ProductId
                         join cus in _customerRepository.GetAllCustomers()
                             on order.CustomerId equals cus.CustomerId

                         where order.CustomerId == id
                         select new CusOrderViewModel()
                         {
                             CustomerID = cus.CustomerId,
                             CompanyName = cus.CompanyName,
                             ContactName = cus.ContactName,
                             City = cus.City,
                             OrderID = detail.OrderId,
                             UnitPrice = detail.UnitPrice,
                             ProductID = pro.ProductId,
                             ProductName = pro.ProductName,
                             OrderDate = order.OrderDate.Value
                         };

            return result;
        }

        public IEnumerable<EmployeeViewModel> GetEmployees()
        {
            return from emp in _employeeRepository.GetAllEmployees()
                   select new EmployeeViewModel()
                   {
                       Address = emp.Address,
                       City = emp.City,
                       BirthDate = emp.BirthDate, 
                       Region = emp.Region,
                       PostalCode = emp.PostalCode,
                       Country = emp.Country,
                       EmployeeID = emp.EmployeeId,
                       FirstName = emp.FirstName,
                       LastName = emp.LastName,
                       Extension = emp.Extension,
                       HireDate = emp.HireDate,
                       HomePhone = emp.HomePhone,
                       Notes = emp.Notes,
                       Photo = emp.Photo,
                       PhotoPath = emp.PhotoPath,
                       Title = emp.Title
                   };
        }

        public IEnumerable<ShipperViewModel> GetShippers()
        {
            return from ship in _shipperRepository.GetShippers()
                   select new ShipperViewModel()
                   {
                       CompanyName = ship.CompanyName,
                       Phone = ship.Phone,
                       ShipperID = ship.ShipperId
                   };
        }

        public int AddCustomer(CustomerViewModel customer)
        {
            int result = 0;
            try
            {
                _customerRepository.Add(new Customer()
                {
                    CustomerId = customer.CustomerID,
                    ContactName = customer.ContactName,
                    ContactTitle = customer.ContactTitle,
                    CompanyName = customer.CompanyName,
                    Country = customer.Country,
                    PostalCode = customer.PostalCode,
                    Address = customer.Address,
                    City = customer.City,
                    Phone = customer.Phone,
                    Region = customer.Region,
                    Fax = customer.Fax
                });
                result = _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                // Write Log

                // Or throw the exception
                throw ex;

            }
            return result;
        }

        public IEnumerable<ProductViewModel> GetProducts()
        {
            return from p in _productRepository.GetProducts()
                   select new ProductViewModel()
                   {
                       ProductID = p.ProductId,
                       ProductName = p.ProductName
                   };
        }

        public string GetCustomerByCustomerID(string customerId)
        {
            return _customerRepository.GetCustomerByCustomerID(customerId);
        }

        public IEnumerable<CusOrderViewModel> GetByCusID(string CusID)
        {
            throw new NotImplementedException();
        }

        object ICustomersService.GetCustomerByCustomerID(string CustomerId)
        {
            throw new NotImplementedException();
        }

        public int AddOrder(OrderViewModel orders)
        {
            throw new NotImplementedException();
        }

        public object GetProductPriceByProductID(int ProductID)
        {
            throw new NotImplementedException();
        }
    }
}
