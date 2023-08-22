using BlazorCusApp1.Server.Application;
using BlazorCusApp1.Server.Infrastructure.Repositories;
using Cus.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCusApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IProductRepository _productRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IShipperRepository _shipperRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly CRM _crm;

        public CustomerController(
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
            _crm = new CRM(_customerRepository, _orderRepository, _orderDetailRepository, _productRepository, _employeeRepository, _shipperRepository, _unitOfWork);
        }

        [Route("GetCustomers")]
        public IEnumerable<CustomerViewModel> GetCustomers()
        {
            var result = _crm.GetCustomerList();

            return result;
        }

        [Route("GetCustomers/{id}")]
        public IEnumerable<CusOrderViewModel> GetCustomers(string id)
        {
            var result = _crm.GetOrderByCusID(id);

            return result;
        }

        [Route("AddCustomer")]
        [HttpPost]
        public int AddCustomer(CustomerViewModel customerViewModel)
        {
            return _crm.AddCustomer(customerViewModel);
        }

        [Route("GetProducts")]
        public IEnumerable<ProductViewModel> GetProducts()
        {
            return _crm.GetProducts();
        }

        [Route("GetEmployees")]
        public IEnumerable<EmployeeViewModel> GetEmployees()
        {
            return _crm.GetEmployees();
        }

        [Route("GetCustomerByCustomerID/{customerId}")]
        public string GetCustomerByCustomerID(string customerId)
        {
            return _crm.GetCustomerByCustomerID(customerId);
        }

        [Route("GetShippers")]
        public IEnumerable<ShipperViewModel> GetShippers()
        {
            return _crm.GetShippers();
        }
    }
}
