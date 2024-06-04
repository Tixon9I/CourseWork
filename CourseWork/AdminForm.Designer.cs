namespace CourseWork
{
    partial class AdminForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainPanel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonPurchaseMaterial = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonBill = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAccidentReportView = new System.Windows.Forms.Button();
            this.buttonConnectionRequestView = new System.Windows.Forms.Button();
            this.dataGridViewInfo = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Label();
            this.labelPanel = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInfo)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(156)))), ((int)(((byte)(246)))));
            this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mainPanel.Controls.Add(this.label5);
            this.mainPanel.Controls.Add(this.buttonPurchaseMaterial);
            this.mainPanel.Controls.Add(this.label4);
            this.mainPanel.Controls.Add(this.buttonBill);
            this.mainPanel.Controls.Add(this.label3);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.buttonAccidentReportView);
            this.mainPanel.Controls.Add(this.buttonConnectionRequestView);
            this.mainPanel.Controls.Add(this.dataGridViewInfo);
            this.mainPanel.Controls.Add(this.panel2);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1048, 645);
            this.mainPanel.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(828, 398);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(186, 23);
            this.label5.TabIndex = 27;
            this.label5.Text = "Кнопка для закупівлі";
            // 
            // buttonPurchaseMaterial
            // 
            this.buttonPurchaseMaterial.Location = new System.Drawing.Point(841, 438);
            this.buttonPurchaseMaterial.Name = "buttonPurchaseMaterial";
            this.buttonPurchaseMaterial.Size = new System.Drawing.Size(166, 56);
            this.buttonPurchaseMaterial.TabIndex = 26;
            this.buttonPurchaseMaterial.Text = "Закупівля матеріалів";
            this.buttonPurchaseMaterial.UseVisualStyleBackColor = true;
            this.buttonPurchaseMaterial.Click += new System.EventHandler(this.buttonPurchaseMaterial_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(608, 377);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(199, 44);
            this.label4.TabIndex = 25;
            this.label4.Text = "Кнопка для створення\r\nрозрахунків";
            // 
            // buttonBill
            // 
            this.buttonBill.Location = new System.Drawing.Point(623, 438);
            this.buttonBill.Name = "buttonBill";
            this.buttonBill.Size = new System.Drawing.Size(166, 56);
            this.buttonBill.TabIndex = 24;
            this.buttonBill.Text = "Сформування рахунків";
            this.buttonBill.UseVisualStyleBackColor = true;
            this.buttonBill.Click += new System.EventHandler(this.buttonBill_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(623, 526);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(384, 25);
            this.label3.TabIndex = 23;
            this.label3.Text = "Кнопки, для керування вікном перегляду";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 25);
            this.label1.TabIndex = 21;
            this.label1.Text = "Вікно, для перегляду інформації:";
            // 
            // buttonAccidentReportView
            // 
            this.buttonAccidentReportView.Location = new System.Drawing.Point(841, 568);
            this.buttonAccidentReportView.Name = "buttonAccidentReportView";
            this.buttonAccidentReportView.Size = new System.Drawing.Size(166, 56);
            this.buttonAccidentReportView.TabIndex = 19;
            this.buttonAccidentReportView.Text = "Переглянути заявки на аварії";
            this.buttonAccidentReportView.UseVisualStyleBackColor = true;
            this.buttonAccidentReportView.Click += new System.EventHandler(this.buttonAccidentReportView_Click);
            // 
            // buttonConnectionRequestView
            // 
            this.buttonConnectionRequestView.Location = new System.Drawing.Point(623, 568);
            this.buttonConnectionRequestView.Name = "buttonConnectionRequestView";
            this.buttonConnectionRequestView.Size = new System.Drawing.Size(166, 56);
            this.buttonConnectionRequestView.TabIndex = 18;
            this.buttonConnectionRequestView.Text = "Переглянути заявку на підключення";
            this.buttonConnectionRequestView.UseVisualStyleBackColor = true;
            this.buttonConnectionRequestView.Click += new System.EventHandler(this.buttonConnectionRequestView_Click);
            // 
            // dataGridViewInfo
            // 
            this.dataGridViewInfo.AllowUserToAddRows = false;
            this.dataGridViewInfo.AllowUserToDeleteRows = false;
            this.dataGridViewInfo.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataGridViewInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInfo.Location = new System.Drawing.Point(3, 171);
            this.dataGridViewInfo.Name = "dataGridViewInfo";
            this.dataGridViewInfo.ReadOnly = true;
            this.dataGridViewInfo.RowHeadersWidth = 51;
            this.dataGridViewInfo.RowTemplate.Height = 24;
            this.dataGridViewInfo.Size = new System.Drawing.Size(555, 467);
            this.dataGridViewInfo.TabIndex = 16;
            this.dataGridViewInfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewInfo_CellDoubleClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(228)))), ((int)(((byte)(143)))));
            this.panel2.Controls.Add(this.closeButton);
            this.panel2.Controls.Add(this.labelPanel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1044, 128);
            this.panel2.TabIndex = 0;
            // 
            // closeButton
            // 
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.Font = new System.Drawing.Font("Arial Narrow", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeButton.Location = new System.Drawing.Point(988, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(28, 29);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "x";
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            this.closeButton.MouseEnter += new System.EventHandler(this.closeButton_MouseEnter);
            this.closeButton.MouseLeave += new System.EventHandler(this.closeButton_MouseLeave);
            // 
            // labelPanel
            // 
            this.labelPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPanel.Font = new System.Drawing.Font("Arial", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPanel.Location = new System.Drawing.Point(0, 0);
            this.labelPanel.Name = "labelPanel";
            this.labelPanel.Size = new System.Drawing.Size(1044, 128);
            this.labelPanel.TabIndex = 0;
            this.labelPanel.Text = "Середовище працівника";
            this.labelPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelPanel_MouseDown);
            this.labelPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelPanel_MouseMove);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 645);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminForm";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInfo)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label closeButton;
        private System.Windows.Forms.Label labelPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonBill;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAccidentReportView;
        private System.Windows.Forms.Button buttonConnectionRequestView;
        private System.Windows.Forms.DataGridView dataGridViewInfo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonPurchaseMaterial;
    }
}