using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Classes
{
    internal class WriteOffMaterials
    {
        public int IdWriteOffMaterials { get; set; }
        public int MaterialId { get; set; }
        public string RequestType { get; set; }
        public int Quantity { get; set; }
        public DateTime WriteOffDateW { get; set; }
        public int RequestId { get; set; }

        private Database dataBase = new Database();

        public void AddWriteOffMaterials(int materialId, string requestType, int quantity, DateTime writeOffDate, int requestId)
        {
            using (SqlConnection connection = dataBase.getConnection())
            {
                dataBase.openConnection(connection);

                // Перевірка чи існує запис для цієї заявки
                string checkQuery = "SELECT COUNT(*) FROM WriteOffMaterials WHERE RequestId = @RequestId";
                SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                checkCommand.Parameters.AddWithValue("@RequestId", requestId);
                int count = (int)checkCommand.ExecuteScalar();

                if (count > 0) // Якщо запис існує, виконуємо оновлення
                {
                    string updateQuery = @"UPDATE WriteOffMaterials 
                                   SET MaterialId = @MaterialId, 
                                       RequestType = @RequestType, 
                                       Quantity = @Quantity, 
                                       WriteOffDateW = @WriteOffDate 
                                   WHERE RequestId = @RequestId";
                    SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                    updateCommand.Parameters.AddWithValue("@MaterialId", materialId);
                    updateCommand.Parameters.AddWithValue("@RequestType", requestType);
                    updateCommand.Parameters.AddWithValue("@Quantity", quantity);
                    updateCommand.Parameters.AddWithValue("@WriteOffDate", writeOffDate);
                    updateCommand.Parameters.AddWithValue("@RequestId", requestId);

                    updateCommand.ExecuteNonQuery();
                }
                else // Якщо запис не існує, виконуємо вставку
                {
                    string insertQuery = @"INSERT INTO WriteOffMaterials (MaterialId, RequestType, Quantity, WriteOffDateW, RequestId) 
                                   VALUES (@MaterialId, @RequestType, @Quantity, @WriteOffDate, @RequestId)";
                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@MaterialId", materialId);
                    insertCommand.Parameters.AddWithValue("@RequestType", requestType);
                    insertCommand.Parameters.AddWithValue("@Quantity", quantity);
                    insertCommand.Parameters.AddWithValue("@WriteOffDate", writeOffDate);
                    insertCommand.Parameters.AddWithValue("@RequestId", requestId);

                    insertCommand.ExecuteNonQuery();

                    // Після вставки запису в таблицю WriteOffMaterials, видаляємо відповідний запис з таблиці RequestMaterials
                    string deleteQuery = @"DELETE FROM RequestMaterials WHERE RequestType = @RequestType AND MaterialId = @MaterialId";
                    SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                    deleteCommand.Parameters.AddWithValue("@RequestType", requestType);
                    deleteCommand.Parameters.AddWithValue("@MaterialId", materialId);
                    deleteCommand.ExecuteNonQuery();
                }

                dataBase.closeConnection(connection);
            }
        }

    }
}
