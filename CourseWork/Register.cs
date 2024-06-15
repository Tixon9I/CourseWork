using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class Register : Form
    {
        public bool SelectedRole { get; private set; }

        public Register()
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

        private void buttonUser_Click(object sender, EventArgs e)
        {
            SelectedRole = false;
            LoginForm loginForm = new LoginForm(SelectedRole); // Передача обраної ролі
            this.Hide();
            loginForm.ShowDialog();
            this.Close();
        }

        private void buttonEmployee_Click(object sender, EventArgs e)
        {
            SelectedRole = true;
            LoginForm loginForm = new LoginForm(SelectedRole); // Передача обраної ролі
            this.Hide();
            loginForm.ShowDialog();
            this.Close();
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
    }
}
