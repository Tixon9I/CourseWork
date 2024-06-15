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
    public partial class UserForm : Form
    {
        private short currentClientId;
        private Database dataBase = new Database();

        public UserForm(short clientId)
        {
            currentClientId = clientId;
            InitializeComponent();
        }


        private void buttonEditPersonalEdit_Click(object sender, EventArgs e)
        {
            using (EditPersonalForm editForm = new EditPersonalForm(currentClientId))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    // Оновлення особистої інформації
                    string newPhone = editForm.NewPhone;
                    string newAddress = editForm.NewAddress;

                    UpdatePersonalInfo(newPhone, newAddress);
                    UpdateClientRequestsPhone(newPhone);
                    UpdateClientPhoneInReports(newPhone);
                }
            }
        }

        private void UpdatePersonalInfo(string newPhone, string newAddress)
        {
            using (SqlConnection connection = dataBase.getConnection())
            {
                dataBase.openConnection(connection);
                string updateQuery = "UPDATE Client SET PhoneC = @newPhone, AddressC = @newAddress WHERE IdClient = @idClient";

                SqlCommand command = new SqlCommand(updateQuery, connection);
                command.Parameters.AddWithValue("@newPhone", newPhone);
                command.Parameters.AddWithValue("@newAddress", newAddress);
                command.Parameters.AddWithValue("@idClient", currentClientId);

                command.ExecuteNonQuery();
                dataBase.closeConnection(connection);
            }
        }

        private void UpdateClientRequestsPhone(string newPhone)
        {
            using (SqlConnection connection = dataBase.getConnection())
            {
                dataBase.openConnection(connection);
                string updateQuery = "UPDATE ConnectionRequest SET PhoneC = @newPhone WHERE IdClient = @idClient";

                SqlCommand command = new SqlCommand(updateQuery, connection);
                command.Parameters.AddWithValue("@newPhone", newPhone);
                command.Parameters.AddWithValue("@idClient", currentClientId);

                command.ExecuteNonQuery();
                dataBase.closeConnection(connection);
            }
        }

        private void UpdateClientPhoneInReports(string newPhone)
        {
            using (SqlConnection connection = dataBase.getConnection())
            {
                dataBase.openConnection(connection);

                string updateQuery = "UPDATE AccidentReport SET PhoneC = @newPhone WHERE IdClient = @idClient";
                SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                updateCommand.Parameters.AddWithValue("@newPhone", newPhone);
                updateCommand.Parameters.AddWithValue("@idClient", currentClientId);

                updateCommand.ExecuteNonQuery();

                dataBase.closeConnection(connection);
            }
        }

        // Показ записів з бд на DataGridView (Інфо клієнта)
        private void buttonPersonalView_Click(object sender, EventArgs e)
        {
            LoadPersonalInfo(dataGridViewInfo);
        }

        private void LoadPersonalInfo(DataGridView dgw)
        {
            using (SqlConnection connection = dataBase.getConnection())
            {
                dataBase.openConnection(connection);
                string query = "SELECT SurnameC, NameC, PatronymicC, PhoneC, AddressC FROM Client WHERE IdClient = @idClient";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idClient", currentClientId);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    dgw.DataSource = dataTable;

                    dgw.Columns["SurnameC"].HeaderText = "Прізвище";
                    dgw.Columns["NameC"].HeaderText = "Ім'я";
                    dgw.Columns["PatronymicC"].HeaderText = "По батькові";
                    dgw.Columns["PhoneC"].HeaderText = "Телефон";
                    dgw.Columns["AddressC"].HeaderText = "Адреса";
                }

                dataBase.closeConnection(connection);
            }
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
            CR.RequestDate, 
            CR.RequestStatus, 
            CR.Details,
            CR.IdBrigade,
            CR.WorkDate,
            CR.SumRequest,
            C.SurnameC, 
            C.NameC, 
            C.PatronymicC, 
            CR.PhoneC, 
            CR.AddressC 
        FROM 
            ConnectionRequest CR
        INNER JOIN 
            Client C ON CR.IdClient = C.IdClient
        WHERE 
            CR.IdClient = @idClient";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idClient", currentClientId);

                SqlDataReader reader = command.ExecuteReader();

                dgw.DataSource = null; // Очистимо дані, щоб видалити попередні записи
                DataTable dataTable = new DataTable(); // Створимо новий DataTable для збереження результатів запиту
                dataTable.Load(reader); // Завантажимо дані з SqlDataReader до DataTable
                dgw.DataSource = dataTable; // Прив'яжемо DataTable до DataGridView

                // Змінимо назви стовпців
                dgw.Columns["RequestDate"].HeaderText = "Дата заявки";
                dgw.Columns["RequestStatus"].HeaderText = "Статус заявки";
                dgw.Columns["Details"].HeaderText = "Деталі";
                dgw.Columns["IdBrigade"].HeaderText = "ID Бригади";
                dgw.Columns["WorkDate"].HeaderText = "Дата виконання";
                dgw.Columns["SumRequest"].HeaderText = "Сума заявки";
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
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = dataBase.getConnection())
            {
                connection.Open();
                string query = @"
        SELECT 
            AR.ReportDate, 
            AR.ReportStatus, 
            AR.Details,
            AR.IdBrigade,
            AR.WorkDate,
            AR.SumRequest,
            C.SurnameC, 
            C.NameC, 
            C.PatronymicC, 
            AR.PhoneC, 
            AR.AddressC 
        FROM 
            AccidentReport AR
        INNER JOIN 
            Client C ON AR.IdClient = C.IdClient
        WHERE 
            AR.IdClient = @idClient";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idClient", currentClientId);

                dgw.DataSource = null; // Очистимо дані, щоб видалити попередні записи
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);
            }

            dgw.DataSource = dataTable;

            // Зміна назв стовпців у DataGridView
            dgw.Columns["ReportDate"].HeaderText = "Дата заявки";
            dgw.Columns["ReportStatus"].HeaderText = "Статус заявки";
            dgw.Columns["Details"].HeaderText = "Деталі";
            dgw.Columns["IdBrigade"].HeaderText = "ID Бригади";
            dgw.Columns["WorkDate"].HeaderText = "Дата виконання";
            dgw.Columns["SumRequest"].HeaderText = "Сума заявки";
            dgw.Columns["SurnameC"].HeaderText = "Прізвище";
            dgw.Columns["NameC"].HeaderText = "Ім'я";
            dgw.Columns["PatronymicC"].HeaderText = "По батькові";
            dgw.Columns["PhoneC"].HeaderText = "Телефон";
            dgw.Columns["AddressC"].HeaderText = "Адреса";
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

        // Заявка на підключення до системи
        private void buttonConnectionRequest_Click(object sender, EventArgs e)
        {
            string details = "Підключення до системи водопостачання";

            SqlConnection connection = dataBase.getConnection();

            dataBase.openConnection(connection);
            using (connection)
            {
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Отримання адреси та номера телефону клієнта за його ID
                    string getAddressPhoneQuery = "SELECT AddressC, PhoneC FROM Client WHERE IdClient = @idClient";
                    SqlCommand getAddressPhoneCommand = new SqlCommand(getAddressPhoneQuery, connection, transaction);
                    getAddressPhoneCommand.Parameters.AddWithValue("@idClient", currentClientId);

                    SqlDataReader reader = getAddressPhoneCommand.ExecuteReader();
                    string address = "";
                    string phone = "";

                    if (reader.Read())
                    {
                        address = reader["AddressC"].ToString();
                        phone = reader["PhoneC"].ToString();
                    }
                    reader.Close();

                    // Запит на створення заявки
                    string insertRequestQuery = @"
                INSERT INTO ConnectionRequest (IdClient, RequestDate, RequestStatus, Details, PhoneC, AddressC) 
                VALUES (@idClient, @requestDate, @status, @details, @phone, @address)";

                    SqlCommand commandRequest = new SqlCommand(insertRequestQuery, connection, transaction);
                    commandRequest.Parameters.AddWithValue("@idClient", currentClientId);
                    commandRequest.Parameters.AddWithValue("@requestDate", DateTime.Now);
                    commandRequest.Parameters.AddWithValue("@status", "Новий");
                    commandRequest.Parameters.AddWithValue("@details", details);
                    commandRequest.Parameters.AddWithValue("@phone", phone);
                    commandRequest.Parameters.AddWithValue("@address", address);

                    commandRequest.ExecuteNonQuery();
                    transaction.Commit();

                    MessageBox.Show("Заявка успішно створена!", "Успішно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    buttonConnectionRequest.Enabled = false; // Зробити кнопку недоступною після успішного створення заявки
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Не вдалося створити заявку! " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                finally
                {
                    dataBase.closeConnection(connection);
                }
            }
        }

        // Метод для перевірки та налаштування доступності кнопки при завантаженні форми
        private void CheckConnectionRequestStatus()
        {
            using (SqlConnection connection = dataBase.getConnection())
            {
                connection.Open();

                // Перевіряємо, чи існує заявка на підключення для даного клієнта
                string checkRequestQuery = "SELECT COUNT(*) FROM ConnectionRequest WHERE IdClient = @idClient";
                SqlCommand checkCommand = new SqlCommand(checkRequestQuery, connection);
                checkCommand.Parameters.AddWithValue("@idClient", currentClientId);

                int requestCount = (int)checkCommand.ExecuteScalar();

                if (requestCount > 0)
                {
                    buttonConnectionRequest.Enabled = false; // Зробити кнопку недоступною
                }
            }
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            CheckConnectionRequestStatus();
        }

        // Заявка на усунення аварії
        private void buttonAccidentRequest_Click(object sender, EventArgs e)
        {
            if (!CanCreateNewAccidentRequest())
            {
                MessageBox.Show("Ви вже створили заявку на усунення аварії сьогодні. Будь ласка, спробуйте знову завтра.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (AccidentRequest accidentRequestForm = new AccidentRequest())
            {
                if (accidentRequestForm.ShowDialog() == DialogResult.OK)
                {
                    string details = accidentRequestForm.SelectedDetails;

                    if (string.IsNullOrWhiteSpace(details))
                    {
                        MessageBox.Show("Будь ласка, виберіть деталі аварії.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    SqlConnection connection = dataBase.getConnection();

                    dataBase.openConnection(connection);
                    using (connection)
                    {
                        SqlTransaction transaction = connection.BeginTransaction();

                        try
                        {
                            // Отримання адреси та номера телефону клієнта
                            string getAddressPhoneQuery = "SELECT AddressC, PhoneC FROM Client WHERE IdClient = @idClient";
                            SqlCommand getAddressPhoneCommand = new SqlCommand(getAddressPhoneQuery, connection, transaction);
                            getAddressPhoneCommand.Parameters.AddWithValue("@idClient", currentClientId);

                            SqlDataReader reader = getAddressPhoneCommand.ExecuteReader();
                            string address = "";
                            string phone = "";

                            if (reader.Read())
                            {
                                address = reader["AddressC"].ToString();
                                phone = reader["PhoneC"].ToString();
                            }
                            reader.Close();

                            // Запит на створення заявки на аварію
                            string insertRequestQuery = @"
                            INSERT INTO AccidentReport (IdClient, ReportDate, ReportStatus, Details, PhoneC, AddressC) 
                            VALUES (@idClient, @reportDate, @status, @details, @phone, @address)";
                            SqlCommand commandRequest = new SqlCommand(insertRequestQuery, connection, transaction);
                            commandRequest.Parameters.AddWithValue("@idClient", currentClientId);
                            commandRequest.Parameters.AddWithValue("@reportDate", DateTime.Now);
                            commandRequest.Parameters.AddWithValue("@status", "Новий");
                            commandRequest.Parameters.AddWithValue("@details", $"Деталі: {details}");
                            commandRequest.Parameters.AddWithValue("@phone", phone);
                            commandRequest.Parameters.AddWithValue("@address", address);

                            commandRequest.ExecuteNonQuery();
                            transaction.Commit();

                            MessageBox.Show("Заявка на аварію успішно створена!", "Успішно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Не вдалося створити заявку на аварію! " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        finally
                        {
                            dataBase.closeConnection(connection);
                        }
                    }
                }
            }
        }

        private bool CanCreateNewAccidentRequest()
        {
            using (SqlConnection connection = dataBase.getConnection())
            {
                dataBase.openConnection(connection);
                string query = "SELECT TOP 1 ReportDate FROM AccidentReport WHERE IdClient = @idClient ORDER BY ReportDate DESC";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idClient", currentClientId);

                var lastReportDate = command.ExecuteScalar() as DateTime?;

                if (lastReportDate.HasValue && lastReportDate.Value.Date == DateTime.Now.Date)
                {
                    return false;
                }

                return true;
            }
        }

        // Оплата рахунків
        private void buttonPay_Click(object sender, EventArgs e)
        {
            DateTime paymentDate = DateTime.Now;

            List<short> paidBillIds = UpdateUnpaidBillsForClient(currentClientId, paymentDate);
            List<short> updatedConnectionRequestIds = UpdateUnpaidConnectionRequestsForClient(currentClientId, paymentDate);
            List<short> updatedAccidentReportIds = UpdateUnpaidAccidentReportsForClient(currentClientId, paymentDate);

            string message = "";

            if (paidBillIds.Count > 0)
            {
                message += "Оплачено рахунки з ID: " + string.Join(", ", paidBillIds) + "\n";
            }
            else
            {
                message += "Рахунків для оплати не знайдено.\n";
            }

            if (updatedConnectionRequestIds.Count > 0)
            {
                message += "Оплачено заявки на підключення з ID: " + string.Join(", ", updatedConnectionRequestIds) + "\n";
            }
            else
            {
                message += "Заявок на підключення для оплати не знайдено.\n";
            }

            if (updatedAccidentReportIds.Count > 0)
            {
                message += "Оплачено звіти про аварії з ID: " + string.Join(", ", updatedAccidentReportIds);
            }
            else
            {
                message += "Звітів про аварії для оплати не знайдено.";
            }

            MessageBox.Show(message, "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private List<short> UpdateUnpaidBillsForClient(short clientId, DateTime paymentDate)
        {
            List<short> paidBillIds = new List<short>();

            using (SqlConnection connection = dataBase.getConnection())
            {
                string query = @"
                UPDATE WaterBill
                SET 
                    DueDate = @PaymentDate,
                    BillStatus = 'Оплачено'
                WHERE 
                    IdClient = @ClientId
                    AND BillStatus = 'Неоплачено'";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PaymentDate", paymentDate);
                command.Parameters.AddWithValue("@ClientId", clientId);

                dataBase.openConnection(connection);
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    // Якщо хоч один рядок був змінений, додаємо ID рахунку до списку оплачених рахунків
                    paidBillIds.Add(clientId);
                }
                dataBase.closeConnection(connection);
            }

            return paidBillIds;
        }

        private List<short> UpdateUnpaidAccidentReportsForClient(short clientId, DateTime paymentDate)
        {
            List<short> updatedReportIds = new List<short>();

            using (SqlConnection connection = dataBase.getConnection())
            {
                string query = @"
                            UPDATE AccidentReport
                        SET ReportStatus = 'Оплачено'
                        WHERE IdClient = @ClientId
                        AND SumRequest > 0";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ClientId", clientId);

                dataBase.openConnection(connection);
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    // Додаємо ID звіту про аварію до списку оновлених звітів
                    updatedReportIds.Add(clientId);
                }
                dataBase.closeConnection(connection);
            }

            return updatedReportIds;
        }

        private List<short> UpdateUnpaidConnectionRequestsForClient(short clientId, DateTime paymentDate)
        {
            List<short> updatedRequestIds = new List<short>();

            using (SqlConnection connection = dataBase.getConnection())
            {
                string query = @"
                            UPDATE ConnectionRequest
                        SET RequestStatus = 'Оплачено'
                        WHERE IdClient = @ClientId
                        AND SumRequest > 0";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ClientId", clientId);

                dataBase.openConnection(connection);
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    // Додаємо ID заявки на підключення до списку оновлених заявок
                    updatedRequestIds.Add(clientId);
                }
                dataBase.closeConnection(connection);
            }

            return updatedRequestIds;
        }
    }
}