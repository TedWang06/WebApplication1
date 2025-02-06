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

        public int DeleteCustomer(string id)
        {
            using(var conn = new SqlConnection(_conn))
            {
                var sql = @" DELETE Customers WHERE CustomerID = @Id";

                return conn.Execute(sql, new { Id = id });
            }
        }

        public void EditCustomer(Customer data)
        {
            using(var conn = new SqlConnection(_conn))
            {
                var sql = @" UPDATE Customers 
                                    SET CompanyName = @CompanyName ,
                                    ContactName = @ContactName,
                                    ContactTitle = @ContactTitle,
                                    Address = @Address,
                                    City = @City
                             WHERE CustomerID = @Id";

                var param = new { 
                    Id = data.CustomerId,
                    CompanyName = data.CompanyName,
                    ContactName= data.ContactName,
                    ContactTitle = data.ContactTitle,
                    Address = data.Address,
                    City = data.City,
                };

                conn.Execute(sql, param);
            }
        }

    }
}
