using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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

        // GET: api/Customers/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Customers
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Customers/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Customers/5
        public void Delete(int id)
        {
        }
    }
}
