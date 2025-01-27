namespace LocalApplication
{
    partial class ImageProcessData
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
            cmbProjectStatus = new ComboBox();
            label3 = new Label();
            label5 = new Label();
            label4 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            panel3 = new Panel();
            gvProjectList = new DataGridView();
            tableLayoutPanel3 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            txtFromDate = new DateTimePicker();
            txtToDate = new DateTimePicker();
            lblProjectId = new Label();
            panel2 = new Panel();
            lblClose = new Label();
            label19 = new Label();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvProjectList).BeginInit();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnSearch.BackColor = Color.Navy;
            btnSearch.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = SystemColors.ControlLightLight;
            btnSearch.Location = new Point(369, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(158, 33);
            btnSearch.TabIndex = 10;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // cmbProjectStatus
            // 
            cmbProjectStatus.Anchor = AnchorStyles.None;
            cmbProjectStatus.FormattingEnabled = true;
            cmbProjectStatus.Items.AddRange(new object[] { "OK", "Defective", "Within Criteria" });
            cmbProjectStatus.Location = new Point(154, 8);
            cmbProjectStatus.Name = "cmbProjectStatus";
            cmbProjectStatus.Size = new Size(206, 23);
            cmbProjectStatus.TabIndex = 4;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(3, 12);
            label3.Name = "label3";
            label3.Size = new Size(92, 15);
            label3.TabIndex = 5;
            label3.Text = "Image Result";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(251, 8);
            label5.Name = "label5";
            label5.Size = new Size(57, 15);
            label5.TabIndex = 7;
            label5.Text = "To Date";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(6, 8);
            label4.Name = "label4";
            label4.Size = new Size(74, 15);
            label4.TabIndex = 6;
            label4.Text = "From Date";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Location = new Point(0, 44);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10.38961F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 89.61039F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(534, 491);
            tableLayoutPanel1.TabIndex = 11;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(tableLayoutPanel3);
            panel1.Controls.Add(tableLayoutPanel2);
            panel1.Controls.Add(lblProjectId);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(528, 484);
            panel1.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Controls.Add(gvProjectList);
            panel3.Location = new Point(7, 77);
            panel3.Name = "panel3";
            panel3.Size = new Size(514, 397);
            panel3.TabIndex = 16;
            // 
            // gvProjectList
            // 
            gvProjectList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvProjectList.Location = new Point(0, 0);
            gvProjectList.Name = "gvProjectList";
            gvProjectList.Size = new Size(514, 397);
            gvProjectList.TabIndex = 3;
            gvProjectList.CellDoubleClick += gvProjectList_CellDoubleClick;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.1519871F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40.9326439F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.62201F));
            tableLayoutPanel3.Controls.Add(label3, 0, 0);
            tableLayoutPanel3.Controls.Add(btnSearch, 2, 0);
            tableLayoutPanel3.Controls.Add(cmbProjectStatus, 1, 0);
            tableLayoutPanel3.Location = new Point(-1, 32);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(530, 39);
            tableLayoutPanel3.TabIndex = 15;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.69903F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31.06796F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.2038832F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 39.0291252F));
            tableLayoutPanel2.Controls.Add(label4, 0, 0);
            tableLayoutPanel2.Controls.Add(txtFromDate, 1, 0);
            tableLayoutPanel2.Controls.Add(label5, 2, 0);
            tableLayoutPanel2.Controls.Add(txtToDate, 3, 0);
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(515, 31);
            tableLayoutPanel2.TabIndex = 14;
            // 
            // txtFromDate
            // 
            txtFromDate.Anchor = AnchorStyles.None;
            txtFromDate.Location = new Point(89, 4);
            txtFromDate.MinDate = new DateTime(2024, 11, 30, 0, 0, 0, 0);
            txtFromDate.Name = "txtFromDate";
            txtFromDate.Size = new Size(154, 23);
            txtFromDate.TabIndex = 11;
            txtFromDate.ValueChanged += txtFromDate_ValueChanged;
            // 
            // txtToDate
            // 
            txtToDate.Anchor = AnchorStyles.None;
            txtToDate.Location = new Point(317, 4);
            txtToDate.MinDate = new DateTime(2024, 12, 31, 0, 0, 0, 0);
            txtToDate.Name = "txtToDate";
            txtToDate.Size = new Size(195, 23);
            txtToDate.TabIndex = 12;
            // 
            // lblProjectId
            // 
            lblProjectId.AutoSize = true;
            lblProjectId.Location = new Point(11, 34);
            lblProjectId.Name = "lblProjectId";
            lblProjectId.Size = new Size(13, 15);
            lblProjectId.TabIndex = 13;
            lblProjectId.Text = "0";
            lblProjectId.Visible = false;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.Navy;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(541, 10);
            panel2.TabIndex = 2;
            // 
            // lblClose
            // 
            lblClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblClose.Cursor = Cursors.Hand;
            lblClose.Font = new Font("Calibri", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblClose.ForeColor = Color.Red;
            lblClose.Location = new Point(499, 15);
            lblClose.Name = "lblClose";
            lblClose.Size = new Size(24, 26);
            lblClose.TabIndex = 22;
            lblClose.Text = "X";
            lblClose.Click += lblClose_Click;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label19.ForeColor = SystemColors.GrayText;
            label19.Location = new Point(4, 14);
            label19.Name = "label19";
            label19.Size = new Size(263, 31);
            label19.TabIndex = 23;
            label19.Text = "Image Process List";
            // 
            // ImageProcessData
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(535, 535);
            Controls.Add(label19);
            Controls.Add(lblClose);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ImageProcessData";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ProjectList";
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gvProjectList).EndInit();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox cmbProjectStatus;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnSearch;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private DateTimePicker txtToDate;
        private DateTimePicker txtFromDate;
        private Panel panel2;
        private Label lblProjectId;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private Label lblClose;
        private Panel panel3;
        private Label label19;
        private DataGridView gvProjectList;
    }
}