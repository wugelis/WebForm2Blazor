using Cus.Services.Interface;
using Cus.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Cus.MVC5.Controllers.Api
{
    [EnableCors(origins: "http://localhost:7000/", headers: "*", methods: "*")]
    public class CusApiController : ApiController
    {
        private ICustomersService _customer = null;

        public CusApiController(ICustomersService customer)
        {
            _customer = customer;
        }

        public IEnumerable<CustomerViewModel> Get()
        {
            return _customer.GetCustomerList();
        }
    }
}
