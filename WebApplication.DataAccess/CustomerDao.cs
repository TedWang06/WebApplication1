using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Xml.Linq;
using WebApplication.DataModel;

namespace WebApplication.DataAccess
{
 
    public class CustomerDao
    {
        private readonly string _conn = string.Empty;

        public CustomerDao()
        {
            _conn = WebConfigurationManager.ConnectionStrings["MainDb"].ToString(); 
        }

        public List<Customer> GetCustomer()
        {
            using(var conn = new SqlConnection(_conn))
            {
                var sql = @"
                            SELECT CustomerID , CompanyName , ContactName , ContactTitle , Address , City
                            FROM Customers ";

                return conn.Query<Customer>(sql).ToList();
            }
        }

    }
}
