using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CourseWork
{
    internal class Database
    {
        private string connectionString = @"Data Source=DESKTOP-T9TKG8K\SQLEXPRESS;Initial Catalog=CityWaterSupply;Integrated Security=True";

        public SqlConnection getConnection()
        {
            return new SqlConnection(connectionString);
        }

        public void openConnection(SqlConnection connection)
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }

        public void closeConnection(SqlConnection connection)
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }
    }
}
