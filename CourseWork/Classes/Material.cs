using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Classes
{
    internal class Material
    {
        private Database dataBase = new Database();

        public List<(int MaterialId, int Quantity)> CheckMaterials(string requestType)
        {
            List<(int MaterialId, int Quantity)> requiredMaterials = new List<(int MaterialId, int Quantity)>();

            using (SqlConnection connection = dataBase.getConnection())
            {
                dataBase.openConnection(connection);
                string query = @"
                        SELECT MaterialId, Quantity
                        FROM RequestMaterials
                        WHERE RequestType = @requestType";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@requestType", requestType);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int materialId = Convert.ToInt16(reader["MaterialId"]);
                    int quantity = Convert.ToInt16(reader["Quantity"]);
                    requiredMaterials.Add((materialId, quantity));
                }
                reader.Close();
                dataBase.closeConnection(connection);
            }

            return requiredMaterials;
        }

    }
}
