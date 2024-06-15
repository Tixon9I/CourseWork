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

        public List<(short MaterialId, string RequestType, int Quantity)> CheckMaterials(string requestType)
        {

            List<(short MaterialId, string RequestType, int Quantity)> requiredMaterials = new List<(short MaterialId, string RequestType, int Quantity)>();

            using (SqlConnection connection = dataBase.getConnection())
            {
                dataBase.openConnection(connection);
                string query = @"
                SELECT m.IdMaterial, rm.RequestType, rm.Quantity
                FROM Material m
                INNER JOIN RequestMaterials rm ON m.IdMaterial = rm.MaterialId
                WHERE rm.RequestType = @requestType";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@requestType", requestType);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    short materialId = Convert.ToInt16(reader["IdMaterial"]);
                    string requestTypeFromDb = reader["RequestType"].ToString();
                    int quantity = Convert.ToInt16(reader["Quantity"]);
                    requiredMaterials.Add((materialId, requestTypeFromDb, quantity));
                }
                reader.Close();
                dataBase.closeConnection(connection);
            }

            return requiredMaterials;
        }
    }
}
