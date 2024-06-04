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
        public short MaterialId { get; set; }
        public string RequestType { get; set; }
        public int Quantity { get; set; }
        public DateTime WriteOffDateW { get; set; }

        private Database dataBase = new Database();

        public void AddWriteOffMaterials(short materialId, string requestType, int quantity, DateTime writeOffDate, short requestId)
        {
            using (SqlConnection connection = dataBase.getConnection())
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Insert a new record into WriteOffMaterials
                    string insertQuery = @"INSERT INTO WriteOffMaterials (MaterialId, RequestType, Quantity, WriteOffDateW, RequestId) 
                                       VALUES (@MaterialId, @RequestType, @Quantity, @WriteOffDate, @RequestId)";
                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection, transaction);
                    insertCommand.Parameters.AddWithValue("@MaterialId", materialId);
                    insertCommand.Parameters.AddWithValue("@RequestType", requestType);
                    insertCommand.Parameters.AddWithValue("@Quantity", quantity);
                    insertCommand.Parameters.AddWithValue("@WriteOffDate", writeOffDate);
                    insertCommand.Parameters.AddWithValue("@RequestId", requestId);

                    insertCommand.ExecuteNonQuery();

                    // Delete the corresponding record from RequestMaterials
                    string deleteQuery = @"DELETE FROM RequestMaterials 
                                       WHERE MaterialId = @MaterialId AND RequestType = @RequestType";
                    SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection, transaction);
                    deleteCommand.Parameters.AddWithValue("@MaterialId", materialId);
                    deleteCommand.Parameters.AddWithValue("@RequestType", requestType);

                    deleteCommand.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error while updating the database.", ex);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }

}
