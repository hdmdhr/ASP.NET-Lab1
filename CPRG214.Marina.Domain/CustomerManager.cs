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
            var sql = "SELECT ID,FirstName,LastName,Phone,City FROM Customer";
            dbo.ConnectionString = connectionString;
            dbo.SetProvider("System.Data.SqlClient");

            using (var reader = dbo.Query(sql, CommandType.Text, null))
            {
                while (reader.Read())
                {
                    var c = new Customer()
                    {
                        CustomerID = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Phone = reader.GetString(3),
                        City = reader.GetString(4)
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

        public static List<Slip> FindLeasingHistory(Customer c)
        {
            // set dbo object
            var leasedSlips = new List<Slip>();
            var sql = "SELECT Slip.ID,Width,Length,DockID FROM Lease,Slip WHERE Lease.SlipID=Slip.ID AND CustomerID=@CustomerID";
            dbo.ConnectionString = connectionString;
            dbo.SetProvider("System.Data.SqlClient");
            // set parameter
            var cIDPar = dbo.CreateParameter();
            cIDPar.ParameterName = "@CustomerID";
            cIDPar.Value = c.CustomerID;
            var parameters = new IDataParameter[] { cIDPar };

            // call execute method
            using (var reader = dbo.Query(sql, CommandType.Text, parameters))
            {
                while (reader.Read())
                {
                    var slip = new Slip
                    {
                        SlipID = reader.GetInt32(0),
                        Width = reader.GetInt32(1),
                        Length = reader.GetInt32(2),
                        DockID = reader.GetInt32(3)
                    };
                    leasedSlips.Add(slip);
                }
            }

            return leasedSlips;
        }
    }
}
