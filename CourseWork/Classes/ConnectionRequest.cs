using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private string _workDate;
        private short _idBrigade;

        Brigade brigade = new Brigade();
        private Material material = new Material();

        public ConnectionRequest(short idRequest, DateTime requestDate, string requestStatus, string details)
        {
            InitializeComponent();

            _idRequest = idRequest;
            _requestDate = requestDate;
            _requestStatus = requestStatus;
            _details = details;

            ViewRequest();
        }

        private void ViewRequest()
        {
            textBoxId.Text = _idRequest.ToString();
            textBoxRequestDate.Text = _requestDate.ToString("dd/MM/yyyy HH:mm");
            textBoxRequestState.Text = _requestStatus;
            textBoxDetails.Text = _details;

            textBoxId.ReadOnly = true;
            textBoxRequestDate.ReadOnly = true;
            textBoxDetails.ReadOnly = true;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            recordDatatime();
        }

        private void recordDatatime()
        {
            DateTime selectedDate = dateTimePicker1.Value;
            Brigade[] freeBrigades = brigade.AssignBrigade(selectedDate);

            comboBoxBrigade.Items.Clear();

            foreach (Brigade brigade in freeBrigades)
            {
                comboBoxBrigade.Items.Add(brigade.Id);
            }
        }


        private void ConnectionRequest_Load(object sender, EventArgs e)
        {
            string requestType = "Підключення до системи";

            List<(int MaterialId, int Quantity)> requiredMaterials = material.CheckMaterials(requestType);

            comboBoxNeedMaterial.Items.Clear();

            foreach (var material in requiredMaterials)
            {
                // Кожен елемент матеріалу може бути доданий як рядок до комбобоксу
                comboBoxNeedMaterial.Items.Add($"{material.MaterialId}: {material.Quantity}");
            }
        }
    }
}
