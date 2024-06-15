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
        private Database dataBase = new Database();

        public void AddConnectionRequestWriteOffMaterials(List<MaterialRequest> materialRequests)
        {

            using (SqlConnection connection = dataBase.getConnection())
            {
                dataBase.openConnection(connection);
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    foreach (var materialRequest in materialRequests)
                    {
                        short materialId = materialRequest.MaterialId;
                        string requestType = materialRequest.RequestType;
                        int quantity = materialRequest.Quantity;
                        DateTime writeOffDate = materialRequest.WriteOffDate;
                        short connectionRequestId = materialRequest.RequestId; // Оновлено ім'я змінної
                                                                               // Змінив назву змінної та значення параметра в команді параметрів
                        string checkQuery = "SELECT COUNT(1) FROM ConnectionRequest WHERE IdRequest = @ConnectionRequestId";
                        SqlCommand checkCommand = new SqlCommand(checkQuery, connection, transaction);
                        checkCommand.Parameters.AddWithValue("@ConnectionRequestId", connectionRequestId);
                        int requestExists = (int)checkCommand.ExecuteScalar();

                        if (requestExists == 0)
                        {
                            throw new Exception($"ConnectionRequestId {connectionRequestId} does not exist in ConnectionRequest table.");
                        }

                        string insertQuery = @"INSERT INTO WriteOffMaterials (MaterialId, RequestType, Quantity, WriteOffDateW, ConnectionRequestId) 
                               VALUES (@MaterialId, @RequestType, @Quantity, @WriteOffDate, @ConnectionRequestId)"; // Оновлено назву поля
                        SqlCommand insertCommand = new SqlCommand(insertQuery, connection, transaction);
                        insertCommand.Parameters.AddWithValue("@MaterialId", materialId);
                        insertCommand.Parameters.AddWithValue("@RequestType", requestType);
                        insertCommand.Parameters.AddWithValue("@Quantity", quantity);
                        insertCommand.Parameters.AddWithValue("@WriteOffDate", writeOffDate);
                        insertCommand.Parameters.AddWithValue("@ConnectionRequestId", connectionRequestId); // Оновлено назву поля
                        insertCommand.ExecuteNonQuery();

                        string deleteQuery = @"DELETE FROM RequestMaterials 
                               WHERE MaterialId = @MaterialId AND RequestType = @RequestType";
                        SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection, transaction);
                        deleteCommand.Parameters.AddWithValue("@MaterialId", materialId);
                        deleteCommand.Parameters.AddWithValue("@RequestType", requestType);
                        deleteCommand.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error while updating the database for ConnectionRequest.", ex);
                }
                finally
                {
                    dataBase.closeConnection(connection);
                }
            }
        }

        public void AddAccidentReportWriteOffMaterials(List<MaterialRequest> materialRequests)
        {
            using (SqlConnection connection = dataBase.getConnection())
            {
                dataBase.openConnection(connection);
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    foreach (var materialRequest in materialRequests)
                    {
                        short materialId = materialRequest.MaterialId;
                        string requestType = materialRequest.RequestType;
                        int quantity = materialRequest.Quantity;
                        DateTime writeOffDate = materialRequest.WriteOffDate;
                        short accidentReportId = materialRequest.RequestId; // Оновлено ім'я змінної
                                                                            // Змінив назву змінної та значення параметра в команді параметрів
                        string checkQuery = "SELECT COUNT(1) FROM AccidentReport WHERE IdReport = @AccidentReportId";
                        SqlCommand checkCommand = new SqlCommand(checkQuery, connection, transaction);
                        checkCommand.Parameters.AddWithValue("@AccidentReportId", accidentReportId);
                        int requestExists = (int)checkCommand.ExecuteScalar();

                        if (requestExists == 0)
                        {
                            throw new Exception($"AccidentReportId {accidentReportId} does not exist in AccidentReport table.");
                        }

                        string insertQuery = @"INSERT INTO WriteOffMaterials (MaterialId, RequestType, Quantity, WriteOffDateW, AccidentReportId) 
                               VALUES (@MaterialId, @RequestType, @Quantity, @WriteOffDate, @AccidentReportId)"; // Оновлено назву поля
                        SqlCommand insertCommand = new SqlCommand(insertQuery, connection, transaction);
                        insertCommand.Parameters.AddWithValue("@MaterialId", materialId);
                        insertCommand.Parameters.AddWithValue("@RequestType", requestType);
                        insertCommand.Parameters.AddWithValue("@Quantity", quantity);
                        insertCommand.Parameters.AddWithValue("@WriteOffDate", writeOffDate);
                        insertCommand.Parameters.AddWithValue("@AccidentReportId", accidentReportId); // Оновлено назву поля
                        insertCommand.ExecuteNonQuery();

                        string deleteQuery = @"DELETE FROM RequestMaterials 
                               WHERE MaterialId = @MaterialId AND RequestType = @RequestType";
                        SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection, transaction);
                        deleteCommand.Parameters.AddWithValue("@MaterialId", materialId);
                        deleteCommand.Parameters.AddWithValue("@RequestType", requestType);
                        deleteCommand.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error while updating the database for AccidentReport.", ex);
                }
                finally
                {
                    dataBase.closeConnection(connection);
                }
            }
        }

        // Допоміжний клас для передачі даних
        public class MaterialRequest
        {
            public short MaterialId { get; set; }
            public string RequestType { get; set; }
            public int Quantity { get; set; }
            public DateTime WriteOffDate { get; set; }
            public short RequestId { get; set; }
        }
    }
}
