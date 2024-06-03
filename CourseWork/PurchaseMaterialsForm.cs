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
    public partial class PurchaseMaterialsForm : Form
    {
        Database dataBase = new Database();

        public PurchaseMaterialsForm()
        {
            InitializeComponent();

            this.Shown += new EventHandler(PurchaseMaterialsForm_Shown);

            comboBoxCountMaterial.Items.AddRange(new object[] { "5", "10", "15", "20", "25" });
            comboBoxTypeRequest.Items.AddRange(new object[] { "Усунення аварій", "Підключення до системи" });
            GetMaterials();
            GetProvider();

        }

        private void PurchaseMaterialsForm_Shown(object sender, EventArgs e)
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

        // Отримання даних для комбобокса Material
        private void GetMaterials()
        {
            using (SqlConnection connection = dataBase.getConnection())
            {
                string query = "SELECT IdMaterial, NameM FROM Material";
                SqlCommand command = new SqlCommand(query, connection);
                dataBase.openConnection(connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    short idMaterial = reader.GetInt16(0);
                    string materialName = reader.GetString(1);
                    comboBoxMaterial.Items.Add(new KeyValuePair<short, string>(idMaterial, materialName));
                }

                reader.Close();
                dataBase.closeConnection(connection);
            }

            // Встановлення властивості DisplayMember для показу значень другого
            comboBoxMaterial.DisplayMember = "Value";
        }

        // Отримання даних для комбобокса Provider
        private void GetProvider()
        {
            using (SqlConnection connection = dataBase.getConnection())
            {
                string query = "SELECT IdProvider, NameP FROM Provider";
                SqlCommand command = new SqlCommand(query, connection);
                dataBase.openConnection(connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    short idProvider = reader.GetInt16(0);
                    string providerName = reader.GetString(1);
                    comboBoxProvider.Items.Add(new KeyValuePair<short, string>(idProvider, providerName));
                }

                reader.Close();
                dataBase.closeConnection(connection);
            }

            // Встановлення властивості DisplayMember для показу значень другого
            comboBoxProvider.DisplayMember = "Value";
        }



        public void AddPurchaseAndRequestMaterials(int materialId, int providerId, int countMaterials, DateTime purchaseDate, decimal price, string typeRequest)
        {
            using (SqlConnection connection = dataBase.getConnection())
            {
                dataBase.openConnection(connection);

                // Додавання запису до таблиці PurchaseMaterials
                string purchaseQuery = @"
            INSERT INTO PurchaseMaterials (MaterialId, ProviderId, CountMaterialsP, PurchaseDateP, PriceP)
            VALUES (@MaterialId, @ProviderId, @CountMaterials, @PurchaseDate, @Price)";
                SqlCommand purchaseCommand = new SqlCommand(purchaseQuery, connection);
                purchaseCommand.Parameters.AddWithValue("@MaterialId", materialId);
                purchaseCommand.Parameters.AddWithValue("@ProviderId", providerId);
                purchaseCommand.Parameters.AddWithValue("@CountMaterials", countMaterials);
                purchaseCommand.Parameters.AddWithValue("@PurchaseDate", purchaseDate);
                purchaseCommand.Parameters.AddWithValue("@Price", price);
                purchaseCommand.ExecuteNonQuery();

                // Перевірка наявності запису у таблиці RequestMaterials
                string checkQuery = @"
            SELECT COUNT(*) 
            FROM RequestMaterials 
            WHERE RequestType = @RequestType AND MaterialId = @MaterialId";
                SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                checkCommand.Parameters.AddWithValue("@RequestType", typeRequest);
                checkCommand.Parameters.AddWithValue("@MaterialId", materialId);
                int count = (int)checkCommand.ExecuteScalar();

                // Якщо запис вже існує, виведемо повідомлення
                if (count > 0)
                {
                    MessageBox.Show("Цей матеріал вже є в наявності.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Додавання запису до таблиці RequestMaterials
                    string requestQuery = @"
                INSERT INTO RequestMaterials (RequestType, MaterialId, Quantity)
                VALUES (@RequestType, @MaterialId, @Quantity)";
                    SqlCommand requestCommand = new SqlCommand(requestQuery, connection);
                    requestCommand.Parameters.AddWithValue("@RequestType", typeRequest);
                    requestCommand.Parameters.AddWithValue("@MaterialId", materialId);
                    requestCommand.Parameters.AddWithValue("@Quantity", countMaterials);
                    requestCommand.ExecuteNonQuery();

                    // Повідомлення про успішну купівлю матеріалів
                    MessageBox.Show("Матеріали успішно куплені!", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                dataBase.closeConnection(connection);
            }
        }


        private void buttonPurchase_Click(object sender, EventArgs e)
        {
            // Перевірка наявності обраних значень у комбобоксах
            if (comboBoxMaterial.SelectedItem == null || comboBoxProvider.SelectedItem == null || comboBoxCountMaterial.SelectedItem == null || comboBoxTypeRequest.SelectedItem == null)
            {
                MessageBox.Show("Будь ласка, оберіть значення для всіх полів.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Отримання обраних значень з комбобоксів
            KeyValuePair<short, string> selectedMaterial = (KeyValuePair<short, string>)comboBoxMaterial.SelectedItem;
            short materialId = selectedMaterial.Key;

            KeyValuePair<short, string> selectedProvider = (KeyValuePair<short, string>)comboBoxProvider.SelectedItem;
            short providerId = selectedProvider.Key;

            int countMaterials = int.Parse(comboBoxCountMaterial.SelectedItem.ToString());
            DateTime purchaseDate = DateTime.Now;
            decimal price = countMaterials * 10;

            string typeRequest = comboBoxTypeRequest.SelectedItem.ToString();

            // Додавання запису до бази даних
            AddPurchaseAndRequestMaterials(materialId, providerId, countMaterials, purchaseDate, price, typeRequest);
        }

    }
}
