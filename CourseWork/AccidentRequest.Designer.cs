namespace CourseWork
{
    partial class AccidentRequest
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
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.pictureBoxHelp = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxAccident = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Label();
            this.labelPanel = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHelp)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(156)))), ((int)(((byte)(246)))));
            this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mainPanel.Controls.Add(this.buttonConfirm);
            this.mainPanel.Controls.Add(this.pictureBoxHelp);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.comboBoxAccident);
            this.mainPanel.Controls.Add(this.panel2);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(424, 328);
            this.mainPanel.TabIndex = 3;
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(156)))), ((int)(((byte)(246)))));
            this.buttonConfirm.Location = new System.Drawing.Point(129, 270);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(178, 46);
            this.buttonConfirm.TabIndex = 17;
            this.buttonConfirm.Text = "Підтвердження заявки";
            this.buttonConfirm.UseVisualStyleBackColor = false;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // pictureBoxHelp
            // 
            this.pictureBoxHelp.Image = global::CourseWork.Properties.Resources.help;
            this.pictureBoxHelp.Location = new System.Drawing.Point(385, 144);
            this.pictureBoxHelp.Name = "pictureBoxHelp";
            this.pictureBoxHelp.Size = new System.Drawing.Size(27, 28);
            this.pictureBoxHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxHelp.TabIndex = 16;
            this.pictureBoxHelp.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(153, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Деталі аварії:";
            // 
            // comboBoxAccident
            // 
            this.comboBoxAccident.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAccident.FormattingEnabled = true;
            this.comboBoxAccident.Location = new System.Drawing.Point(87, 194);
            this.comboBoxAccident.MaxLength = 10;
            this.comboBoxAccident.Name = "comboBoxAccident";
            this.comboBoxAccident.Size = new System.Drawing.Size(267, 24);
            this.comboBoxAccident.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(228)))), ((int)(((byte)(143)))));
            this.panel2.Controls.Add(this.closeButton);
            this.panel2.Controls.Add(this.labelPanel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(420, 128);
            this.panel2.TabIndex = 0;
            // 
            // closeButton
            // 
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.Font = new System.Drawing.Font("Arial Narrow", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeButton.Location = new System.Drawing.Point(397, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(28, 29);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "x";
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            this.closeButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelPanel_MouseDown);
            this.closeButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelPanel_MouseMove);
            // 
            // labelPanel
            // 
            this.labelPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPanel.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPanel.Location = new System.Drawing.Point(0, 0);
            this.labelPanel.Name = "labelPanel";
            this.labelPanel.Size = new System.Drawing.Size(420, 128);
            this.labelPanel.TabIndex = 0;
            this.labelPanel.Text = "Заява на усунення аварії";
            this.labelPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelPanel_MouseDown);
            this.labelPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelPanel_MouseMove);
            // 
            // AccidentRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 328);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AccidentRequest";
            this.Text = "AccidentRequest";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHelp)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label closeButton;
        private System.Windows.Forms.Label labelPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxAccident;
        private System.Windows.Forms.PictureBox pictureBoxHelp;
        private System.Windows.Forms.Button buttonConfirm;
    }
}