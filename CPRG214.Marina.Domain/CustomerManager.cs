using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPRG214.Framework.Data;

namespace CPRG214.Marina.Domain
{
    public class CustomerManager
    {
        private static string connectionString = @"server=.\sqlexpress;database=Marina;trusted_connection=True";
        private static DBObject dbo = DBObject.Instance;

        /// <summary>
        /// Get all customers.
        /// </summary>
        /// <returns>A list of Customer object.</returns>
        public static List<Customer> GetAllCustomers()
        {
            var customers = new List<Customer>();
            var sql = "SELECT FirstName,LastName,Phone,City FROM Customer";
            dbo.ConnectionString = connectionString;
            dbo.SetProvider("System.Data.SqlClient");

            using (var reader = dbo.Query(sql, CommandType.Text, null))
            {
                while (reader.Read())
                {
                    var c = new Customer()
                    {
                        CustomerID = null,
                        FirstName = reader.GetString(0),
                        LastName = reader.GetString(1),
                        Phone = reader.GetString(2),
                        City = reader.GetString(3)
                    };
                    customers.Add(c);
                }
            }

            return customers;
        }
        /// <summary>
        /// Insert a Customer object into DB.
        /// </summary>
        /// <param name="c">Customer object.</param>
        /// <returns>Bool indicate if succeed.</returns>
        public static bool InsertCustomer(Customer c)
        {
            // set DBObject
            string sql = "INSERT INTO Customer(FirstName,LastName,Phone,City) VALUES(@FN,@LN,@PH,@CT)";
            dbo.ConnectionString = connectionString;
            dbo.SetProvider("System.Data.SqlClient");
            // set parameters (let database infer DBType)
            var fNamePar = dbo.CreateParameter();
            fNamePar.Value = c.FirstName;
            fNamePar.ParameterName = "@FN";
            var lNamePar = dbo.CreateParameter();
            lNamePar.Value = c.LastName;
            lNamePar.ParameterName = "@LN";
            var phonePar = dbo.CreateParameter();
            phonePar.Value = c.Phone;
            phonePar.ParameterName = "@PH";
            var cityPar = dbo.CreateParameter();
            cityPar.Value = c.City;
            cityPar.ParameterName = "@CT";

            var parameters = new IDataParameter[] { fNamePar, lNamePar, phonePar, cityPar };
            // call execute method
            var rowsAffected = dbo.NonQuery(sql, CommandType.Text, parameters);

            return rowsAffected > 0 ? true : false;
        }
    }
}
