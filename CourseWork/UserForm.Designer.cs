namespace CourseWork
{
    partial class UserForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonPersonalView = new System.Windows.Forms.Button();
            this.buttonAccidentReportView = new System.Windows.Forms.Button();
            this.buttonConnectionRequestView = new System.Windows.Forms.Button();
            this.buttonPersonalEdit = new System.Windows.Forms.Button();
            this.dataGridViewInfo = new System.Windows.Forms.DataGridView();
            this.buttonAccidentRequest = new System.Windows.Forms.Button();
            this.buttonConnectionRequest = new System.Windows.Forms.Button();
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
            this.mainPanel.Controls.Add(this.label4);
            this.mainPanel.Controls.Add(this.button1);
            this.mainPanel.Controls.Add(this.label3);
            this.mainPanel.Controls.Add(this.label2);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.buttonPersonalView);
            this.mainPanel.Controls.Add(this.buttonAccidentReportView);
            this.mainPanel.Controls.Add(this.buttonConnectionRequestView);
            this.mainPanel.Controls.Add(this.buttonPersonalEdit);
            this.mainPanel.Controls.Add(this.dataGridViewInfo);
            this.mainPanel.Controls.Add(this.buttonAccidentRequest);
            this.mainPanel.Controls.Add(this.buttonConnectionRequest);
            this.mainPanel.Controls.Add(this.panel2);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1037, 640);
            this.mainPanel.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(618, 341);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(393, 25);
            this.label4.TabIndex = 13;
            this.label4.Text = "Кнопки, для редагування даних та оплати";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(832, 378);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 56);
            this.button1.TabIndex = 12;
            this.button1.Text = "Оплата рахунків";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(627, 471);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(384, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "Кнопки, для керування вікном перегляду";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(676, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(288, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Кнопки, для створення заявок";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(5, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Вікно, для перегляду інформації:";
            // 
            // buttonPersonalView
            // 
            this.buttonPersonalView.Location = new System.Drawing.Point(636, 508);
            this.buttonPersonalView.Name = "buttonPersonalView";
            this.buttonPersonalView.Size = new System.Drawing.Size(166, 56);
            this.buttonPersonalView.TabIndex = 8;
            this.buttonPersonalView.Text = "Переглянути особисті дані";
            this.buttonPersonalView.UseVisualStyleBackColor = true;
            this.buttonPersonalView.Click += new System.EventHandler(this.buttonPersonalView_Click);
            // 
            // buttonAccidentReportView
            // 
            this.buttonAccidentReportView.Location = new System.Drawing.Point(742, 570);
            this.buttonAccidentReportView.Name = "buttonAccidentReportView";
            this.buttonAccidentReportView.Size = new System.Drawing.Size(166, 56);
            this.buttonAccidentReportView.TabIndex = 7;
            this.buttonAccidentReportView.Text = "Переглянути заявки на аварії";
            this.buttonAccidentReportView.UseVisualStyleBackColor = true;
            this.buttonAccidentReportView.Click += new System.EventHandler(this.buttonAccidentReportView_Click);
            // 
            // buttonConnectionRequestView
            // 
            this.buttonConnectionRequestView.Location = new System.Drawing.Point(832, 508);
            this.buttonConnectionRequestView.Name = "buttonConnectionRequestView";
            this.buttonConnectionRequestView.Size = new System.Drawing.Size(166, 56);
            this.buttonConnectionRequestView.TabIndex = 6;
            this.buttonConnectionRequestView.Text = "Переглянути заявку на підключення";
            this.buttonConnectionRequestView.UseVisualStyleBackColor = true;
            this.buttonConnectionRequestView.Click += new System.EventHandler(this.buttonConnectionRequestView_Click);
            // 
            // buttonPersonalEdit
            // 
            this.buttonPersonalEdit.Location = new System.Drawing.Point(636, 378);
            this.buttonPersonalEdit.Name = "buttonPersonalEdit";
            this.buttonPersonalEdit.Size = new System.Drawing.Size(166, 56);
            this.buttonPersonalEdit.TabIndex = 5;
            this.buttonPersonalEdit.Text = "Редагування особистих даних";
            this.buttonPersonalEdit.UseVisualStyleBackColor = true;
            this.buttonPersonalEdit.Click += new System.EventHandler(this.buttonEditPersonalEdit_Click);
            // 
            // dataGridViewInfo
            // 
            this.dataGridViewInfo.AllowUserToAddRows = false;
            this.dataGridViewInfo.AllowUserToDeleteRows = false;
            this.dataGridViewInfo.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataGridViewInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInfo.Location = new System.Drawing.Point(4, 166);
            this.dataGridViewInfo.Name = "dataGridViewInfo";
            this.dataGridViewInfo.ReadOnly = true;
            this.dataGridViewInfo.RowHeadersWidth = 51;
            this.dataGridViewInfo.RowTemplate.Height = 24;
            this.dataGridViewInfo.Size = new System.Drawing.Size(555, 467);
            this.dataGridViewInfo.TabIndex = 4;
            // 
            // buttonAccidentRequest
            // 
            this.buttonAccidentRequest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(156)))), ((int)(((byte)(246)))));
            this.buttonAccidentRequest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonAccidentRequest.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAccidentRequest.Location = new System.Drawing.Point(832, 205);
            this.buttonAccidentRequest.Name = "buttonAccidentRequest";
            this.buttonAccidentRequest.Size = new System.Drawing.Size(168, 85);
            this.buttonAccidentRequest.TabIndex = 3;
            this.buttonAccidentRequest.Text = "Заявка на усунення аварії";
            this.buttonAccidentRequest.UseVisualStyleBackColor = false;
            this.buttonAccidentRequest.Click += new System.EventHandler(this.buttonAccidentRequest_Click);
            // 
            // buttonConnectionRequest
            // 
            this.buttonConnectionRequest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(156)))), ((int)(((byte)(246)))));
            this.buttonConnectionRequest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonConnectionRequest.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonConnectionRequest.Location = new System.Drawing.Point(636, 205);
            this.buttonConnectionRequest.Name = "buttonConnectionRequest";
            this.buttonConnectionRequest.Size = new System.Drawing.Size(168, 85);
            this.buttonConnectionRequest.TabIndex = 2;
            this.buttonConnectionRequest.Text = "Заявка на підключення до системи водопостачання";
            this.buttonConnectionRequest.UseVisualStyleBackColor = false;
            this.buttonConnectionRequest.Click += new System.EventHandler(this.buttonConnectionRequest_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(228)))), ((int)(((byte)(143)))));
            this.panel2.Controls.Add(this.closeButton);
            this.panel2.Controls.Add(this.labelPanel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1033, 128);
            this.panel2.TabIndex = 0;
            // 
            // closeButton
            // 
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.Font = new System.Drawing.Font("Arial Narrow", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeButton.Location = new System.Drawing.Point(1006, 0);
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
            this.labelPanel.Size = new System.Drawing.Size(1033, 128);
            this.labelPanel.TabIndex = 0;
            this.labelPanel.Text = "Обліковий запис користувача";
            this.labelPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelPanel_MouseDown);
            this.labelPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelPanel_MouseMove);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 640);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserForm";
            this.Load += new System.EventHandler(this.UserForm_Load);
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
        private System.Windows.Forms.Button buttonConnectionRequest;
        private System.Windows.Forms.Button buttonAccidentRequest;
        private System.Windows.Forms.DataGridView dataGridViewInfo;
        private System.Windows.Forms.Button buttonPersonalEdit;
        private System.Windows.Forms.Button buttonPersonalView;
        private System.Windows.Forms.Button buttonAccidentReportView;
        private System.Windows.Forms.Button buttonConnectionRequestView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}