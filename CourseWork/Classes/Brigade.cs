using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Classes
{
    internal class Brigade
    {

        private Database dataBase = new Database();
        public int Id { get; set; }
        public DateTime DateCreation { get; set; }

        public Brigade() { }

        public Brigade(int id, DateTime dateCreation)
        {
            Id = id;
            DateCreation = dateCreation;
        }

        public Brigade[] AssignBrigade(DateTime date)
        {
            // Підключення до бази даних
            using (SqlConnection connection = dataBase.getConnection())
            {
                dataBase.openConnection(connection);
                // SQL-запит для отримання всіх бригад
                string query = @"
                SELECT IdBrigade, DateCreation
                FROM Brigade";

                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Створення масиву для зберігання вільних бригад
                    var freeBrigades = new List<Brigade>();
                    while (reader.Read())
                    {
                        int id = reader.GetInt16(0);
                        DateTime dateCreation = reader.GetDateTime(1);
                        
                        // Перевірка, чи бригада не використовується на певну дату
                        if (!IsBrigadeUsedOnDate(id, date))
                        {
                            freeBrigades.Add(new Brigade(id, dateCreation));
                        }
                    }
                    dataBase.closeConnection(connection);
                    reader.Close();
                    return freeBrigades.ToArray();
                }
            }
        }

        private bool IsBrigadeUsedOnDate(int brigadeId, DateTime date)
        {
            // SQL-запит для перевірки, чи бригада використовується на певну дату
            string query = @"
            SELECT COUNT(*)
            FROM (
                SELECT IdBrigade
                FROM ConnectionRequest
                WHERE WorkDate = @date AND IdBrigade = @brigadeId
                UNION ALL
                SELECT IdBrigade
                FROM AccidentReport
                WHERE WorkDate = @date AND IdBrigade = @brigadeId
            ) AS UsedBrigades";

            using (SqlConnection connection = dataBase.getConnection())
            {
                dataBase.openConnection(connection);
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@date", date);
                command.Parameters.AddWithValue("@brigadeId", brigadeId);
                int count = (int)command.ExecuteScalar();
                dataBase.closeConnection(connection);
                return count > 0;
            }
        }
    }
}
