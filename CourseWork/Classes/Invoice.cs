using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Classes
{
    internal class Invoice
    {
        private Database dataBase = new Database();

        public decimal GetAmountForRequestType(string requestType)
        {
            decimal fixedAmount = 0;

            using (SqlConnection connection = dataBase.getConnection())
            {
                dataBase.openConnection(connection);
                string query = @"
                SELECT Amount
                FROM FixedAmountPerRequestType
                WHERE RequestType = @requestType";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@requestType", requestType);

                object result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    fixedAmount = Convert.ToDecimal(result);
                }
                
                dataBase.closeConnection(connection);
            }

            return fixedAmount;
        }
    }
}
