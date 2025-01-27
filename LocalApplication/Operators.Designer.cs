namespace LocalApplication
{
    partial class Operators
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
            panel1 = new Panel();
            pnlAdminDashboard = new Panel();
            panel2 = new Panel();
            lblClose = new Label();
            empId = new Label();
            label1 = new Label();
            cmbSelectEmployee = new ComboBox();
            dtGridEmployee = new DataGridView();
            panel8 = new Panel();
            label19 = new Label();
            lblBulkClose = new Label();
            btnEmployee = new Button();
            panel1.SuspendLayout();
            pnlAdminDashboard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtGridEmployee).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(pnlAdminDashboard);
            panel1.Controls.Add(dtGridEmployee);
            panel1.Location = new Point(4, 75);
            panel1.Name = "panel1";
            panel1.Size = new Size(525, 467);
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
            pnlAdminDashboard.Size = new Size(223, 113);
            pnlAdminDashboard.TabIndex = 1;
            pnlAdminDashboard.Visible = false;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.None;
            panel2.BackColor = Color.Navy;
            panel2.Location = new Point(-1, -1);
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
            label1.Location = new Point(16, 39);
            label1.Name = "label1";
            label1.Size = new Size(141, 15);
            label1.TabIndex = 1;
            label1.Text = "Please select your option.";
            // 
            // cmbSelectEmployee
            // 
            cmbSelectEmployee.FormattingEnabled = true;
            cmbSelectEmployee.Items.AddRange(new object[] { "Edit", "Delete", "Dashboard" });
            cmbSelectEmployee.Location = new Point(16, 58);
            cmbSelectEmployee.Name = "cmbSelectEmployee";
            cmbSelectEmployee.Size = new Size(193, 23);
            cmbSelectEmployee.TabIndex = 0;
            cmbSelectEmployee.SelectedValueChanged += cmbSelectEmployee_SelectedValueChanged;
            // 
            // dtGridEmployee
            // 
            dtGridEmployee.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dtGridEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtGridEmployee.Location = new Point(2, 3);
            dtGridEmployee.Name = "dtGridEmployee";
            dtGridEmployee.Size = new Size(519, 464);
            dtGridEmployee.TabIndex = 0;
            dtGridEmployee.CellMouseDoubleClick += dtGridEmployee_CellMouseDoubleClick;
            // 
            // panel8
            // 
            panel8.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel8.BackColor = Color.Navy;
            panel8.Location = new Point(-4, -2);
            panel8.Name = "panel8";
            panel8.Size = new Size(543, 13);
            panel8.TabIndex = 5;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Rockwell", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label19.ForeColor = SystemColors.GrayText;
            label19.Location = new Point(7, 16);
            label19.Name = "label19";
            label19.Size = new Size(193, 33);
            label19.TabIndex = 6;
            label19.Text = "Operator List";
            // 
            // lblBulkClose
            // 
            lblBulkClose.AutoSize = true;
            lblBulkClose.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblBulkClose.ForeColor = Color.Red;
            lblBulkClose.Location = new Point(502, 12);
            lblBulkClose.Name = "lblBulkClose";
            lblBulkClose.Size = new Size(24, 25);
            lblBulkClose.TabIndex = 11;
            lblBulkClose.Text = "X";
            lblBulkClose.Click += lblBulkClose_Click;
            // 
            // btnEmployee
            // 
            btnEmployee.BackColor = Color.DarkBlue;
            btnEmployee.ForeColor = SystemColors.ControlLightLight;
            btnEmployee.Location = new Point(385, 43);
            btnEmployee.Name = "btnEmployee";
            btnEmployee.Size = new Size(142, 29);
            btnEmployee.TabIndex = 12;
            btnEmployee.Text = "Add Employee";
            btnEmployee.UseVisualStyleBackColor = false;
            btnEmployee.Click += btnEmployee_Click;
            // 
            // Operators
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(535, 560);
            Controls.Add(btnEmployee);
            Controls.Add(lblBulkClose);
            Controls.Add(label19);
            Controls.Add(panel8);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            MinimumSize = new Size(535, 560);
            Name = "Operators";
            Padding = new Padding(2);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard";
            panel1.ResumeLayout(false);
            pnlAdminDashboard.ResumeLayout(false);
            pnlAdminDashboard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtGridEmployee).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel1;
        private ToolStripMenuItem iToolStripMenuItem;
        private DataGridView dtGridEmployee;
        private Panel pnlAdminDashboard;
        private ComboBox cmbSelectEmployee;
        private Label label1;
        private Label lblClose;
        private Label empId;
        private Panel panel2;
        private Panel panel8;
        private Label label19;
        private Label lblBulkClose;
        private Button btnEmployee;
    }
}