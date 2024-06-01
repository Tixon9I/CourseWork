namespace CourseWork
{
    partial class Register
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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonEmployee = new System.Windows.Forms.Button();
            this.buttonUser = new System.Windows.Forms.Button();
            this.pictureBoxLock = new System.Windows.Forms.PictureBox();
            this.pictureBoxUser = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Label();
            this.labelPanel = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUser)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(156)))), ((int)(((byte)(246)))));
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.buttonEmployee);
            this.mainPanel.Controls.Add(this.buttonUser);
            this.mainPanel.Controls.Add(this.pictureBoxLock);
            this.mainPanel.Controls.Add(this.pictureBoxUser);
            this.mainPanel.Controls.Add(this.panel2);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(429, 450);
            this.mainPanel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(22, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(344, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "Щоб увійти в систему, представте себе як:";
            // 
            // buttonEmployee
            // 
            this.buttonEmployee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEmployee.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(119)))), ((int)(((byte)(192)))));
            this.buttonEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEmployee.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEmployee.Location = new System.Drawing.Point(145, 296);
            this.buttonEmployee.Name = "buttonEmployee";
            this.buttonEmployee.Size = new System.Drawing.Size(154, 48);
            this.buttonEmployee.TabIndex = 6;
            this.buttonEmployee.Text = "Працівник";
            this.buttonEmployee.UseVisualStyleBackColor = true;
            this.buttonEmployee.Click += new System.EventHandler(this.buttonEmployee_Click);
            // 
            // buttonUser
            // 
            this.buttonUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonUser.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(119)))), ((int)(((byte)(192)))));
            this.buttonUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUser.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonUser.Location = new System.Drawing.Point(145, 229);
            this.buttonUser.Name = "buttonUser";
            this.buttonUser.Size = new System.Drawing.Size(154, 48);
            this.buttonUser.TabIndex = 5;
            this.buttonUser.Text = "Користувач";
            this.buttonUser.UseVisualStyleBackColor = true;
            this.buttonUser.Click += new System.EventHandler(this.buttonUser_Click);
            // 
            // pictureBoxLock
            // 
            this.pictureBoxLock.Image = global::CourseWork.Properties.Resources.Employee;
            this.pictureBoxLock.Location = new System.Drawing.Point(84, 292);
            this.pictureBoxLock.Name = "pictureBoxLock";
            this.pictureBoxLock.Size = new System.Drawing.Size(55, 52);
            this.pictureBoxLock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLock.TabIndex = 2;
            this.pictureBoxLock.TabStop = false;
            // 
            // pictureBoxUser
            // 
            this.pictureBoxUser.Image = global::CourseWork.Properties.Resources.user;
            this.pictureBoxUser.Location = new System.Drawing.Point(84, 227);
            this.pictureBoxUser.Name = "pictureBoxUser";
            this.pictureBoxUser.Size = new System.Drawing.Size(55, 52);
            this.pictureBoxUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxUser.TabIndex = 1;
            this.pictureBoxUser.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(228)))), ((int)(((byte)(143)))));
            this.panel2.Controls.Add(this.closeButton);
            this.panel2.Controls.Add(this.labelPanel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(429, 128);
            this.panel2.TabIndex = 0;
            // 
            // closeButton
            // 
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.Font = new System.Drawing.Font("Arial Narrow", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeButton.Location = new System.Drawing.Point(403, 0);
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
            this.labelPanel.Font = new System.Drawing.Font("Arial", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPanel.Location = new System.Drawing.Point(0, 0);
            this.labelPanel.Name = "labelPanel";
            this.labelPanel.Size = new System.Drawing.Size(429, 128);
            this.labelPanel.TabIndex = 0;
            this.labelPanel.Text = "Вітаємо в системі водопостачання!";
            this.labelPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelPanel_MouseDown);
            this.labelPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelPanel_MouseMove);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 450);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUser)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button buttonUser;
        private System.Windows.Forms.PictureBox pictureBoxLock;
        private System.Windows.Forms.PictureBox pictureBoxUser;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label closeButton;
        private System.Windows.Forms.Label labelPanel;
        private System.Windows.Forms.Button buttonEmployee;
        private System.Windows.Forms.Label label1;
    }
}