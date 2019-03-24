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
        public static List<Slip> GetAvailableSlips()
        {
            var slips = new List<Slip>();
            var sql = "SELECT ID,Width,Length,DockID FROM Slip " +
                      "WHERE ID NOT IN (SELECT SlipID FROM Lease)";
            var dbo = DBObject.Instance;
            dbo.ConnectionString = @"server=.\sqlexpress;database=Marina;trusted_connection=True";
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
    }
}
