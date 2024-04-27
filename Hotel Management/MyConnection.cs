using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management
{
    internal class MyConnection
    {
        public SqlConnection con_login;

        public MyConnection()
        {
            con_login = new SqlConnection(ConfigurationManager.ConnectionStrings["CC"].ConnectionString);
        }

        public static string type;
    }
}
