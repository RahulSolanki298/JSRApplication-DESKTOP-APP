namespace LocalApplication
{
    partial class ModuleConfiguration
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel2 = new Panel();
            lblID = new Label();
            btnSave = new Button();
            label1 = new Label();
            panel3 = new Panel();
            tableLayoutPanel6 = new TableLayoutPanel();
            btnUpload = new Button();
            btnInputUpload = new Button();
            txtInputPath = new TextBox();
            label2 = new Label();
            cmbModuleSetting = new ComboBox();
            txtOutputFolder = new TextBox();
            label3 = new Label();
            label4 = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            txtStrEnd = new TextBox();
            txtStrStart = new TextBox();
            txtEnd = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label7 = new Label();
            label8 = new Label();
            txtStart = new TextBox();
            label10 = new Label();
            txtModuleStart = new TextBox();
            label11 = new Label();
            txtModuleEnd = new TextBox();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Location = new Point(-1, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(536, 562);
            panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.AutoScroll = true;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel2, 0, 0);
            tableLayoutPanel1.Controls.Add(panel3, 0, 1);
            tableLayoutPanel1.Location = new Point(1, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8.267269F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 91.7327347F));
            tableLayoutPanel1.Size = new Size(535, 559);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Lime;
            panel2.Controls.Add(lblID);
            panel2.Controls.Add(btnSave);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(529, 40);
            panel2.TabIndex = 0;
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.Location = new Point(282, 12);
            lblID.Name = "lblID";
            lblID.Size = new Size(13, 15);
            lblID.TabIndex = 17;
            lblID.Text = "0";
            lblID.Visible = false;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSave.BackColor = Color.Navy;
            btnSave.Font = new Font("Rockwell", 10F, FontStyle.Bold);
            btnSave.ForeColor = SystemColors.Control;
            btnSave.Location = new Point(400, -3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(129, 43);
            btnSave.TabIndex = 16;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Rockwell Extra Bold", 14F);
            label1.ForeColor = SystemColors.HighlightText;
            label1.Location = new Point(3, 9);
            label1.Name = "label1";
            label1.Size = new Size(262, 22);
            label1.TabIndex = 0;
            label1.Text = "Module Configuration";
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel3.Controls.Add(tableLayoutPanel6);
            panel3.Controls.Add(tableLayoutPanel2);
            panel3.Location = new Point(3, 49);
            panel3.Name = "panel3";
            panel3.Size = new Size(529, 507);
            panel3.TabIndex = 1;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel6.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel6.ColumnCount = 3;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.8962269F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 69.103775F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 98F));
            tableLayoutPanel6.Controls.Add(btnUpload, 2, 1);
            tableLayoutPanel6.Controls.Add(btnInputUpload, 2, 0);
            tableLayoutPanel6.Controls.Add(txtInputPath, 1, 0);
            tableLayoutPanel6.Controls.Add(label2, 0, 0);
            tableLayoutPanel6.Controls.Add(cmbModuleSetting, 1, 2);
            tableLayoutPanel6.Controls.Add(txtOutputFolder, 1, 1);
            tableLayoutPanel6.Controls.Add(label3, 0, 1);
            tableLayoutPanel6.Controls.Add(label4, 0, 2);
            tableLayoutPanel6.Location = new Point(3, 6);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 3;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 48.101265F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 51.898735F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
            tableLayoutPanel6.Size = new Size(523, 103);
            tableLayoutPanel6.TabIndex = 38;
            // 
            // btnUpload
            // 
            btnUpload.Anchor = AnchorStyles.Right;
            btnUpload.Cursor = Cursors.Hand;
            btnUpload.Location = new Point(426, 36);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(93, 28);
            btnUpload.TabIndex = 16;
            btnUpload.Text = "Upload";
            btnUpload.UseVisualStyleBackColor = true;
            btnUpload.Click += btnUpload_Click;
            // 
            // btnInputUpload
            // 
            btnInputUpload.Anchor = AnchorStyles.Right;
            btnInputUpload.Cursor = Cursors.Hand;
            btnInputUpload.Location = new Point(426, 4);
            btnInputUpload.Name = "btnInputUpload";
            btnInputUpload.Size = new Size(93, 25);
            btnInputUpload.TabIndex = 18;
            btnInputUpload.Text = "Upload";
            btnInputUpload.UseVisualStyleBackColor = true;
            btnInputUpload.Click += btnInputUpload_Click;
            // 
            // txtInputPath
            // 
            txtInputPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtInputPath.Location = new Point(135, 4);
            txtInputPath.Multiline = true;
            txtInputPath.Name = "txtInputPath";
            txtInputPath.Size = new Size(284, 25);
            txtInputPath.TabIndex = 17;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(4, 9);
            label2.Name = "label2";
            label2.Size = new Size(75, 15);
            label2.TabIndex = 0;
            label2.Text = "Input Folder";
            // 
            // cmbModuleSetting
            // 
            cmbModuleSetting.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbModuleSetting.FormattingEnabled = true;
            cmbModuleSetting.Items.AddRange(new object[] { "Inv", "CB" });
            cmbModuleSetting.Location = new Point(135, 71);
            cmbModuleSetting.Name = "cmbModuleSetting";
            cmbModuleSetting.Size = new Size(284, 23);
            cmbModuleSetting.TabIndex = 19;
            // 
            // txtOutputFolder
            // 
            txtOutputFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtOutputFolder.Location = new Point(135, 36);
            txtOutputFolder.Multiline = true;
            txtOutputFolder.Name = "txtOutputFolder";
            txtOutputFolder.Size = new Size(284, 28);
            txtOutputFolder.TabIndex = 15;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(4, 42);
            label3.Name = "label3";
            label3.Size = new Size(85, 15);
            label3.TabIndex = 1;
            label3.Text = "Output Folder";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(4, 70);
            label4.Name = "label4";
            label4.Size = new Size(90, 30);
            label4.TabIndex = 2;
            label4.Text = "Select Module Setting";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel2.Controls.Add(txtStrEnd, 3, 1);
            tableLayoutPanel2.Controls.Add(txtStrStart, 1, 1);
            tableLayoutPanel2.Controls.Add(txtEnd, 3, 0);
            tableLayoutPanel2.Controls.Add(label6, 2, 0);
            tableLayoutPanel2.Controls.Add(label5, 0, 0);
            tableLayoutPanel2.Controls.Add(label7, 0, 1);
            tableLayoutPanel2.Controls.Add(label8, 2, 1);
            tableLayoutPanel2.Controls.Add(txtStart, 1, 0);
            tableLayoutPanel2.Controls.Add(label10, 0, 2);
            tableLayoutPanel2.Controls.Add(txtModuleStart, 1, 2);
            tableLayoutPanel2.Controls.Add(label11, 2, 2);
            tableLayoutPanel2.Controls.Add(txtModuleEnd, 3, 2);
            tableLayoutPanel2.Location = new Point(0, 117);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutPanel2.Size = new Size(526, 92);
            tableLayoutPanel2.TabIndex = 34;
            // 
            // txtStrEnd
            // 
            txtStrEnd.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtStrEnd.Location = new Point(371, 31);
            txtStrEnd.Name = "txtStrEnd";
            txtStrEnd.Size = new Size(151, 23);
            txtStrEnd.TabIndex = 37;
            // 
            // txtStrStart
            // 
            txtStrStart.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtStrStart.Location = new Point(109, 31);
            txtStrStart.Name = "txtStrStart";
            txtStrStart.Size = new Size(150, 23);
            txtStrStart.TabIndex = 36;
            // 
            // txtEnd
            // 
            txtEnd.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtEnd.Location = new Point(371, 4);
            txtEnd.Name = "txtEnd";
            txtEnd.Size = new Size(151, 23);
            txtEnd.TabIndex = 35;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Left;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.Location = new Point(266, 6);
            label6.Name = "label6";
            label6.Size = new Size(84, 15);
            label6.TabIndex = 4;
            label6.Text = "Inv End Count";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(4, 6);
            label5.Name = "label5";
            label5.Size = new Size(92, 15);
            label5.TabIndex = 3;
            label5.Text = "Inv Start Count";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Left;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.Location = new Point(4, 28);
            label7.Name = "label7";
            label7.Size = new Size(75, 28);
            label7.TabIndex = 5;
            label7.Text = "String Start Count";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Left;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label8.Location = new Point(266, 34);
            label8.Name = "label8";
            label8.Size = new Size(83, 15);
            label8.TabIndex = 6;
            label8.Text = "String End No";
            // 
            // txtStart
            // 
            txtStart.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtStart.Location = new Point(109, 4);
            txtStart.Name = "txtStart";
            txtStart.Size = new Size(150, 23);
            txtStart.TabIndex = 34;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Left;
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label10.Location = new Point(4, 59);
            label10.Name = "label10";
            label10.Size = new Size(83, 30);
            label10.TabIndex = 8;
            label10.Text = "Module Start Count";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtModuleStart
            // 
            txtModuleStart.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtModuleStart.Location = new Point(109, 62);
            txtModuleStart.Name = "txtModuleStart";
            txtModuleStart.Size = new Size(150, 23);
            txtModuleStart.TabIndex = 38;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Left;
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label11.Location = new Point(266, 59);
            label11.Name = "label11";
            label11.Size = new Size(75, 30);
            label11.TabIndex = 9;
            label11.Text = "Module End Count";
            // 
            // txtModuleEnd
            // 
            txtModuleEnd.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtModuleEnd.Location = new Point(371, 62);
            txtModuleEnd.Name = "txtModuleEnd";
            txtModuleEnd.Size = new Size(151, 23);
            txtModuleEnd.TabIndex = 39;
            // 
            // ModuleConfiguration
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSize = true;
            BackColor = SystemColors.ControlLight;
            Controls.Add(panel1);
            ForeColor = SystemColors.ActiveCaptionText;
            MinimumSize = new Size(535, 560);
            Name = "ModuleConfiguration";
            Size = new Size(535, 560);
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel6.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel2;
        private Label label1;
        private Button btnSave;
        private Panel panel3;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label11;
        private Label label10;
        private Label label8;
        private Button btnInputUpload;
        private TextBox txtInputPath;
        private Button btnUpload;
        private TextBox txtOutputFolder;
        private ComboBox cmbModuleSetting;
        private Label lblID;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel6;
        private TextBox txtStrEnd;
        private TextBox txtStrStart;
        private TextBox txtEnd;
        private TextBox txtStart;
        private TextBox txtModuleStart;
        private TextBox txtModuleEnd;
    }
}
