using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CPRG214.Framework.Data;

namespace CPRG214.Marina.Domain
{

    public class SlipManager
    {
        private static string connectionString = @"server=.\sqlexpress;database=Marina;trusted_connection=True";
        private static DBObject dbo = DBObject.Instance;

        /// <summary>
        /// Get available slips of a certain dock, if no parameter or null, get all available slips.
        /// </summary>
        /// <param name="dockID">If want all available slips, don't pass in parameter.</param>
        /// <returns>A list of Slip object.</returns>
        public static List<Slip> GetAvailableSlipsFromDock(int dockID = 0)
        {
            var slips = new List<Slip>();
            // if dockID is provided, find slips of that dock, otherwise search through all slips
            var sql = "SELECT ID,Width,Length,DockID FROM Slip " +
                      "WHERE ID NOT IN (SELECT SlipID FROM Lease) " +
                      (dockID != 0 ? $"AND DockID={dockID}" : "");
            dbo.ConnectionString = connectionString;
            dbo.SetProvider("System.Data.SqlClient");

            using (var reader = dbo.Query(sql, CommandType.Text, null))
            {
                while (reader.Read())
                {
                    var s = new Slip
                    {
                        SlipID = reader.GetInt32(0),
                        Width = reader.GetInt32(1),
                        Length = reader.GetInt32(2),
                        DockID = reader.GetInt32(3)
                    };
                    slips.Add(s);
                }
            }

            return slips;
        }

        public static bool LeaseSelectedSlip(Slip s, Customer c)
        {
            // set DBObject
            string sql = "INSERT INTO Lease(SlipID,CustomerID) VALUES(@SlipID,@CustomerID)";
            dbo.ConnectionString = connectionString;
            dbo.SetProvider("System.Data.SqlClient");
            // set parameters (let database infer DBType)
            var slipIDPar = dbo.CreateParameter();
            slipIDPar.Value = s.SlipID;
            slipIDPar.ParameterName = "@SlipID";
            var custIDPar = dbo.CreateParameter();
            custIDPar.Value = c.CustomerID;
            custIDPar.ParameterName = "@CustomerID";

            var parameters = new IDataParameter[] { slipIDPar,custIDPar };
            // call execute method
            var rowsAffected = dbo.NonQuery(sql, CommandType.Text, parameters);

            return rowsAffected > 0 ? true : false;
        }
    }
}
