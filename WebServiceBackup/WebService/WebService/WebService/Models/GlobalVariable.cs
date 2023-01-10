using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class GlobalVariable
    {
      
        public static SqlConnection connexionBD()
        {
            var ConnectionStringBD = ConfigurationManager.AppSettings["ConnectionBD"];
            SqlConnection conn = new SqlConnection(ConnectionStringBD);
            return conn;
        }
    }
}