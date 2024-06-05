using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CourseWork
{
    public partial class LoginForm : Form
    {

        Database dataBase = new Database();
        private bool selectedRole;

        public LoginForm()
        {
            InitializeComponent();
            // Вирівнюємо текст-бокс з паролем
            this.textBoxLock.AutoSize = false;
            this.textBoxLock.Size = new Size(this.textBoxUser.Width, 32);

            // Підписуємося на подію завантаження форми
            this.Shown += new EventHandler(LoginForm_Shown);
        }

        public LoginForm(bool selectedRole)
        {
            InitializeComponent();

            this.selectedRole = selectedRole;

            // Вирівнюємо текст-бокс з паролем
            this.textBoxLock.AutoSize = false;
            this.textBoxLock.Size = new Size(this.textBoxUser.Width, 32);

            // Підписуємося на подію завантаження форми
            this.Shown += new EventHandler(LoginForm_Shown);

        }

        // Обробник потрібен, аби сфокусувати курсор не на текст-бокс
        // при запуску вікна
        private void LoginForm_Shown(object sender, EventArgs e)
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
        }

        // Посилання на вікно "Реєстрації"
        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(selectedRole == true)
                linkRegister.Enabled = false;
            else
            {
                RegisterForm frm = new RegisterForm(selectedRole);
                this.Hide();
                frm.ShowDialog();
                this.Close();
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

        // Надписи в полях текст-боксів
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

        // Запит до бази даних, авторизація до програми
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            var loginUser = textBoxUser.Text;
            var passwordUser = textBoxLock.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string isAdminValue = selectedRole ? "1" : "0";
            string queryString = $"SELECT iduser, loginuserr, passworduserr, isadmin FROM register WHERE loginuserr = '{loginUser}' AND passworduserr = '{passwordUser}' AND isadmin = {isAdminValue}";

            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                short userId = Convert.ToInt16(table.Rows[0]["iduser"]); // Отримати ідентифікатор користувача з результатів запиту

                SqlConnection connection = dataBase.getConnection();

                // Відкриваємо підключення до бази даних
                dataBase.openConnection(connection);

                // Здійснюємо другий запит для отримання ідентифікатора клієнта
                string clientQueryString = $"SELECT IdClient FROM Client WHERE IdUser = {userId}";
                SqlCommand clientCommand = new SqlCommand(clientQueryString, connection);
                short clientId = Convert.ToInt16(clientCommand.ExecuteScalar());

                // Закриваємо підключення до бази даних після виконання запиту
                dataBase.closeConnection(connection);

                if (selectedRole == false)
                {
                    MessageBox.Show("Авторизація пройшла!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UserForm userForm = new UserForm(clientId);
                    this.Hide();
                    userForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Авторизація пройшла!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AdminForm adminForm = new AdminForm();
                    this.Hide();
                    adminForm.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Обліковий запис не існує для даної ролі!", "Помилка авторизації!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void buttonRole_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            this.Hide();
            register.ShowDialog();
            this.Close();
        }
    }
}
