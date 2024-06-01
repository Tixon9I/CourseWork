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
        SqlConnection _connection = new SqlConnection(@"Data Source=DESKTOP-T9TKG8K\SQLEXPRESS;Initial Catalog=CityWaterSupply;Integrated Security=True");

        public void openConnection()
        {
            if (_connection.State == System.Data.ConnectionState.Closed)
                _connection.Open();
        }

        public void closeConnection()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
                _connection.Close();
        }

        public SqlConnection getConnection()
        {
            return _connection; 
        }
    }
}
