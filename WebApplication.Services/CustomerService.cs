using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.DataAccess;

namespace WebApplication.Services
{
    public class CustomerService
    {
        private readonly CustomerDao _dao = null;

        public CustomerService()
        {
            _dao = new CustomerDao();
        }

        public object GetCustomer()
        {
            var result = _dao.GetCustomer();
            return result;
        }

    }
}
