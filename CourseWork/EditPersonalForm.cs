using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CourseWork
{
    public partial class EditPersonalForm : Form
    {
        private int clientId;
        public string NewPhone { get; private set; }
        public string NewAddress { get; private set; }

        private Database dataBase = new Database();

        public EditPersonalForm(int clientId)
        {
            InitializeComponent();
            this.clientId = clientId;

            comboBoxPhone.Items.AddRange(new object[] { "050", "066", "095", "099", "067", "068", "096", "097", "098", "063", "073", "093" });
            comboBoxAddress.Items.AddRange(new object[] { "Магістральна", "Ланжеронівська", "Калинова", "Закарпатська", "Житомирська", "Єлісаветинська", "Естонська", "Дем’янова", "Гагаріна", "Вапняна" });
            
            LoadClientInfo();
            this.Shown += new EventHandler(EditPersonalForm_Shown);
        }

        // Обробник потрібен, аби сфокусувати курсор не на текст-бокс
        // при запуску вікна
        private void EditPersonalForm_Shown(object sender, EventArgs e)
        {
            labelPanel.Focus();

            if (string.IsNullOrEmpty(textBoxPhone.Text))
            {
                textBoxPhone.Text = "Введіть телефон";
                textBoxPhone.ForeColor = Color.Gray;
            }
        }

        // Надписи в полях текст-боксу 
        private void textBoxPhone_Enter(object sender, EventArgs e)
        {
            if (textBoxPhone.Text == "Введіть телефон")
            {
                textBoxPhone.Text = "";
                textBoxPhone.ForeColor = Color.Black;
            }
        }

        private void textBoxPhone_Leave(object sender, EventArgs e)
        {
            if (textBoxPhone.Text == "")
            {
                textBoxPhone.Text = "Введіть телефон";
                textBoxPhone.ForeColor = Color.Gray;
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

        private void LoadClientInfo()
        {
            using (SqlConnection connection = dataBase.getConnection())
            {
                dataBase.openConnection(connection);
                string query = "SELECT PhoneC, AddressC FROM Client WHERE IdClient = @idClient";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idClient", clientId);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string phone = reader["PhoneC"].ToString();
                    string address = reader["AddressC"].ToString();

                    // Assuming comboBoxPhone contains the prefixes
                    string phonePrefix = phone.Substring(0, 3); // Get the prefix
                    string phoneNumber = phone.Substring(3); // Get the rest of the number

                    comboBoxPhone.Text = phonePrefix;
                    textBoxPhone.Text = phoneNumber;
                    comboBoxAddress.Text = address;
                }

                reader.Close();
                dataBase.closeConnection(connection);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string numberPhone = comboBoxPhone.Text + textBoxPhone.Text.Trim();

            if (!IsPhoneValid(numberPhone))
            {
                MessageBox.Show("Телефон повинен містити не менше 7 цифр.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (IsPhoneExists(textBoxPhone.Text.Trim()))
            {
                MessageBox.Show("Цей номер телефону вже існує.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NewPhone = numberPhone;
            NewAddress = comboBoxAddress.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        // Метод для перевірки існування користувача з таким номером телефону в базі даних
        private bool IsPhoneExists(string phone)
        {
            SqlConnection connection = dataBase.getConnection();

            dataBase.openConnection(connection);

            string queryString = $"SELECT COUNT(*) FROM Client WHERE PhoneC = @phone";

            SqlCommand command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@phone", phone);


            int count = (int)command.ExecuteScalar();

            dataBase.closeConnection(connection);

            return count > 0;
        }


        // Метод для перевірки чи номер телефону містить не менше 7 цифр
        private bool IsPhoneValid(string phone)
        {
            return Regex.IsMatch(phone, @"^\d{7}$");
        }

        // Ввід лише цифр
        private void textBoxPhone_TextChanged(object sender, EventArgs e)
        {
            string text = textBoxPhone.Text;
            textBoxPhone.ForeColor = Color.Black;
            textBoxPhone.Text = Regex.Replace(text, "[^0-9]", ""); // Видаляємо всі символи, які не є цифрами

        }
    }
}
