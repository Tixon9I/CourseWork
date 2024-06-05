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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonEmployeeComments = new System.Windows.Forms.Button();
            this.buttonEmployeeWithMostRequests = new System.Windows.Forms.Button();
            this.buttonLoadRequestsByDate = new System.Windows.Forms.Button();
            this.buttonEmployeesNoRequestsLastWeek = new System.Windows.Forms.Button();
            this.buttonCountRequestsByBrigadeDate = new System.Windows.Forms.Button();
            this.buttonFindClientsBySurname = new System.Windows.Forms.Button();
            this.buttonMaxRequestsByJobTitle = new System.Windows.Forms.Button();
            this.buttonCountClients = new System.Windows.Forms.Button();
            this.buttonLoadClientRequests = new System.Windows.Forms.Button();
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip4 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip5 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip6 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip7 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip8 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip9 = new System.Windows.Forms.ToolTip(this.components);
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInfo)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(156)))), ((int)(((byte)(246)))));
            this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mainPanel.Controls.Add(this.label2);
            this.mainPanel.Controls.Add(this.buttonEmployeeComments);
            this.mainPanel.Controls.Add(this.buttonEmployeeWithMostRequests);
            this.mainPanel.Controls.Add(this.buttonLoadRequestsByDate);
            this.mainPanel.Controls.Add(this.buttonEmployeesNoRequestsLastWeek);
            this.mainPanel.Controls.Add(this.buttonCountRequestsByBrigadeDate);
            this.mainPanel.Controls.Add(this.buttonFindClientsBySurname);
            this.mainPanel.Controls.Add(this.buttonMaxRequestsByJobTitle);
            this.mainPanel.Controls.Add(this.buttonCountClients);
            this.mainPanel.Controls.Add(this.buttonLoadClientRequests);
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
            this.mainPanel.Size = new System.Drawing.Size(1007, 645);
            this.mainPanel.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(642, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(323, 25);
            this.label2.TabIndex = 37;
            this.label2.Text = "Кнопки, для перегляду інформації";
            // 
            // buttonEmployeeComments
            // 
            this.buttonEmployeeComments.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEmployeeComments.Location = new System.Drawing.Point(897, 308);
            this.buttonEmployeeComments.Name = "buttonEmployeeComments";
            this.buttonEmployeeComments.Size = new System.Drawing.Size(89, 43);
            this.buttonEmployeeComments.TabIndex = 36;
            this.buttonEmployeeComments.Text = "Запит 9";
            this.toolTip9.SetToolTip(this.buttonEmployeeComments, "Операція об\'єднання UNION із включенням\r\nкоментарю в кожен рядок:\r\nОтримати списо" +
        "к бригад з коментарем про\r\nкількість виконаних робіт");
            this.buttonEmployeeComments.UseVisualStyleBackColor = true;
            this.buttonEmployeeComments.Click += new System.EventHandler(this.buttonBrigadeComments_Click);
            // 
            // buttonEmployeeWithMostRequests
            // 
            this.buttonEmployeeWithMostRequests.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEmployeeWithMostRequests.Location = new System.Drawing.Point(897, 259);
            this.buttonEmployeeWithMostRequests.Name = "buttonEmployeeWithMostRequests";
            this.buttonEmployeeWithMostRequests.Size = new System.Drawing.Size(89, 43);
            this.buttonEmployeeWithMostRequests.TabIndex = 35;
            this.buttonEmployeeWithMostRequests.Text = "Запит 6";
            this.toolTip6.SetToolTip(this.buttonEmployeeWithMostRequests, "Використання предиката ALL або ANY:\r\nЗнайти посаду і робітника, який має найбільш" +
        "у\r\nкількість заявок на підключення");
            this.buttonEmployeeWithMostRequests.UseVisualStyleBackColor = true;
            this.buttonEmployeeWithMostRequests.Click += new System.EventHandler(this.buttonEmployeeWithMostRequests_Click);
            // 
            // buttonLoadRequestsByDate
            // 
            this.buttonLoadRequestsByDate.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonLoadRequestsByDate.Location = new System.Drawing.Point(897, 210);
            this.buttonLoadRequestsByDate.Name = "buttonLoadRequestsByDate";
            this.buttonLoadRequestsByDate.Size = new System.Drawing.Size(89, 43);
            this.buttonLoadRequestsByDate.TabIndex = 34;
            this.buttonLoadRequestsByDate.Text = "Запит 3";
            this.toolTip3.SetToolTip(this.buttonLoadRequestsByDate, "Використання предикату BETWEEN:\r\nОтримати список заявок на підключення, створених" +
        "\r\nу 2023 році");
            this.buttonLoadRequestsByDate.UseVisualStyleBackColor = true;
            this.buttonLoadRequestsByDate.Click += new System.EventHandler(this.buttonLoadRequestsByDate_Click);
            // 
            // buttonEmployeesNoRequestsLastWeek
            // 
            this.buttonEmployeesNoRequestsLastWeek.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEmployeesNoRequestsLastWeek.Location = new System.Drawing.Point(761, 308);
            this.buttonEmployeesNoRequestsLastWeek.Name = "buttonEmployeesNoRequestsLastWeek";
            this.buttonEmployeesNoRequestsLastWeek.Size = new System.Drawing.Size(89, 43);
            this.buttonEmployeesNoRequestsLastWeek.TabIndex = 33;
            this.buttonEmployeesNoRequestsLastWeek.Text = "Запит 8";
            this.toolTip8.SetToolTip(this.buttonEmployeesNoRequestsLastWeek, "Запит на заперечення:\r\nВзято для програми IN.\r\nЗнайти робітників, які не брали уч" +
        "асть у заявках на\r\nпідключення протягом останнього тижня");
            this.buttonEmployeesNoRequestsLastWeek.UseVisualStyleBackColor = true;
            this.buttonEmployeesNoRequestsLastWeek.Click += new System.EventHandler(this.buttonEmployeesNoRequestsLastWeek_Click);
            // 
            // buttonCountRequestsByBrigadeDate
            // 
            this.buttonCountRequestsByBrigadeDate.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCountRequestsByBrigadeDate.Location = new System.Drawing.Point(761, 259);
            this.buttonCountRequestsByBrigadeDate.Name = "buttonCountRequestsByBrigadeDate";
            this.buttonCountRequestsByBrigadeDate.Size = new System.Drawing.Size(89, 43);
            this.buttonCountRequestsByBrigadeDate.TabIndex = 32;
            this.buttonCountRequestsByBrigadeDate.Text = "Запит 5";
            this.toolTip5.SetToolTip(this.buttonCountRequestsByBrigadeDate, "Агрегатна функція з угрупованням:\r\nПорахувати кількість заявок на підключення\r\nдл" +
        "я кожної дати створення бригади");
            this.buttonCountRequestsByBrigadeDate.UseVisualStyleBackColor = true;
            this.buttonCountRequestsByBrigadeDate.Click += new System.EventHandler(this.buttonCountRequestsByBrigadeDate_Click);
            // 
            // buttonFindClientsBySurname
            // 
            this.buttonFindClientsBySurname.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonFindClientsBySurname.Location = new System.Drawing.Point(761, 210);
            this.buttonFindClientsBySurname.Name = "buttonFindClientsBySurname";
            this.buttonFindClientsBySurname.Size = new System.Drawing.Size(89, 43);
            this.buttonFindClientsBySurname.TabIndex = 31;
            this.buttonFindClientsBySurname.Text = "Запит 2";
            this.toolTip2.SetToolTip(this.buttonFindClientsBySurname, "Використання предикату LIKE:\r\nЗнайти всіх клієнтів, чиє прізвище починається на\r\n" +
        "букву \"Л\"");
            this.buttonFindClientsBySurname.UseVisualStyleBackColor = true;
            this.buttonFindClientsBySurname.Click += new System.EventHandler(this.buttonFindClientsBySurname_Click);
            // 
            // buttonMaxRequestsByJobTitle
            // 
            this.buttonMaxRequestsByJobTitle.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMaxRequestsByJobTitle.Location = new System.Drawing.Point(625, 308);
            this.buttonMaxRequestsByJobTitle.Name = "buttonMaxRequestsByJobTitle";
            this.buttonMaxRequestsByJobTitle.Size = new System.Drawing.Size(89, 43);
            this.buttonMaxRequestsByJobTitle.TabIndex = 30;
            this.buttonMaxRequestsByJobTitle.Text = "Запит 7";
            this.toolTip7.SetToolTip(this.buttonMaxRequestsByJobTitle, "Корельований підзапит:\r\nДля кожної посади визначити робітника, який має\r\nмаксимал" +
        "ьну кількість заявок на підключення\r\n");
            this.buttonMaxRequestsByJobTitle.UseVisualStyleBackColor = true;
            this.buttonMaxRequestsByJobTitle.Click += new System.EventHandler(this.buttonMaxRequestsByJobTitle_Click);
            // 
            // buttonCountClients
            // 
            this.buttonCountClients.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCountClients.Location = new System.Drawing.Point(625, 259);
            this.buttonCountClients.Name = "buttonCountClients";
            this.buttonCountClients.Size = new System.Drawing.Size(89, 43);
            this.buttonCountClients.TabIndex = 29;
            this.buttonCountClients.Text = "Запит 4";
            this.toolTip4.SetToolTip(this.buttonCountClients, "Агрегатна функція без угруповання:\r\nПорахувати загальну кількість клієнтів, які\r\n" +
        "зареєструвались у системі (мають Ід користувача)");
            this.buttonCountClients.UseVisualStyleBackColor = true;
            this.buttonCountClients.Click += new System.EventHandler(this.buttonCountClients_Click);
            // 
            // buttonLoadClientRequests
            // 
            this.buttonLoadClientRequests.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonLoadClientRequests.Location = new System.Drawing.Point(625, 210);
            this.buttonLoadClientRequests.Name = "buttonLoadClientRequests";
            this.buttonLoadClientRequests.Size = new System.Drawing.Size(89, 43);
            this.buttonLoadClientRequests.TabIndex = 28;
            this.buttonLoadClientRequests.Text = "Запит 1";
            this.toolTip1.SetToolTip(this.buttonLoadClientRequests, resources.GetString("buttonLoadClientRequests.ToolTip"));
            this.buttonLoadClientRequests.UseVisualStyleBackColor = true;
            this.buttonLoadClientRequests.Click += new System.EventHandler(this.buttonLoadClientRequests_Click);
            // 
            // buttonPurchaseMaterial
            // 
            this.buttonPurchaseMaterial.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPurchaseMaterial.Location = new System.Drawing.Point(812, 438);
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
            this.label4.Location = new System.Drawing.Point(642, 381);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(305, 44);
            this.label4.TabIndex = 25;
            this.label4.Text = "Кнопки для сформування рахунків \r\nта закупівлі матеріалів";
            // 
            // buttonBill
            // 
            this.buttonBill.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBill.Location = new System.Drawing.Point(604, 438);
            this.buttonBill.Name = "buttonBill";
            this.buttonBill.Size = new System.Drawing.Size(175, 56);
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
            this.label3.Location = new System.Drawing.Point(654, 529);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(288, 25);
            this.label3.TabIndex = 23;
            this.label3.Text = "Кнопки, для перегляду заявок";
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
            this.buttonAccidentReportView.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAccidentReportView.Location = new System.Drawing.Point(812, 568);
            this.buttonAccidentReportView.Name = "buttonAccidentReportView";
            this.buttonAccidentReportView.Size = new System.Drawing.Size(166, 56);
            this.buttonAccidentReportView.TabIndex = 19;
            this.buttonAccidentReportView.Text = "Переглянути заявки на аварії";
            this.buttonAccidentReportView.UseVisualStyleBackColor = true;
            this.buttonAccidentReportView.Click += new System.EventHandler(this.buttonAccidentReportView_Click);
            // 
            // buttonConnectionRequestView
            // 
            this.buttonConnectionRequestView.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonConnectionRequestView.Location = new System.Drawing.Point(604, 568);
            this.buttonConnectionRequestView.Name = "buttonConnectionRequestView";
            this.buttonConnectionRequestView.Size = new System.Drawing.Size(175, 56);
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
            this.panel2.Size = new System.Drawing.Size(1003, 128);
            this.panel2.TabIndex = 0;
            // 
            // closeButton
            // 
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.Font = new System.Drawing.Font("Arial Narrow", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeButton.Location = new System.Drawing.Point(972, 0);
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
            this.labelPanel.Size = new System.Drawing.Size(1003, 128);
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
            this.ClientSize = new System.Drawing.Size(1007, 645);
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
        private System.Windows.Forms.Button buttonPurchaseMaterial;
        private System.Windows.Forms.Button buttonEmployeeComments;
        private System.Windows.Forms.Button buttonEmployeeWithMostRequests;
        private System.Windows.Forms.Button buttonLoadRequestsByDate;
        private System.Windows.Forms.Button buttonEmployeesNoRequestsLastWeek;
        private System.Windows.Forms.Button buttonCountRequestsByBrigadeDate;
        private System.Windows.Forms.Button buttonFindClientsBySurname;
        private System.Windows.Forms.Button buttonMaxRequestsByJobTitle;
        private System.Windows.Forms.Button buttonCountClients;
        private System.Windows.Forms.Button buttonLoadClientRequests;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.ToolTip toolTip3;
        private System.Windows.Forms.ToolTip toolTip4;
        private System.Windows.Forms.ToolTip toolTip5;
        private System.Windows.Forms.ToolTip toolTip6;
        private System.Windows.Forms.ToolTip toolTip8;
        private System.Windows.Forms.ToolTip toolTip7;
        private System.Windows.Forms.ToolTip toolTip9;
    }
}