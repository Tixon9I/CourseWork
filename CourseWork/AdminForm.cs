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
                        CR.IdRequest, 
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
                        Client C ON CR.IdClient = C.IdClient";

                SqlCommand command = new SqlCommand(query, connection);

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

            dataGridViewInfo.Columns.Add("IdRequest", "Ідентифікатор заявки");
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
            int idRequest = record.GetInt16(0); // IdRequest is SMALLINT, so use GetInt16
            DateTime requestDate = record.GetDateTime(1);
            string requestStatus = record.IsDBNull(2) ? string.Empty : record.GetString(2);
            string details = record.IsDBNull(3) ? string.Empty : record.GetString(3);
            string surnameC = record.IsDBNull(4) ? string.Empty : record.GetString(4);
            string nameC = record.IsDBNull(5) ? string.Empty : record.GetString(5);
            string patronymicC = record.IsDBNull(6) ? string.Empty : record.GetString(6);
            string phoneC = record.IsDBNull(7) ? string.Empty : record.GetString(7);
            string addressC = record.IsDBNull(8) ? string.Empty : record.GetString(8);

            dgw.Rows.Add(idRequest, requestDate, requestStatus, details, surnameC, nameC, patronymicC, phoneC, addressC);
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
                        AR.IdReport,
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
                        Client C ON AR.IdClient = C.IdClient";

                SqlCommand command = new SqlCommand(query, connection);
                
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

            dataGridViewInfo.Columns.Add("IdReport", "Ідентифікатор заявки");
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
            int idReport = record.GetInt16(0); // IdReport is SMALLINT, so use GetInt16
            DateTime reportDate = record.GetDateTime(1);
            string reportStatus = record.IsDBNull(2) ? string.Empty : record.GetString(2);
            string details = record.IsDBNull(3) ? string.Empty : record.GetString(3);
            string surnameC = record.IsDBNull(4) ? string.Empty : record.GetString(4);
            string nameC = record.IsDBNull(5) ? string.Empty : record.GetString(5);
            string patronymicC = record.IsDBNull(6) ? string.Empty : record.GetString(6);
            string phoneC = record.IsDBNull(7) ? string.Empty : record.GetString(7);
            string addressC = record.IsDBNull(8) ? string.Empty : record.GetString(8);

            dgw.Rows.Add(idReport, reportDate, reportStatus, details, surnameC, nameC, patronymicC, phoneC, addressC);
        }

        private void dataGridViewInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Перевірте, чи було вибрано дійсний рядок
            {
                // Отримайте значення з обраного рядка
                short idRequest = Convert.ToInt16(dataGridViewInfo.Rows[e.RowIndex].Cells["IdRequest"].Value);
                DateTime requestDate = Convert.ToDateTime(dataGridViewInfo.Rows[e.RowIndex].Cells["RequestDate"].Value);
                string requestStatus = dataGridViewInfo.Rows[e.RowIndex].Cells["RequestStatus"].Value.ToString();
                string details = dataGridViewInfo.Rows[e.RowIndex].Cells["Details"].Value.ToString();

                // Відкрийте нову форму та передайте значення
                ConnectionRequest requestDetailsForm = new ConnectionRequest(idRequest, requestDate, requestStatus, details);
                requestDetailsForm.ShowDialog();
            }
        }
    }
}
