using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication.DataModel;
using WebApplication.Services;

namespace WebApplication1.Controllers.API
{
    public class CustomersController : ApiController
    {
        private readonly CustomerService _service;

        public CustomersController()
        {
            _service = new CustomerService();
        }

        // GET: api/Customers
        public IHttpActionResult Get()
        {
            var data = _service.GetCustomer();
            return Ok(data);
        }

        public IHttpActionResult DELETE(string id)
        {
            var result = _service.DeleteCustomer(id);
            return Ok(result);
        }


        //[HttpPost]
        //[Route("api/Customers/DeleteCustomer")]

        //public IHttpActionResult DeleteCustomer([FromBody] string id)
        //{
        //    var result = _service.DeleteCustomer(id);
        //    return Ok(result );
        //}

        [HttpPost]
        [Route("api/Customers/EditCustomer")]

        public IHttpActionResult EditCustomer(Customer data)
        {
            var result = _service.EditCustomer(data);
            return Ok(result);
        }    


    }
}
