using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CourseWork
{
    public partial class RegisterForm : Form
    {

        Database dataBase = new Database();
        private bool selectedRole;

        public RegisterForm(bool selectedRole)
        {
            InitializeComponent();

            this.selectedRole = selectedRole;

            this.Shown += new EventHandler(RegisterForm_Shown);
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

        // Надписи в полях текст-боксу 
        private void textBoxName_Enter(object sender, EventArgs e)
        {
            if(textBoxName.Text == "Введіть ім'я")
            {
                textBoxName.Text = "";
                textBoxName.ForeColor = Color.Black;
            }
                
        }

        private void textBoxName_Leave(object sender, EventArgs e)
        {
            if (textBoxName.Text == "")
            {
                textBoxName.Text = "Введіть ім'я";
                textBoxName.ForeColor = Color.Gray;
            }         
        }

        private void textBoxSurname_Enter(object sender, EventArgs e)
        {
            if (textBoxSurname.Text == "Введіть прізвище")
            {
                textBoxSurname.Text = "";
                textBoxSurname.ForeColor = Color.Black;
            }
        }

        private void textBoxSurname_Leave(object sender, EventArgs e)
        {
            if (textBoxSurname.Text == "")
            {
                textBoxSurname.Text = "Введіть прізвище";
                textBoxSurname.ForeColor = Color.Gray;
            }
        }

        private void textBoxPatronymic_Enter(object sender, EventArgs e)
        {
            if (textBoxPatronymic.Text == "Введіть по-батькові")
            {
                textBoxPatronymic.Text = "";
                textBoxPatronymic.ForeColor = Color.Black;
            }
        }

        private void textBoxPatronymic_Leave(object sender, EventArgs e)
        {
            if (textBoxPatronymic.Text == "")
            {
                textBoxPatronymic.Text = "Введіть по-батькові";
                textBoxPatronymic.ForeColor = Color.Gray;
            }
        }

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

        private void textBoxAddress_Enter(object sender, EventArgs e)
        {
            if (textBoxAddress.Text == "Введіть адресу")
            {
                textBoxAddress.Text = "";
                textBoxAddress.ForeColor = Color.Black;
            }
        }

        private void textBoxAddress_Leave(object sender, EventArgs e)
        {
            if (textBoxAddress.Text == "")
            {
                textBoxAddress.Text = "Введіть адресу";
                textBoxAddress.ForeColor = Color.Gray;
            }
        }

        private void textBoxUser_Enter(object sender, EventArgs e)
        {
            if (textBoxUser.Text == "Введіть логін")
            {
                textBoxUser.Text = "";
                textBoxUser.ForeColor = Color.Black;
            }
        }

        private void textBoxUser_Leave(object sender, EventArgs e)
        {
            if (textBoxUser.Text == "")
            {
                textBoxUser.Text = "Введіть логін";
                textBoxUser.ForeColor = Color.Gray;
            }
        }

        private void textBoxLock_Enter(object sender, EventArgs e)
        {
            if (textBoxLock.Text == "Введіть пароль")
            {
                textBoxLock.UseSystemPasswordChar = true;
                textBoxLock.Text = "";
                textBoxLock.ForeColor = Color.Black;
            }
        }

        private void textBoxLock_Leave(object sender, EventArgs e)
        {
            if (textBoxLock.Text == "")
            {
                textBoxLock.UseSystemPasswordChar = false;
                textBoxLock.Text = "Введіть пароль";
                textBoxLock.ForeColor = Color.Gray;
            }
        }

        // Обробник потрібен, аби сфокусувати курсор не на текст-бокс
        // при запуску вікна
        private void RegisterForm_Shown(object sender, EventArgs e)
        {
            labelPanel.Focus();

            // Встановлюємо текст у текстових полях, якщо вони пусті
            if (string.IsNullOrEmpty(textBoxUser.Text))
            {
                textBoxUser.Text = "Введіть логін";
                textBoxUser.ForeColor = Color.Gray;
            }

            if (string.IsNullOrEmpty(textBoxLock.Text))
            {
                textBoxLock.UseSystemPasswordChar = false;
                textBoxLock.Text = "Введіть пароль";
                textBoxLock.ForeColor = Color.Gray;
            }

            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                textBoxName.Text = "Введіть ім'я";
                textBoxName.ForeColor = Color.Gray;
            }

            if (string.IsNullOrEmpty(textBoxSurname.Text))
            {
                textBoxSurname.Text = "Введіть прізвище";
                textBoxSurname.ForeColor = Color.Gray;
            }

            if (string.IsNullOrEmpty(textBoxPatronymic.Text))
            {
                textBoxPatronymic.Text = "Введіть по-батькові";
                textBoxPatronymic.ForeColor = Color.Gray;
            }

            if (string.IsNullOrEmpty(textBoxPhone.Text))
            {
                textBoxPhone.Text = "Введіть телефон";
                textBoxPhone.ForeColor = Color.Gray;
            }

            if (string.IsNullOrEmpty(textBoxAddress.Text))
            {
                textBoxAddress.Text = "Введіть адресу";
                textBoxAddress.ForeColor = Color.Gray;
            }
        }

        // Показати/Сховати текст в текст-боксі Password
        private void pictureBoxLook_Click(object sender, EventArgs e)
        {
            textBoxLock.UseSystemPasswordChar = false;
            pictureBoxLook.Visible = false;
            pictureBoxHidden.Visible = true;
        }

        private void pictureBoxHidden_Click(object sender, EventArgs e)
        {
            if (textBoxLock.Text == "Введіть пароль")
            {
                textBoxLock.UseSystemPasswordChar = false;
                textBoxLock.Text = "Введіть пароль";
                textBoxLock.ForeColor = Color.Gray;
            }
            else
                textBoxLock.UseSystemPasswordChar = true;

            pictureBoxLook.Visible = true;
            pictureBoxHidden.Visible = false;
        }

        // Метод реєстрації юзера
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            var login = textBoxUser.Text;
            var password = textBoxLock.Text;
            var name = textBoxName.Text;
            var surname = textBoxSurname.Text;
            var patronymic = textBoxPatronymic.Text;
            var phone = textBoxPhone.Text;
            var address = textBoxAddress.Text;

            if (IsLoginExists(login))
            {
                MessageBox.Show("Користувач з таким логіном вже існує!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection connection = dataBase.getConnection())
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Додавання запису до таблиці Register
                    string insertUserQuery = "INSERT INTO Register (LoginUserR, PasswordUserR, IsAdmin) OUTPUT INSERTED.IdUser VALUES (@login, @password, 0)";
                    SqlCommand commandUser = new SqlCommand(insertUserQuery, connection, transaction);
                    commandUser.Parameters.AddWithValue("@login", login);
                    commandUser.Parameters.AddWithValue("@password", password);

                    int userId = Convert.ToInt32(commandUser.ExecuteScalar());

                    // Додавання запису до таблиці Client
                    string insertClientQuery = "INSERT INTO Client (SurnameC, NameC, PatronymicC, PhoneC, AddressC, IdUser) VALUES (@surname, @name, @patronymic, @phone, @address, @userId)";
                    SqlCommand commandClient = new SqlCommand(insertClientQuery, connection, transaction);
                    commandClient.Parameters.AddWithValue("@surname", surname);
                    commandClient.Parameters.AddWithValue("@name", name);
                    commandClient.Parameters.AddWithValue("@patronymic", patronymic);
                    commandClient.Parameters.AddWithValue("@phone", phone);
                    commandClient.Parameters.AddWithValue("@address", address);
                    commandClient.Parameters.AddWithValue("@userId", userId);

                    commandClient.ExecuteNonQuery();

                    transaction.Commit();

                    MessageBox.Show("Успішно створено!", "Успішно", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoginForm loginForm = new LoginForm();
                    this.Hide();
                    loginForm.ShowDialog();
                    this.Close();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Не вдалося створити обліковий запис! " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // Метод для перевірки існування користувача з таким логіном в базі даних
        private bool IsLoginExists(string login)
        {
            string queryString = $"SELECT COUNT(*) FROM register WHERE LoginUserR = '{login}'";

            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());

            dataBase.openConnection();

            int count = (int)command.ExecuteScalar();

            dataBase.closeConnection();

            return count > 0;
        }

        // Поверненнся до вікна авторизації
        private void buttonBackLogin_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            this.Hide();
            loginForm.ShowDialog();
            this.Close();
        }

    }
}
