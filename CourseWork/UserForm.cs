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

            using (SqlConnection connection = dataBase.getConnection())
            {
                connection.Open();
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
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Не вдалося створити заявку! " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
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


                    using (SqlConnection connection = dataBase.getConnection())
                    {
                        connection.Open();
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
                    }
                }
            }
        }
    }
}