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
        public int RequestId { get; set; }  // Поле для зберігання ідентифікатора заявки

        public void AddWriteOffMaterials(int materialId, string requestType, int quantity, DateTime writeOffDate, int requestId)
        {
            // Виконати додавання запису до таблиці бази даних за допомогою SQL-запиту або ORM-бібліотеки
            // Наприклад, використовуючи ADO.NET:
            using (SqlConnection connection = new SqlConnection())
            {
                string query = "INSERT INTO WriteOffMaterials (MaterialId, RequestType, Quantity, WriteOffDateW, RequestId) VALUES (@MaterialId, @RequestType, @Quantity, @WriteOffDate, @RequestId)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaterialId", materialId);
                command.Parameters.AddWithValue("@RequestType", requestType);
                command.Parameters.AddWithValue("@Quantity", quantity);
                command.Parameters.AddWithValue("@WriteOffDate", writeOffDate);
                command.Parameters.AddWithValue("@RequestId", requestId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
