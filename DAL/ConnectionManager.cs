using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ConnectionManager
    {
        internal SqlConnection connection;
        public ConnectionManager(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }
        public void Open()
        {
            connection.Open();
        }
        public void Close()
        {
            connection.Close();
        }
    }
}
