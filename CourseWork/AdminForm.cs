using CourseWork.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class AdminForm : Form
    {
        private Database dataBase = new Database();
        
        public AdminForm()
        {
            InitializeComponent();
        }

        // Кастомізована кнопка закриття вікна
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Кастомізація кнопки закриття вікна, зміна кольору при наведені
        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.Red;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.Black;
        }

        // Рухати вікно на екрані
        Point lastPoint;
        private void labelPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }

        }

        private void labelPanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        // Показ записів з бд на DataGridView (Заявка на підключення)
        private void buttonConnectionRequestView_Click(object sender, EventArgs e)
        {
            LoadConnectionRequests(dataGridViewInfo);
        }

        private void LoadConnectionRequests(DataGridView dgw)
        {
            using (SqlConnection connection = dataBase.getConnection())
            {
                dataBase.openConnection(connection);
                string query = @"
        SELECT 
            CR.IdRequest, 
            CR.RequestDate, 
            CR.RequestStatus, 
            CR.Details,
            CR.IdBrigade,
            CR.WorkDate,
            CR.SumRequest,
            C.IdClient,
            C.SurnameC, 
            C.NameC, 
            C.PatronymicC, 
            CR.PhoneC, 
            CR.AddressC 
        FROM 
            ConnectionRequest CR
        INNER JOIN 
            Client C ON CR.IdClient = C.IdClient";

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();

                dgw.DataSource = null;
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                dgw.DataSource = dataTable;

                // Зміна назв стовпців у DataGridView
                dgw.Columns["IdRequest"].HeaderText = "ID Заявки";
                dgw.Columns["RequestDate"].HeaderText = "Дата створення";
                dgw.Columns["RequestStatus"].HeaderText = "Статус заявки";
                dgw.Columns["Details"].HeaderText = "Деталі";
                dgw.Columns["IdBrigade"].HeaderText = "ID Бригади";
                dgw.Columns["WorkDate"].HeaderText = "Дата виконання";
                dgw.Columns["SumRequest"].HeaderText = "Сума заявки";
                dgw.Columns["IdClient"].HeaderText = "ID Клієнта";
                dgw.Columns["SurnameC"].HeaderText = "Прізвище";
                dgw.Columns["NameC"].HeaderText = "Ім'я";
                dgw.Columns["PatronymicC"].HeaderText = "По батькові";
                dgw.Columns["PhoneC"].HeaderText = "Телефон";
                dgw.Columns["AddressC"].HeaderText = "Адреса";

                reader.Close();
                dataBase.closeConnection(connection);
            }
        }

        // Показ записів з бд на DataGridView (Заявки на усунення аварії)
        private void buttonAccidentReportView_Click(object sender, EventArgs e)
        {
            
            LoadAccidentRequests(dataGridViewInfo);
        }

        private void LoadAccidentRequests(DataGridView dgw)
        {
            using (SqlConnection connection = dataBase.getConnection())
            {
                dataBase.openConnection(connection);
                string query = @"
             SELECT
                 AR.IdReport,
                 AR.ReportDate, 
                 AR.ReportStatus, 
                 AR.Details,
                 AR.IdBrigade,
                 AR.WorkDate,
                 AR.SumRequest,
                 C.IdClient,
                 C.SurnameC, 
                 C.NameC, 
                 C.PatronymicC, 
                 AR.PhoneC, 
                 AR.AddressC 
             FROM 
                  AccidentReport AR
             INNER JOIN 
                 Client C ON AR.IdClient = C.IdClient";

                SqlCommand command = new SqlCommand(query, connection);

                dgw.DataSource = null; 
                DataTable dataTable = new DataTable(); 
                dataTable.Load(command.ExecuteReader()); 
                dgw.DataSource = dataTable;

                dgw.Columns["IdReport"].HeaderText = "ID заявки";
                dgw.Columns["ReportDate"].HeaderText = "Дата створення";
                dgw.Columns["ReportStatus"].HeaderText = "Статус заявки";
                dgw.Columns["Details"].HeaderText = "Деталі";
                dgw.Columns["IdBrigade"].HeaderText = "ID Бригади";
                dgw.Columns["WorkDate"].HeaderText = "Дата виконання";
                dgw.Columns["SumRequest"].HeaderText = "Сума заявки";
                dgw.Columns["IdClient"].HeaderText = "ID Клієнта";
                dgw.Columns["SurnameC"].HeaderText = "Прізвище";
                dgw.Columns["NameC"].HeaderText = "Ім'я";
                dgw.Columns["PatronymicC"].HeaderText = "По батькові";
                dgw.Columns["PhoneC"].HeaderText = "Телефон";
                dgw.Columns["AddressC"].HeaderText = "Адреса";

                dataBase.closeConnection(connection);
            }
        }

        // Виклик форми редагування даних
        private void dataGridViewInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Перевірка назви стовпця, щоб визначити, яка заявка вибрана
                if (dataGridViewInfo.Columns[e.ColumnIndex].Name == "IdRequest")
                {
                    short idRequest = Convert.ToInt16(dataGridViewInfo.Rows[e.RowIndex].Cells["IdRequest"].Value);
                    DateTime requestDate = Convert.ToDateTime(dataGridViewInfo.Rows[e.RowIndex].Cells["RequestDate"].Value);
                    string requestStatus = dataGridViewInfo.Rows[e.RowIndex].Cells["RequestStatus"].Value.ToString();
                    string details = dataGridViewInfo.Rows[e.RowIndex].Cells["Details"].Value.ToString();

                    if (requestStatus.Equals("Оплачено"))
                    {
                        MessageBox.Show("Редагування цієї заявки не дозволено, оскільки статус 'Оплачено'.", "Повідомлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    ConnectionRequest requestDetailsForm = new ConnectionRequest(idRequest, requestDate, requestStatus, details);
                    requestDetailsForm.ShowDialog();
                }
                else if (dataGridViewInfo.Columns[e.ColumnIndex].Name == "IdReport")
                {
                    short idReport = Convert.ToInt16(dataGridViewInfo.Rows[e.RowIndex].Cells["IdReport"].Value);
                    DateTime reportDate = Convert.ToDateTime(dataGridViewInfo.Rows[e.RowIndex].Cells["ReportDate"].Value);
                    string reportStatus = dataGridViewInfo.Rows[e.RowIndex].Cells["ReportStatus"].Value.ToString();
                    string details = dataGridViewInfo.Rows[e.RowIndex].Cells["Details"].Value.ToString();

                    if (reportStatus.Equals("Оплачено"))
                    {
                        MessageBox.Show("Редагування цієї заявки не дозволено, оскільки статус 'Оплачено'.", "Повідомлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    EmergencyRepairRequest reportDetailsForm = new EmergencyRepairRequest(idReport, reportDate, reportStatus, details);
                    reportDetailsForm.ShowDialog();
                }
            }
        }

        // Закупівля матеріалів
        private void buttonPurchaseMaterial_Click(object sender, EventArgs e)
        {
            PurchaseMaterialsForm purchaseMaterialsForm = new PurchaseMaterialsForm();
            purchaseMaterialsForm.ShowDialog();

        }

        // Сформування рахунків клієнтам
        private void buttonBill_Click(object sender, EventArgs e)
        {
            // Отримання всіх ідентифікаторів клієнтів з бази даних
            List<short> clientIds = GetAllClientIds();

            // Перевірка, чи є клієнти у базі даних
            if (clientIds.Count == 0)
            {
                MessageBox.Show("Клієнти відсутні. Спочатку додайте клієнтів до бази даних.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Початкова дата створення рахунку
            DateTime billDate = DateTime.Now;

            // Ціна за кубометр води
            decimal pricePerCubicMeter = 4.5m;

            // Отримання кількості використаних кубометрів води
            decimal cubicMetersUsed = 50.0m;

            // Статус рахунку
            string billStatus = "Неоплачено";

            // Прапорець, що вказує на те, чи було створено хоча б один рахунок
            bool anyBillCreated = false;

            // Додавання рахунку для кожного клієнта
            foreach (short clientId in clientIds)
            {
                // Перевірка, чи існує заявка на підключення для поточного клієнта
                if (HasConnectionRequest(clientId))
                {
                    // Перевірка, чи існує рахунок для поточного клієнта або чи пройшло більше 30 днів з моменту створення останнього рахунку
                    if (!IsBillExistOrExpired(clientId))
                    {
                        // Виклик методу додавання рахунку
                        AddWaterBill(clientId, billDate, pricePerCubicMeter, cubicMetersUsed, billStatus);

                        // Встановлення прапорця, що було створено рахунок
                        anyBillCreated = true;
                    }
                }
            }

            // Перевірка, чи було створено хоча б один рахунок
            if (!anyBillCreated)
            {
                MessageBox.Show("Рахунки не були створені.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Рахунки успішно створено!", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Метод для додавання рахунку в базу даних для певного клієнта
        private void AddWaterBill(short clientId, DateTime billDate, decimal pricePerCubicMeter, decimal cubicMetersUsed, string billStatus)
        {
            using (SqlConnection connection = dataBase.getConnection())
            {
                string query = @"
                 INSERT INTO WaterBill (IdClient, BillDate, PricePerCubicMeter, CubicMetersUsed, BillStatus)
                 VALUES (@IdClient, @BillDate, @PricePerCubicMeter, @CubicMetersUsed, @BillStatus)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdClient", clientId);
                command.Parameters.AddWithValue("@BillDate", billDate);
                command.Parameters.AddWithValue("@PricePerCubicMeter", pricePerCubicMeter);
                command.Parameters.AddWithValue("@CubicMetersUsed", cubicMetersUsed);
                command.Parameters.AddWithValue("@BillStatus", billStatus);

                dataBase.openConnection(connection);
                command.ExecuteNonQuery();
                dataBase.closeConnection(connection);
            }
        }

        // Метод для перевірки наявності заявки на підключення для клієнта
        private bool HasConnectionRequest(short clientId)
        {
            // SQL-запит для перевірки наявності заявки на підключення для клієнта
            string query = "SELECT COUNT(*) FROM ConnectionRequest WHERE IdClient = @IdClient";

            using (SqlConnection connection = dataBase.getConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdClient", clientId);
                dataBase.openConnection(connection);

                int count = (int)command.ExecuteScalar();

                dataBase.closeConnection(connection);

                // Перевірка, чи існує заявка на підключення
                return count > 0;
            }
        }

        // Метод для перевірки наявності рахунку для клієнта або перевірки, чи пройшло більше 30 днів з моменту створення останнього рахунку
        private bool IsBillExistOrExpired(short clientId)
        {
            // SQL-запит для отримання найновішої дати рахунку для клієнта
            string query = "SELECT MAX(BillDate) FROM WaterBill WHERE IdClient = @IdClient";

            using (SqlConnection connection = dataBase.getConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdClient", clientId);
                dataBase.openConnection(connection);

                // Отримання найновішої дати рахунку
                object latestBillDateObj = command.ExecuteScalar();

                // Перевірка на null перед конвертацією
                if (latestBillDateObj != DBNull.Value && latestBillDateObj != null)
                {
                    DateTime latestBillDate = Convert.ToDateTime(latestBillDateObj);

                    // Перевірка, чи пройшло більше 30 днів з отримання дати рахунку
                    if ((DateTime.Now - latestBillDate).TotalDays >= 30)
                    {
                        // Закриття з'єднання, так як воно вже не потрібне
                        dataBase.closeConnection(connection);
                        return true;
                    }
                }

                // Закриття з'єднання в будь-якому випадку
                dataBase.closeConnection(connection);
                return false;
            }
        }

        // Метод для отримання всіх ідентифікаторів клієнтів з бази даних
        private List<short> GetAllClientIds()
        {
            List<short> clientIds = new List<short>();

            // SQL-запит для отримання всіх ідентифікаторів клієнтів
            string query = "SELECT IdClient FROM Client";

            // Виконання SQL-запиту
            using (SqlConnection connection = dataBase.getConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                dataBase.openConnection(connection);

                SqlDataReader reader = command.ExecuteReader();

                // Читання результатів запиту та додавання ідентифікаторів до списку
                while (reader.Read())
                {
                    short clientId = reader.GetInt16(0);
                    clientIds.Add(clientId);
                }

                reader.Close();
                dataBase.closeConnection(connection);
            }

            return clientIds;
        }

        // Запит 1
        private void buttonLoadClientRequests_Click(object sender, EventArgs e)
        {
            LoadClientRequests(dataGridViewInfo);
        }

        private void LoadClientRequests(DataGridView dgw)
        {
            using (SqlConnection connection = dataBase.getConnection())
            {
                dataBase.openConnection(connection);
                string query = @"
        SELECT 
            C.SurnameC, C.NameC, C.PatronymicC, 
            CR.RequestDate, CR.RequestStatus, 
            B.DateCreation
        FROM 
            Client C
            JOIN ConnectionRequest CR ON C.IdClient = CR.IdClient
            JOIN Brigade B ON CR.IdBrigade = B.IdBrigade
        ORDER BY 
            CR.RequestDate DESC";

                SqlCommand command = new SqlCommand(query, connection);

                dgw.DataSource = null;
                DataTable dataTable = new DataTable();
                dataTable.Load(command.ExecuteReader());
                dgw.DataSource = dataTable;

                dgw.Columns["SurnameC"].HeaderText = "Прізвище";
                dgw.Columns["NameC"].HeaderText = "Ім'я";
                dgw.Columns["PatronymicC"].HeaderText = "По батькові";
                dgw.Columns["RequestDate"].HeaderText = "Дата заявки";
                dgw.Columns["RequestStatus"].HeaderText = "Статус заявки";
                dgw.Columns["DateCreation"].HeaderText = "Дата створення бригади";

                dataBase.closeConnection(connection);
            }
        }

        // Запит 2
        private void buttonFindClientsBySurname_Click(object sender, EventArgs e)
        {
            string letter = "Л";
            FindClientsBySurname(dataGridViewInfo, letter);
        }

        private void FindClientsBySurname(DataGridView dgw, string letter)
        {
            using (SqlConnection connection = dataBase.getConnection())
            {
                dataBase.openConnection(connection);
                string query = @"
        SELECT 
            C.SurnameC, C.NameC, C.PatronymicC, C.PhoneC
        FROM 
            Client C
        WHERE 
            C.SurnameC LIKE @Letter";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Letter", letter + "%");

                dgw.DataSource = null;
                DataTable dataTable = new DataTable();
                dataTable.Load(command.ExecuteReader());
                dgw.DataSource = dataTable;

                dgw.Columns["SurnameC"].HeaderText = "Прізвище";
                dgw.Columns["NameC"].HeaderText = "Ім'я";
                dgw.Columns["PatronymicC"].HeaderText = "По батькові";
                dgw.Columns["PhoneC"].HeaderText = "Телефон";

                dataBase.closeConnection(connection);
            }
        }

        // Запит 3
        private void buttonLoadRequestsByDate_Click(object sender, EventArgs e)
        {
            DateTime startDate = new DateTime(2023, 1, 1);
            DateTime endDate = new DateTime(2023, 12, 31);
            LoadRequestsByDate(dataGridViewInfo, startDate, endDate);
        }

        private void LoadRequestsByDate(DataGridView dgw, DateTime startDate, DateTime endDate)
        {
            using (SqlConnection connection = dataBase.getConnection())
            {
                dataBase.openConnection(connection);
                string query = @"
        SELECT 
            CR.IdRequest, C.SurnameC, C.NameC, CR.RequestDate, CR.RequestStatus
        FROM 
            Client C
            JOIN ConnectionRequest CR ON C.IdClient = CR.IdClient
        WHERE 
            CR.RequestDate BETWEEN @StartDate AND @EndDate";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);

                dgw.DataSource = null;
                DataTable dataTable = new DataTable();
                dataTable.Load(command.ExecuteReader());
                dgw.DataSource = dataTable;

                dgw.Columns["IdRequest"].HeaderText = "ID заявки";
                dgw.Columns["SurnameC"].HeaderText = "Прізвище";
                dgw.Columns["NameC"].HeaderText = "Ім'я";
                dgw.Columns["RequestDate"].HeaderText = "Дата заявки";
                dgw.Columns["RequestStatus"].HeaderText = "Статус заявки";

                dataBase.closeConnection(connection);
            }
        }

        // Запит 4
        private void buttonCountClients_Click(object sender, EventArgs e)
        {
            CountClients(dataGridViewInfo);
        }

        private void CountClients(DataGridView dgw)
        {
            using (SqlConnection connection = dataBase.getConnection())
            {
                dataBase.openConnection(connection);
                string query = @"
            SELECT 
                COUNT(*) AS TotalClients
            FROM 
                Client
            WHERE 
                IdUser IS NOT NULL";

                SqlCommand command = new SqlCommand(query, connection);

                dgw.DataSource = null;
                DataTable dataTable = new DataTable();
                dataTable.Load(command.ExecuteReader());
                dgw.DataSource = dataTable;

                dgw.Columns["TotalClients"].HeaderText = "Загальна кількість клієнтів";

                dataBase.closeConnection(connection);
            }
        }

        // Запит 5
        private void buttonCountRequestsByBrigadeDate_Click(object sender, EventArgs e)
        {
            CountRequestsByBrigadeDate(dataGridViewInfo);
        }

        private void CountRequestsByBrigadeDate(DataGridView dgw)
        {
            using (SqlConnection connection = dataBase.getConnection())
            {
                dataBase.openConnection(connection);
                string query = @"
        SELECT 
            B.DateCreation, COUNT(*) AS TotalRequests
        FROM 
            Brigade B
            JOIN ConnectionRequest CR ON B.IdBrigade = CR.IdBrigade
        GROUP BY 
            B.DateCreation";

                SqlCommand command = new SqlCommand(query, connection);

                dgw.DataSource = null;
                DataTable dataTable = new DataTable();
                dataTable.Load(command.ExecuteReader());
                dgw.DataSource = dataTable;

                dgw.Columns["DateCreation"].HeaderText = "Дата створення бригади";
                dgw.Columns["TotalRequests"].HeaderText = "Кількість заявок";

                dataBase.closeConnection(connection);
            }
        }

        // Запит 6
        private void buttonEmployeeWithMostRequests_Click(object sender, EventArgs e)
        {
            EmployeeWithMostRequests(dataGridViewInfo);
        }

        private void EmployeeWithMostRequests(DataGridView dgw)
        {
            using (SqlConnection connection = dataBase.getConnection())
            {
                dataBase.openConnection(connection);
                string query = @"
        SELECT 
            J.TitleJ, E.SurnameE, E.NameE, COUNT(*) AS TotalRequests
        FROM 
            Employee E
            JOIN JobTitle J ON E.JobTitleId = J.IdJobTitle
            JOIN Brigade B ON E.BrigadeId = B.IdBrigade
            JOIN ConnectionRequest CR ON B.IdBrigade = CR.IdBrigade
        GROUP BY 
            J.TitleJ, E.SurnameE, E.NameE
        HAVING 
            COUNT(*) >= ALL (SELECT COUNT(*) 
                             FROM ConnectionRequest 
                             GROUP BY IdBrigade)";

                SqlCommand command = new SqlCommand(query, connection);

                dgw.DataSource = null;
                DataTable dataTable = new DataTable();
                dataTable.Load(command.ExecuteReader());
                dgw.DataSource = dataTable;

                dgw.Columns["TitleJ"].HeaderText = "Посада";
                dgw.Columns["SurnameE"].HeaderText = "Прізвище";
                dgw.Columns["NameE"].HeaderText = "Ім'я";
                dgw.Columns["TotalRequests"].HeaderText = "Кількість заявок";

                dataBase.closeConnection(connection);
            }
        }

        // Запит 7
        private void buttonMaxRequestsByJobTitle_Click(object sender, EventArgs e)
        {
            MaxRequestsByJobTitle(dataGridViewInfo);
        }

        private void MaxRequestsByJobTitle(DataGridView dgw)
        {
            using (SqlConnection connection = dataBase.getConnection())
            {
                dataBase.openConnection(connection);
                string query = @"
        SELECT 
            J.TitleJ, E.SurnameE, E.NameE
        FROM 
            Employee E
            JOIN JobTitle J ON E.JobTitleId = J.IdJobTitle
        WHERE 
            E.IdEmployee = (SELECT TOP 1 IdEmployee 
                            FROM Employee E2 
                            WHERE E2.JobTitleId = J.IdJobTitle 
                            ORDER BY (SELECT COUNT(*) 
                                      FROM ConnectionRequest CR 
                                      WHERE CR.IdBrigade = E2.BrigadeId) DESC)";

                SqlCommand command = new SqlCommand(query, connection);

                dgw.DataSource = null;
                DataTable dataTable = new DataTable();
                dataTable.Load(command.ExecuteReader());
                dgw.DataSource = dataTable;

                dgw.Columns["TitleJ"].HeaderText = "Посада";
                dgw.Columns["SurnameE"].HeaderText = "Прізвище";
                dgw.Columns["NameE"].HeaderText = "Ім'я";

                dataBase.closeConnection(connection);
            }
        }

        //Запит 8
        private void buttonEmployeesNoRequestsLastWeek_Click(object sender, EventArgs e)
        {
            EmployeesNoRequestsLastWeek(dataGridViewInfo);
        }

        private void EmployeesNoRequestsLastWeek(DataGridView dgw)
        {
            using (SqlConnection connection = dataBase.getConnection())
            {
                dataBase.openConnection(connection);
                string query = @"
                SELECT 
                    E.SurnameE, E.NameE
                FROM 
                    Employee E
                WHERE 
                    E.BrigadeId NOT IN (SELECT IdBrigade 
                                        FROM ConnectionRequest 
                                        WHERE RequestDate BETWEEN @StartDate AND @EndDate)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StartDate", new DateTime(2023, 6, 1));
                command.Parameters.AddWithValue("@EndDate", new DateTime(2023, 6, 7));

                dgw.DataSource = null;
                DataTable dataTable = new DataTable();
                dataTable.Load(command.ExecuteReader());
                dgw.DataSource = dataTable;

                dgw.Columns["SurnameE"].HeaderText = "Прізвище";
                dgw.Columns["NameE"].HeaderText = "Ім'я";

                dataBase.closeConnection(connection);
            }
        }

        // Запит 9
        private void buttonBrigadeComments_Click(object sender, EventArgs e)
        {
            LoadBrigadeComments(dataGridViewInfo);
        }

        private void LoadBrigadeComments(DataGridView dgw)
        {
            using (SqlConnection connection = dataBase.getConnection())
            {
                dataBase.openConnection(connection);
                string query = @"
                        SELECT 
                            B.IdBrigade, 
                            'Має виконані роботи' AS Коментар
                        FROM 
                            Brigade B
                        JOIN 
                            ConnectionRequest CR ON B.IdBrigade = CR.IdBrigade

                        UNION

                        SELECT 
                            B.IdBrigade, 
                            'Не має виконаних робіт' AS Коментар
                        FROM 
                            Brigade B
                        WHERE 
                            B.IdBrigade NOT IN (
                                SELECT 
                                    CR.IdBrigade
                                FROM 
                                    ConnectionRequest CR
                            );";

                SqlCommand command = new SqlCommand(query, connection);

                dgw.DataSource = null;
                DataTable dataTable = new DataTable();
                dataTable.Load(command.ExecuteReader());
                dgw.DataSource = dataTable;

                dgw.Columns["IdBrigade"].HeaderText = "ID Бригади";
                dgw.Columns["Коментар"].HeaderText = "Коментар";

                dataBase.closeConnection(connection);
            }
        }
    }
}
