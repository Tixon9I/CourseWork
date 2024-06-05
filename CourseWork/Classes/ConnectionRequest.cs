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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CourseWork.Classes
{
    public partial class ConnectionRequest : Form
    {
        private short _idRequest;
        private DateTime _requestDate;
        private string _requestStatus;
        private string _details;
        private decimal fixedAmount;

        public DateTime workDate;

        Database dataBase = new Database();

        Brigade brigade = new Brigade();
        Material material = new Material();
        WriteOffMaterials writeOffMaterials = new WriteOffMaterials();
        Invoice invoice = new Invoice();

        // Глобальна колекція для зберігання вибраних матеріалів
        List<(short MaterialId, string RequestType, int Quantity)> selectedMaterials = new List<(short MaterialId, string RequestType, int Quantity)>();

        public ConnectionRequest(short idRequest, DateTime requestDate, string requestStatus, string details)
        {
            InitializeComponent();

            dateTimePickerTime.Format = DateTimePickerFormat.Custom;
            dateTimePickerTime.CustomFormat = "HH:mm"; 
            dateTimePickerTime.ShowUpDown = true; 
            dateTimePickerTime.Value = DateTime.Today; 
            
            dateTimePickerDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerDate.CustomFormat = "dd.MM.yyyy";

            _idRequest = idRequest;
            _requestDate = requestDate;
            _requestStatus = requestStatus;
            _details = details;

            this.Shown += new EventHandler(ConnectionRequest_Shown);

            ViewRequest();
        }

        private void ViewRequest()
        {
            textBoxId.Text = _idRequest.ToString();
            textBoxRequestDate.Text = _requestDate.ToString("dd.MM.yyyy HH:mm");
            textBoxRequestState.Text = "Оновлено";
            textBoxDetails.Text = _details;

            textBoxRequestState.ReadOnly = true;
            textBoxId.ReadOnly = true;
            textBoxRequestDate.ReadOnly = true;
            textBoxDetails.ReadOnly = true;
        }

        private void ConnectionRequest_Shown(object sender, EventArgs e)
        {
            labelPanel.Focus();
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

        private void ConnectionRequest_Load(object sender, EventArgs e)
        {
            string requestType = "Підключення до системи водопостачання";

            selectedMaterials = material.CheckMaterials(requestType);

            if (selectedMaterials.Count == 0)
            {
                MessageBox.Show("Потрібно здійснити закупку необхідних матеріалів!", "Повідомлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                this.Close();
                return;
            }

            comboBoxNeedMaterial.Items.Clear();

            foreach (var material in selectedMaterials)
            {
                // Кожен елемент матеріалу може бути доданий як рядок до комбобоксу
                comboBoxNeedMaterial.Items.Add($"{material.RequestType}: {material.Quantity}");
            }

            fixedAmount = invoice.GetAmountForRequestType(requestType);
        }

        private void AssignBrigade()
        {
            DateTime selectedDate = dateTimePickerDate.Value.Date;
            TimeSpan selectedTime = dateTimePickerTime.Value.TimeOfDay;
            DateTime dateTimeCombined = selectedDate.Add(selectedTime);

            Brigade[] freeBrigades = brigade.AssignBrigade(dateTimeCombined);

            comboBoxBrigade.Items.Clear();

            foreach (Brigade brigade in freeBrigades)
            {
                comboBoxBrigade.Items.Add(brigade.Id);
            }
        }

        private void dateTimePickerTime_ValueChanged(object sender, EventArgs e)
        {
            AssignBrigade();
        }

        // Метод для додавання нового запису в таблицю ConnectionRequest
        private void UpdateConnectionRequest(short requestId)
        {
            DateTime date = dateTimePickerDate.Value.Date;
            TimeSpan time = dateTimePickerTime.Value.TimeOfDay;
            DateTime workDate = date.Add(time); // Об'єднати дату та час

            _requestStatus = "Оновлено";
            short selectedBrigadeId = Convert.ToInt16(comboBoxBrigade.SelectedItem);

            using (SqlConnection connection = dataBase.getConnection())
            {
                dataBase.openConnection(connection);
                string query = @"
                        UPDATE ConnectionRequest 
                        SET RequestStatus = @RequestStatus,
                            IdBrigade = @IdBrigade,
                            WorkDate = @WorkDate,
                            SumRequest = @SumRequest
                        WHERE IdRequest = @IdRequest";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RequestStatus", _requestStatus);
                command.Parameters.AddWithValue("@IdBrigade", selectedBrigadeId);
                command.Parameters.AddWithValue("@WorkDate", workDate);
                command.Parameters.AddWithValue("@SumRequest", fixedAmount);
                command.Parameters.AddWithValue("@IdRequest", requestId);

                command.ExecuteNonQuery();
                dataBase.closeConnection(connection);
            }
        }

        private bool AreRequiredFieldsFilled()
        {
            List<string> errorMessages = new List<string>();

            // Перевірка, чи було обрано значення для DateTimePicker
            if (dateTimePickerTime.Value.TimeOfDay == TimeSpan.Zero)
            {
                errorMessages.Add("Час");
            }
            if (dateTimePickerDate.Value.Date == new DateTime(2024, 6, 3))
            {
                errorMessages.Add("Дата");
            }

            // Перевірка, чи було обрано значення для ComboBox
            if (comboBoxBrigade.SelectedItem == null)
            {
                errorMessages.Add("Бригада");
            }
            if (comboBoxNeedMaterial.SelectedItem == null)
            {
                errorMessages.Add("Матеріал");
            }

            // Відображення повідомлення, якщо є помилки
            if (errorMessages.Count > 0)
            {
                MessageBox.Show("Будь ласка, заповніть наступні поля: " + string.Join(", ", errorMessages), "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void WriteOffMaterials(short materialId, string requestType, int quantity, DateTime writeOffDate, short requestId)
        {
            //WriteOffMaterials writeOffMaterials = new WriteOffMaterials();
            writeOffMaterials.AddWriteOffMaterials(materialId, requestType, quantity, writeOffDate, requestId);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (!AreRequiredFieldsFilled())
            {
                return;
            }

            UpdateConnectionRequest(_idRequest);

            comboBoxNeedMaterial_SelectedIndexChanged(sender, e);
        }

        private void comboBoxNeedMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Отримати вибраний елемент
            string selectedItem = comboBoxNeedMaterial.SelectedItem.ToString();

            // Знайти відповідний матеріал у списку
            var selectedMaterial = selectedMaterials.FirstOrDefault(m => $"{m.RequestType}: {m.Quantity}" == selectedItem);

            if (selectedMaterial != default)
            {
                // Викликати функцію WriteOffMaterials
                short materialId = selectedMaterial.MaterialId;
                string requestType = selectedMaterial.RequestType;
                int quantity = selectedMaterial.Quantity;
                DateTime writeOffDate = dateTimePickerDate.Value.Date.Add(dateTimePickerTime.Value.TimeOfDay);
                short idRequest = _idRequest; // Використовується з глобальної змінної

                WriteOffMaterials(materialId, requestType, quantity, writeOffDate, idRequest);

                // Закрити форму або виконати інші необхідні дії
                this.Close();
            }
            else
            {
                // Обробка випадку, коли матеріал не знайдено (якщо необхідно)
                MessageBox.Show("Матеріал не знайдено у списку.");
            }
        }
    }
}
