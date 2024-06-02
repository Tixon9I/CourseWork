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
    // Потрібне для відображення даних в DataGridView
    
    public partial class UserForm : Form
    {
        private int currentClientId;
        private Database dataBase = new Database();

        public UserForm(int clientId)
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
            dataGridViewInfo.Columns.Clear(); // Очистити стовпці

            CreateColumnsPersonalInfo();
             
            LoadPersonalInfo(dataGridViewInfo);
        }

        private void LoadPersonalInfo(DataGridView dgw)
        {
            dgw.Rows.Clear();

            using (SqlConnection connection = dataBase.getConnection())
            {
                dataBase.openConnection(connection);
                string query = "SELECT SurnameC, NameC, PatronymicC, PhoneC, AddressC FROM Client WHERE IdClient = @idClient";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idClient", currentClientId);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ReadSingleRowPersonalInfo(dgw, reader);
                }
                reader.Close();
                dataBase.closeConnection(connection);
            }
        }

        private void CreateColumnsPersonalInfo()
        {
            dataGridViewInfo.Columns.Add("SurnameC", "Прізвище");
            dataGridViewInfo.Columns.Add("NameC", "Ім'я");
            dataGridViewInfo.Columns.Add("PatronymicC", "По-батькові");
            dataGridViewInfo.Columns.Add("PhoneC", "Телефон");
            dataGridViewInfo.Columns.Add("AddressC", "Адреса");
           // dataGridViewInfo.Columns.Add("IsNew", String.Empty);
        }

        private void ReadSingleRowPersonalInfo(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetString(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4));
        }

        // Показ записів з бд на DataGridView (Заявка на підключення)
        private void buttonConnectionRequestView_Click(object sender, EventArgs e)
        {
            dataGridViewInfo.Columns.Clear(); // Очистити стовпці
            
            CreateColumnsConnectionRequests();
                
            LoadConnectionRequests(dataGridViewInfo);
        }

        private void LoadConnectionRequests(DataGridView dgw)
        {
            dgw.Rows.Clear();

            using (SqlConnection connection = dataBase.getConnection())
            {
                dataBase.openConnection(connection);
                string query = @"
            SELECT 
                CR.RequestDate, 
                CR.RequestStatus, 
                CR.Details,
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

                while (reader.Read())
                {
                    ReadSingleRowConnectionRequests(dgw, reader);
                }
                reader.Close();
                dataBase.closeConnection(connection);
            }
        }

        private void CreateColumnsConnectionRequests()
        {
            dataGridViewInfo.Columns.Clear(); // Очистити старі стовпці перед додаванням нових

            dataGridViewInfo.Columns.Add("RequestDate", "Дата та час заявки");
            dataGridViewInfo.Columns.Add("RequestStatus", "Статус");
            dataGridViewInfo.Columns.Add("Details", "Деталі");
            dataGridViewInfo.Columns.Add("SurnameC", "Прізвище");
            dataGridViewInfo.Columns.Add("NameC", "Ім'я");
            dataGridViewInfo.Columns.Add("PatronymicC", "По-батькові");
            dataGridViewInfo.Columns.Add("PhoneC", "Телефон");
            dataGridViewInfo.Columns.Add("AddressC", "Адреса");
        }

        private void ReadSingleRowConnectionRequests(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetDateTime(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetString(5), record.GetString(6), record.GetString(7));
        }

        // Показ записів з бд на DataGridView (Заявки на усунення аварії)
        private void buttonAccidentReportView_Click(object sender, EventArgs e)
        {
            dataGridViewInfo.Columns.Clear(); // Очистити стовпці

            CreateColumnsAccidentRequests();

            LoadAccidentRequests(dataGridViewInfo);
        }

        private void LoadAccidentRequests(DataGridView dgw)
        {
            dgw.Rows.Clear();

            using (SqlConnection connection = dataBase.getConnection())
            {
                dataBase.openConnection(connection);
                string query = @"
            SELECT 
                AR.ReportDate, 
                AR.ReportStatus, 
                AR.Details,
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

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ReadSingleRowAccidentRequests(dgw, reader);
                }
                reader.Close();
                dataBase.closeConnection(connection);
            }
        }

        private void CreateColumnsAccidentRequests()
        {
            dataGridViewInfo.Columns.Clear(); // Очистити старі стовпці перед додаванням нових

            dataGridViewInfo.Columns.Add("ReportDate", "Дата та час заявки");
            dataGridViewInfo.Columns.Add("ReportStatus", "Статус");
            dataGridViewInfo.Columns.Add("Details", "Деталі");
            dataGridViewInfo.Columns.Add("SurnameC", "Прізвище");
            dataGridViewInfo.Columns.Add("NameC", "Ім'я");
            dataGridViewInfo.Columns.Add("PatronymicC", "По-батькові");
            dataGridViewInfo.Columns.Add("PhoneC", "Телефон");
            dataGridViewInfo.Columns.Add("AddressC", "Адреса");
        }

        private void ReadSingleRowAccidentRequests(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetDateTime(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetString(5), record.GetString(6), record.GetString(7));
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

    }
}