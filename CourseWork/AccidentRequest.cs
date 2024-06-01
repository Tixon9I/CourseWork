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
    public partial class AccidentRequest : Form
    {
        public string SelectedDetails { get; set; }

        public AccidentRequest()
        {
            InitializeComponent();

            comboBoxAccident.Items.AddRange(new string[]
        {
            "Пошкодження водопроводу",
            "Прорив труби",
            "Забруднення води",
            "Несправність насосу",
            "Пошкодження вентиля",
            "Перекриття води",
            "Проблема з тиском води",
            "Неочікувана зупинка водопостачання",
            "Витік води з резервуару",
            "Інша аварія"
        });

            // Налаштовуємо ToolTip
            toolTip1.ToolTipTitle = "Підказка";
            toolTip1.UseFading = true;
            toolTip1.UseAnimation = true;
            toolTip1.IsBalloon = true;
            toolTip1.ShowAlways = true;
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;

            // Встановлюємо текст для ToolTip
            toolTip1.SetToolTip(pictureBoxHelp, "Всі ваші дані, автоматично підтягнені. Ввести лише потрібно деталі аварії.");
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

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            string selectedDetails = comboBoxAccident.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(selectedDetails))
            {
                MessageBox.Show("Будь ласка, виберіть деталі аварії.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Передача обраних деталей та встановлення DialogResult на OK
            SelectedDetails = selectedDetails;
            this.DialogResult = DialogResult.OK;
        }
    }
}
