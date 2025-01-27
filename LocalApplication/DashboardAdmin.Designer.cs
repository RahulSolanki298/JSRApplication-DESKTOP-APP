namespace LocalApplication
{
    partial class DashboardAdmin
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
        private async void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardAdmin));
            tableLayoutPanel1 = new TableLayoutPanel();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            picSetting = new PictureBox();
            panel1 = new Panel();
            pnlAdminDashboard = new Panel();
            panel2 = new Panel();
            lblClose = new Label();
            empId = new Label();
            label1 = new Label();
            cmbSelectEmployee = new ComboBox();
            dtGridEmployee = new DataGridView();
            menuStrip1 = new MenuStrip();
            employeeToolStripMenuItem = new ToolStripMenuItem();
            replicateToolStripMenuItem = new ToolStripMenuItem();
            changePasswordToolStripMenuItem = new ToolStripMenuItem();
            logOutToolStripMenuItem = new ToolStripMenuItem();
            panel8 = new Panel();
            lblMinimize = new Label();
            label3 = new Label();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picSetting).BeginInit();
            panel1.SuspendLayout();
            pnlAdminDashboard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtGridEmployee).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.BackColor = Color.WhiteSmoke;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 143F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 126F));
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 1, 0);
            tableLayoutPanel1.Controls.Add(picSetting, 2, 0);
            tableLayoutPanel1.Location = new Point(5, 39);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(525, 43);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(149, 37);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            label2.ForeColor = SystemColors.InfoText;
            label2.Location = new Point(293, 20);
            label2.Margin = new Padding(3, 20, 3, 0);
            label2.Name = "label2";
            label2.Size = new Size(103, 13);
            label2.TabIndex = 2;
            label2.Text = "Software Version";
            // 
            // picSetting
            // 
            picSetting.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            picSetting.Cursor = Cursors.Hand;
            picSetting.Image = Properties.Resources._2590084;
            picSetting.Location = new Point(495, 3);
            picSetting.Name = "picSetting";
            picSetting.Size = new Size(27, 30);
            picSetting.SizeMode = PictureBoxSizeMode.StretchImage;
            picSetting.TabIndex = 16;
            picSetting.TabStop = false;
            picSetting.Click += picSetting_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(pnlAdminDashboard);
            panel1.Controls.Add(dtGridEmployee);
            panel1.Location = new Point(5, 88);
            panel1.Name = "panel1";
            panel1.Size = new Size(525, 481);
            panel1.TabIndex = 1;
            // 
            // pnlAdminDashboard
            // 
            pnlAdminDashboard.BorderStyle = BorderStyle.FixedSingle;
            pnlAdminDashboard.Controls.Add(panel2);
            pnlAdminDashboard.Controls.Add(lblClose);
            pnlAdminDashboard.Controls.Add(empId);
            pnlAdminDashboard.Controls.Add(label1);
            pnlAdminDashboard.Controls.Add(cmbSelectEmployee);
            pnlAdminDashboard.Location = new Point(133, 64);
            pnlAdminDashboard.Name = "pnlAdminDashboard";
            pnlAdminDashboard.Size = new Size(223, 124);
            pnlAdminDashboard.TabIndex = 1;
            pnlAdminDashboard.Visible = false;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.None;
            panel2.BackColor = Color.Navy;
            panel2.Location = new Point(-1, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(223, 10);
            panel2.TabIndex = 6;
            // 
            // lblClose
            // 
            lblClose.AutoSize = true;
            lblClose.Cursor = Cursors.Hand;
            lblClose.Font = new Font("Segoe UI Historic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblClose.ForeColor = Color.Red;
            lblClose.Location = new Point(200, 18);
            lblClose.Name = "lblClose";
            lblClose.Size = new Size(15, 15);
            lblClose.TabIndex = 3;
            lblClose.Text = "X";
            lblClose.Click += lblClose_Click;
            // 
            // empId
            // 
            empId.AutoSize = true;
            empId.Location = new Point(160, 18);
            empId.Name = "empId";
            empId.Size = new Size(13, 15);
            empId.TabIndex = 2;
            empId.Text = "0";
            empId.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 40);
            label1.Name = "label1";
            label1.Size = new Size(141, 15);
            label1.TabIndex = 1;
            label1.Text = "Please select your option.";
            // 
            // cmbSelectEmployee
            // 
            cmbSelectEmployee.FormattingEnabled = true;
            cmbSelectEmployee.Items.AddRange(new object[] { "Edit", "Delete", "Dashboard" });
            cmbSelectEmployee.Location = new Point(22, 58);
            cmbSelectEmployee.Name = "cmbSelectEmployee";
            cmbSelectEmployee.Size = new Size(193, 23);
            cmbSelectEmployee.TabIndex = 0;
            cmbSelectEmployee.SelectedValueChanged += cmbSelectEmployee_SelectedValueChanged;
            // 
            // dtGridEmployee
            // 
            dtGridEmployee.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dtGridEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtGridEmployee.Location = new Point(3, 3);
            dtGridEmployee.Name = "dtGridEmployee";
            dtGridEmployee.Size = new Size(519, 464);
            dtGridEmployee.TabIndex = 0;
            dtGridEmployee.CellMouseDoubleClick += dtGridEmployee_CellMouseDoubleClick;
            // 
            // menuStrip1
            // 
            menuStrip1.Dock = DockStyle.None;
            menuStrip1.Items.AddRange(new ToolStripItem[] { employeeToolStripMenuItem, replicateToolStripMenuItem, changePasswordToolStripMenuItem, logOutToolStripMenuItem });
            menuStrip1.Location = new Point(8, 12);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(318, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // employeeToolStripMenuItem
            // 
            employeeToolStripMenuItem.Name = "employeeToolStripMenuItem";
            employeeToolStripMenuItem.Size = new Size(71, 20);
            employeeToolStripMenuItem.Text = "Employee";
            employeeToolStripMenuItem.Click += employeeToolStripMenuItem_Click;
            // 
            // replicateToolStripMenuItem
            // 
            replicateToolStripMenuItem.Name = "replicateToolStripMenuItem";
            replicateToolStripMenuItem.Size = new Size(67, 20);
            replicateToolStripMenuItem.Text = "Replicate";
            replicateToolStripMenuItem.Click += replicateToolStripMenuItem_Click;
            // 
            // changePasswordToolStripMenuItem
            // 
            changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            changePasswordToolStripMenuItem.Size = new Size(110, 20);
            changePasswordToolStripMenuItem.Text = "ChangePassword";
            changePasswordToolStripMenuItem.Click += changePasswordToolStripMenuItem_Click;
            // 
            // logOutToolStripMenuItem
            // 
            logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            logOutToolStripMenuItem.Size = new Size(62, 20);
            logOutToolStripMenuItem.Text = "Log Out";
            logOutToolStripMenuItem.Click += logOutToolStripMenuItem_Click;
            // 
            // panel8
            // 
            panel8.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel8.BackColor = Color.Navy;
            panel8.Location = new Point(-3, -1);
            panel8.Name = "panel8";
            panel8.Size = new Size(539, 10);
            panel8.TabIndex = 5;
            // 
            // lblMinimize
            // 
            lblMinimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblMinimize.Cursor = Cursors.Hand;
            lblMinimize.Font = new Font("Algerian", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMinimize.ForeColor = Color.LightSlateGray;
            lblMinimize.Location = new Point(468, 15);
            lblMinimize.Name = "lblMinimize";
            lblMinimize.Size = new Size(21, 23);
            lblMinimize.TabIndex = 21;
            lblMinimize.Text = "-";
            lblMinimize.Click += lblMinimize_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.Cursor = Cursors.Hand;
            label3.Font = new Font("Calibri", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Red;
            label3.Location = new Point(503, 12);
            label3.Name = "label3";
            label3.Size = new Size(24, 26);
            label3.TabIndex = 20;
            label3.Text = "X";
            label3.Click += label3_Click;
            // 
            // DashboardAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(535, 560);
            Controls.Add(lblMinimize);
            Controls.Add(menuStrip1);
            Controls.Add(label3);
            Controls.Add(panel8);
            Controls.Add(panel1);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            MinimumSize = new Size(535, 560);
            Name = "DashboardAdmin";
            Padding = new Padding(2);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard";
            WindowState = FormWindowState.Maximized;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)picSetting).EndInit();
            panel1.ResumeLayout(false);
            pnlAdminDashboard.ResumeLayout(false);
            pnlAdminDashboard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtGridEmployee).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBox1;
        private Label label2;
        private Panel panel1;
        private ToolStripMenuItem iToolStripMenuItem;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem logOutToolStripMenuItem;
        private ToolStripMenuItem employeeToolStripMenuItem;
        private DataGridView dtGridEmployee;
        private PictureBox picSetting;
        private ToolStripMenuItem changePasswordToolStripMenuItem;
        private ToolStripMenuItem replicateToolStripMenuItem;
        private Panel pnlAdminDashboard;
        private ComboBox cmbSelectEmployee;
        private Label label1;
        private Label lblClose;
        private Label empId;
        private Panel panel2;
        private Panel panel8;
        private Label lblMinimize;
        private Label label3;
    }
}