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
        private int currentClientId;
        private Database dataBase = new Database();

        public UserForm(int clientId)
        {
            currentClientId = clientId;
            InitializeComponent();
            InitializeButtons();
        }

        private void InitializeButtons()
        {
            Button buttonPersonalInfo = new Button();
            buttonPersonalInfo.Text = "Особиста інформація";
            buttonPersonalInfo.Location = new Point(10, 10);
            buttonPersonalInfo.Click += (sender, e) => LoadPersonalInfo();
            this.Controls.Add(buttonPersonalInfo);

            Button buttonConnectionRequests = new Button();
            buttonConnectionRequests.Text = "Заявки на підключення";
            buttonConnectionRequests.Location = new Point(150, 10);
            buttonConnectionRequests.Click += (sender, e) => LoadConnectionRequests();
            this.Controls.Add(buttonConnectionRequests);

            Button buttonAccidentRequests = new Button();
            buttonAccidentRequests.Text = "Заявки на усунення аварій";
            buttonAccidentRequests.Location = new Point(300, 10);
            buttonAccidentRequests.Click += (sender, e) => LoadAccidentRequests();
            this.Controls.Add(buttonAccidentRequests);
        }

        private void LoadPersonalInfo()
        {
            using (SqlConnection connection = dataBase.getConnection())
            {
                connection.Open();
                string query = "SELECT SurnameC AS Прізвище, NameC AS Ім'я, PatronymicC AS По батькові, PhoneC AS Телефон, AddressC AS Адреса FROM Client WHERE IdClient = @idClient";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@idClient", currentClientId);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridViewInfo.DataSource = dataTable;
            }
        }

        private void LoadConnectionRequests()
        {
            using (SqlConnection connection = dataBase.getConnection())
            {
                connection.Open();
                string query = "SELECT RequestDate AS Дата_заявки, RequestStatus AS Статус, Details AS Деталі FROM ConnectionRequest WHERE IdClient = @idClient";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@idClient", currentClientId);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridViewInfo.DataSource = dataTable;
            }
        }

        private void LoadAccidentRequests()
        {
            using (SqlConnection connection = dataBase.getConnection())
            {
                connection.Open();
                string query = "SELECT ReportDate AS Дата_заявки, ReportStatus AS Статус, Details AS Деталі FROM AccidentReport WHERE IdClient = @idClient";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@idClient", currentClientId);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridViewInfo.DataSource = dataTable;
            }
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
                    string insertRequestQuery = "INSERT INTO ConnectionRequest (IdClient, RequestDate, RequestStatus, Details) VALUES (@idClient, @requestDate, @status, @details)";
                    SqlCommand commandRequest = new SqlCommand(insertRequestQuery, connection, transaction);
                    commandRequest.Parameters.AddWithValue("@idClient", currentClientId);
                    commandRequest.Parameters.AddWithValue("@requestDate", DateTime.Now);
                    commandRequest.Parameters.AddWithValue("@status", "Новий");
                    commandRequest.Parameters.AddWithValue("@details", details);

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
                            string insertRequestQuery = "INSERT INTO AccidentReport (IdClient, ReportDate, ReportStatus, Details) VALUES (@idClient, @reportDate, @status, @details)";
                            SqlCommand commandRequest = new SqlCommand(insertRequestQuery, connection, transaction);
                            commandRequest.Parameters.AddWithValue("@idClient", currentClientId);
                            commandRequest.Parameters.AddWithValue("@reportDate", DateTime.Now);
                            commandRequest.Parameters.AddWithValue("@status", "Новий");
                            commandRequest.Parameters.AddWithValue("@details", $"Деталі: {details}");

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
    }
}