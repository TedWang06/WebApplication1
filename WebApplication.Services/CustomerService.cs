using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.DataAccess;
using WebApplication.DataModel;

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

        public int DeleteCustomer(string id)
        {
            return _dao.DeleteCustomer(id);
        }

        public bool EditCustomer(Customer data)
        {
            var success = true;
            try { 
                _dao.EditCustomer(data);
            }
            catch (Exception ) {
                success = false;
                throw;
            }
            return success;
        }


    }
}
