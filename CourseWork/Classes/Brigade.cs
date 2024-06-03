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
            List<Brigade> freeBrigades = new List<Brigade>();

            using (SqlConnection connection = dataBase.getConnection())
            {
                dataBase.openConnection(connection);

                string query = @"
            SELECT IdBrigade, DateCreation
            FROM Brigade";

                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        short id = reader.GetInt16(0);
                        DateTime dateCreation = reader.GetDateTime(1);

                        if (!IsBrigadeUsedOnDate(id, date))
                        {
                            freeBrigades.Add(new Brigade(id, dateCreation));
                        }
                    }
                }

                dataBase.closeConnection(connection);
            }

            return freeBrigades.ToArray();
        }

        private bool IsBrigadeUsedOnDate(short brigadeId, DateTime date)
        {
            string query = @"
            SELECT COUNT(*)
            FROM (
                SELECT WorkDate, IdBrigade FROM ConnectionRequest
                UNION ALL
                SELECT WorkDate, IdBrigade FROM AccidentReport
            ) AS CombinedRequests
            WHERE WorkDate = @date AND IdBrigade = @brigadeId";

            using (SqlConnection connection = dataBase.getConnection())
            {
                dataBase.openConnection(connection);
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@date", date);
                command.Parameters.AddWithValue("@brigadeId", brigadeId);

                // Журналювання для перевірки параметрів
                Console.WriteLine($"Checking if brigade {brigadeId} is used on date {date}");

                int count = (int)command.ExecuteScalar();
                dataBase.closeConnection(connection);

                // Журналювання для перевірки результату
                Console.WriteLine($"Brigade {brigadeId} usage count on {date}: {count}");

                return count > 0;
            }
        }
    }
}
