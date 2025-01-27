namespace LocalApplication
{
    partial class SettingForm
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
            panel1 = new Panel();
            panel3 = new Panel();
            btnSave = new Button();
            label3 = new Label();
            label2 = new Label();
            lblID = new Label();
            txtOutputFolder = new TextBox();
            btnInputUpload = new Button();
            btnUpload = new Button();
            txtInputPath = new TextBox();
            panel2 = new Panel();
            lblClose = new Label();
            label1 = new Label();
            openFileDialog1 = new OpenFileDialog();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AccessibleRole = AccessibleRole.Window;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(lblClose);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.MaximumSize = new Size(518, 458);
            panel1.MinimumSize = new Size(518, 458);
            panel1.Name = "panel1";
            panel1.Size = new Size(518, 458);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(btnSave);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(lblID);
            panel3.Controls.Add(txtOutputFolder);
            panel3.Controls.Add(btnInputUpload);
            panel3.Controls.Add(btnUpload);
            panel3.Controls.Add(txtInputPath);
            panel3.Location = new Point(29, 56);
            panel3.Name = "panel3";
            panel3.Size = new Size(455, 354);
            panel3.TabIndex = 21;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.None;
            btnSave.BackColor = Color.Navy;
            btnSave.Cursor = Cursors.Hand;
            btnSave.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = SystemColors.ControlLightLight;
            btnSave.Location = new Point(283, 301);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(146, 32);
            btnSave.TabIndex = 13;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 9F);
            label3.ForeColor = SystemColors.ControlText;
            label3.Location = new Point(9, 104);
            label3.Name = "label3";
            label3.Size = new Size(62, 15);
            label3.TabIndex = 2;
            label3.Text = "Input Path";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 9F);
            label2.ForeColor = SystemColors.ControlText;
            label2.Location = new Point(9, 144);
            label2.Name = "label2";
            label2.Size = new Size(71, 15);
            label2.TabIndex = 1;
            label2.Text = "Output Path";
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.Location = new Point(439, 10);
            lblID.Name = "lblID";
            lblID.Size = new Size(13, 15);
            lblID.TabIndex = 14;
            lblID.Text = "0";
            lblID.Visible = false;
            // 
            // txtOutputFolder
            // 
            txtOutputFolder.Location = new Point(97, 142);
            txtOutputFolder.Name = "txtOutputFolder";
            txtOutputFolder.Size = new Size(210, 23);
            txtOutputFolder.TabIndex = 9;
            // 
            // btnInputUpload
            // 
            btnInputUpload.Cursor = Cursors.Hand;
            btnInputUpload.Location = new Point(308, 100);
            btnInputUpload.Name = "btnInputUpload";
            btnInputUpload.Size = new Size(85, 24);
            btnInputUpload.TabIndex = 12;
            btnInputUpload.Text = "Upload";
            btnInputUpload.UseVisualStyleBackColor = true;
            btnInputUpload.Click += btnInputUpload_Click;
            // 
            // btnUpload
            // 
            btnUpload.Cursor = Cursors.Hand;
            btnUpload.Location = new Point(307, 142);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(85, 23);
            btnUpload.TabIndex = 10;
            btnUpload.Text = "Upload";
            btnUpload.UseVisualStyleBackColor = true;
            btnUpload.Click += btnUpload_Click;
            // 
            // txtInputPath
            // 
            txtInputPath.Location = new Point(97, 100);
            txtInputPath.Name = "txtInputPath";
            txtInputPath.Size = new Size(210, 23);
            txtInputPath.TabIndex = 11;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.Navy;
            panel2.Location = new Point(-1, -1);
            panel2.Name = "panel2";
            panel2.Size = new Size(526, 10);
            panel2.TabIndex = 20;
            // 
            // lblClose
            // 
            lblClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblClose.Cursor = Cursors.Hand;
            lblClose.Font = new Font("Calibri", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblClose.ForeColor = Color.Red;
            lblClose.Location = new Point(482, 13);
            lblClose.Name = "lblClose";
            lblClose.Size = new Size(24, 26);
            lblClose.TabIndex = 15;
            lblClose.Text = "X";
            lblClose.Click += lblClose_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(9, 30);
            label1.Name = "label1";
            label1.Size = new Size(74, 24);
            label1.TabIndex = 0;
            label1.Text = "Setting";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // SettingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(518, 458);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            MinimumSize = new Size(518, 458);
            Name = "SettingForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SettingForm";
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnSave;
        private Button btnInputUpload;
        private TextBox txtInputPath;
        private Button btnUpload;
        private TextBox txtOutputFolder;
        private OpenFileDialog openFileDialog1;
        private Label lblID;
        private Label lblClose;
        private Panel panel3;
        private Panel panel2;
    }
}