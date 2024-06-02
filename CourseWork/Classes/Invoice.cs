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
        public static decimal GetFixedAmountForRequestType(string requestType)
        {
            decimal fixedAmount = 0;

            using (SqlConnection connection = new SqlConnection("your_connection_string"))
            {
                connection.Open();
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
            }

            return fixedAmount;
        }

        public static void SaveTotalAmount(int requestId, decimal totalAmount)
        {
            // Запис суми не потрібно, оскільки вона фіксована для кожного типу заявки
        }
    }
}
