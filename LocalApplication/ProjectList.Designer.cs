namespace LocalApplication
{
    partial class ProjectList
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
            btnSearch = new Button();
            gvProjectList = new DataGridView();
            panel2 = new Panel();
            lblClose = new Label();
            panel3 = new Panel();
            tableLayoutPanel5 = new TableLayoutPanel();
            label4 = new Label();
            label2 = new Label();
            label3 = new Label();
            cmbProjectStatus = new ComboBox();
            txtFromDate = new DateTimePicker();
            txtToDate = new DateTimePicker();
            label19 = new Label();
            ((System.ComponentModel.ISupportInitialize)gvProjectList).BeginInit();
            panel3.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            SuspendLayout();
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.BackColor = Color.Navy;
            btnSearch.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = SystemColors.ControlLightLight;
            btnSearch.Location = new Point(424, 138);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(119, 31);
            btnSearch.TabIndex = 10;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // gvProjectList
            // 
            gvProjectList.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gvProjectList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvProjectList.Location = new Point(0, 3);
            gvProjectList.Name = "gvProjectList";
            gvProjectList.Size = new Size(531, 361);
            gvProjectList.TabIndex = 2;
            gvProjectList.CellDoubleClick += gvProjectList_CellClick;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.Navy;
            panel2.Location = new Point(-5, -2);
            panel2.Name = "panel2";
            panel2.Size = new Size(566, 10);
            panel2.TabIndex = 19;
            // 
            // lblClose
            // 
            lblClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblClose.Cursor = Cursors.Hand;
            lblClose.Font = new Font("Calibri", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblClose.ForeColor = Color.Red;
            lblClose.Location = new Point(519, 20);
            lblClose.Name = "lblClose";
            lblClose.Size = new Size(24, 26);
            lblClose.TabIndex = 21;
            lblClose.Text = "X";
            lblClose.Click += lblClose_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(gvProjectList);
            panel3.Location = new Point(12, 175);
            panel3.Name = "panel3";
            panel3.Size = new Size(531, 365);
            panel3.TabIndex = 22;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel5.ColumnCount = 3;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.434782F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.434782F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.434782F));
            tableLayoutPanel5.Controls.Add(label4, 2, 0);
            tableLayoutPanel5.Controls.Add(label2, 0, 0);
            tableLayoutPanel5.Controls.Add(label3, 1, 0);
            tableLayoutPanel5.Controls.Add(cmbProjectStatus, 2, 1);
            tableLayoutPanel5.Controls.Add(txtFromDate, 0, 1);
            tableLayoutPanel5.Controls.Add(txtToDate, 1, 1);
            tableLayoutPanel5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            tableLayoutPanel5.ForeColor = SystemColors.ButtonShadow;
            tableLayoutPanel5.Location = new Point(12, 72);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 2;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tableLayoutPanel5.Size = new Size(533, 60);
            tableLayoutPanel5.TabIndex = 51;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            label4.ForeColor = SystemColors.ControlDarkDark;
            label4.Location = new Point(420, 8);
            label4.Name = "label4";
            label4.Size = new Size(47, 15);
            label4.TabIndex = 15;
            label4.Text = "Status";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(51, 8);
            label2.Name = "label2";
            label2.Size = new Size(74, 15);
            label2.TabIndex = 13;
            label2.Text = "From Date";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ControlDarkDark;
            label3.Location = new Point(237, 8);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 14;
            label3.Text = "To Date";
            // 
            // cmbProjectStatus
            // 
            cmbProjectStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbProjectStatus.FormattingEnabled = true;
            cmbProjectStatus.Items.AddRange(new object[] { "Pending", "Completed", "Hold" });
            cmbProjectStatus.Location = new Point(357, 34);
            cmbProjectStatus.Name = "cmbProjectStatus";
            cmbProjectStatus.Size = new Size(173, 23);
            cmbProjectStatus.TabIndex = 4;
            // 
            // txtFromDate
            // 
            txtFromDate.Location = new Point(3, 34);
            txtFromDate.Name = "txtFromDate";
            txtFromDate.Size = new Size(170, 23);
            txtFromDate.TabIndex = 11;
            txtFromDate.ValueChanged += txtFromDate_ValueChanged;
            // 
            // txtToDate
            // 
            txtToDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtToDate.Location = new Point(181, 34);
            txtToDate.Name = "txtToDate";
            txtToDate.Size = new Size(170, 23);
            txtToDate.TabIndex = 12;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label19.ForeColor = SystemColors.GrayText;
            label19.Location = new Point(12, 20);
            label19.Name = "label19";
            label19.Size = new Size(161, 31);
            label19.TabIndex = 24;
            label19.Text = "Project List";
            // 
            // ProjectList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(557, 554);
            Controls.Add(label19);
            Controls.Add(tableLayoutPanel5);
            Controls.Add(btnSearch);
            Controls.Add(panel3);
            Controls.Add(lblClose);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ProjectList";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Project List";
            TransparencyKey = Color.Black;
            ((System.ComponentModel.ISupportInitialize)gvProjectList).EndInit();
            panel3.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnSearch;
        private Panel panel2;
        private Label lblClose;
        private DataGridView gvProjectList;
        private Panel panel3;
        private TableLayoutPanel tableLayoutPanel5;
        private Label label4;
        private Label label2;
        private Label label3;
        private ComboBox cmbProjectStatus;
        private DateTimePicker txtFromDate;
        private DateTimePicker txtToDate;
        private Label label19;
    }
}