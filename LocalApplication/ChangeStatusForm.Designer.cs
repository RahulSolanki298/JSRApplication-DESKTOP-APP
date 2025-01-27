namespace LocalApplication
{
    partial class ChangeStatusForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeStatusForm));
            pnlBulkInsert = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            lblProcessCounter = new Label();
            lblNoOfImages = new Label();
            panel2 = new Panel();
            chkIsExcel = new CheckBox();
            btnExcelUpload = new Button();
            lblExcelUpload = new Label();
            label18 = new Label();
            _loader = new PictureBox();
            txtExcelUpload = new TextBox();
            txtInputFolder = new TextBox();
            btnUploadInputFolder = new Button();
            btnSaveBulkImage = new Button();
            btnCancel = new Button();
            lblId = new Label();
            dgvData = new DataGridView();
            lblBulkClose = new Label();
            label19 = new Label();
            panel1 = new Panel();
            pnlBulkInsert.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_loader).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            SuspendLayout();
            // 
            // pnlBulkInsert
            // 
            pnlBulkInsert.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlBulkInsert.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlBulkInsert.BackColor = Color.WhiteSmoke;
            pnlBulkInsert.BorderStyle = BorderStyle.FixedSingle;
            pnlBulkInsert.Controls.Add(tableLayoutPanel1);
            pnlBulkInsert.Controls.Add(panel2);
            pnlBulkInsert.Controls.Add(lblId);
            pnlBulkInsert.Controls.Add(dgvData);
            pnlBulkInsert.Controls.Add(lblBulkClose);
            pnlBulkInsert.Controls.Add(label19);
            pnlBulkInsert.ForeColor = SystemColors.GrayText;
            pnlBulkInsert.Location = new Point(0, 12);
            pnlBulkInsert.Name = "pnlBulkInsert";
            pnlBulkInsert.Size = new Size(627, 487);
            pnlBulkInsert.TabIndex = 32;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 69.4379654F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.5620289F));
            tableLayoutPanel1.Controls.Add(lblNoOfImages, 1, 0);
            tableLayoutPanel1.Controls.Add(lblProcessCounter, 1, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Location = new Point(4, 431);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(616, 51);
            tableLayoutPanel1.TabIndex = 47;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(4, 1);
            label1.Name = "label1";
            label1.Size = new Size(419, 15);
            label1.TabIndex = 14;
            label1.Text = "No of Inputed files :-";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ControlText;
            label2.Location = new Point(4, 26);
            label2.Name = "label2";
            label2.Size = new Size(419, 15);
            label2.TabIndex = 45;
            label2.Text = "No of processed files :-";
            // 
            // lblProcessCounter
            // 
            lblProcessCounter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblProcessCounter.AutoSize = true;
            lblProcessCounter.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            lblProcessCounter.ForeColor = SystemColors.ControlText;
            lblProcessCounter.Location = new Point(430, 26);
            lblProcessCounter.Name = "lblProcessCounter";
            lblProcessCounter.Size = new Size(182, 15);
            lblProcessCounter.TabIndex = 44;
            lblProcessCounter.Text = "0";
            // 
            // lblNoOfImages
            // 
            lblNoOfImages.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblNoOfImages.AutoSize = true;
            lblNoOfImages.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            lblNoOfImages.ForeColor = SystemColors.ControlText;
            lblNoOfImages.Location = new Point(430, 1);
            lblNoOfImages.Name = "lblNoOfImages";
            lblNoOfImages.Size = new Size(182, 15);
            lblNoOfImages.TabIndex = 13;
            lblNoOfImages.Text = "0";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = SystemColors.ControlLightLight;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(chkIsExcel);
            panel2.Controls.Add(btnExcelUpload);
            panel2.Controls.Add(lblExcelUpload);
            panel2.Controls.Add(label18);
            panel2.Controls.Add(_loader);
            panel2.Controls.Add(txtExcelUpload);
            panel2.Controls.Add(txtInputFolder);
            panel2.Controls.Add(btnUploadInputFolder);
            panel2.Controls.Add(btnSaveBulkImage);
            panel2.Controls.Add(btnCancel);
            panel2.Location = new Point(80, 30);
            panel2.Name = "panel2";
            panel2.Size = new Size(450, 133);
            panel2.TabIndex = 46;
            // 
            // chkIsExcel
            // 
            chkIsExcel.AutoSize = true;
            chkIsExcel.Location = new Point(21, 7);
            chkIsExcel.Name = "chkIsExcel";
            chkIsExcel.Size = new Size(184, 19);
            chkIsExcel.TabIndex = 7;
            chkIsExcel.Text = "Bulk Image Process with Excel";
            chkIsExcel.UseVisualStyleBackColor = true;
            chkIsExcel.CheckedChanged += chkIsExcel_CheckedChanged;
            // 
            // btnExcelUpload
            // 
            btnExcelUpload.Location = new Point(332, 72);
            btnExcelUpload.Name = "btnExcelUpload";
            btnExcelUpload.Size = new Size(107, 24);
            btnExcelUpload.TabIndex = 5;
            btnExcelUpload.Text = "Upload";
            btnExcelUpload.UseVisualStyleBackColor = true;
            btnExcelUpload.Click += btnExcelUpload_Click;
            // 
            // lblExcelUpload
            // 
            lblExcelUpload.AutoSize = true;
            lblExcelUpload.ForeColor = SystemColors.InactiveCaptionText;
            lblExcelUpload.Location = new Point(20, 72);
            lblExcelUpload.Name = "lblExcelUpload";
            lblExcelUpload.Size = new Size(86, 15);
            lblExcelUpload.TabIndex = 1;
            lblExcelUpload.Text = "Excel Upload :-";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.ForeColor = SystemColors.InactiveCaptionText;
            label18.Location = new Point(20, 35);
            label18.Name = "label18";
            label18.Size = new Size(82, 15);
            label18.TabIndex = 2;
            label18.Text = "Input Folder :-";
            // 
            // _loader
            // 
            _loader.Image = (Image)resources.GetObject("_loader.Image");
            _loader.Location = new Point(227, 98);
            _loader.Name = "_loader";
            _loader.Size = new Size(26, 28);
            _loader.SizeMode = PictureBoxSizeMode.StretchImage;
            _loader.TabIndex = 42;
            _loader.TabStop = false;
            // 
            // txtExcelUpload
            // 
            txtExcelUpload.Location = new Point(109, 68);
            txtExcelUpload.Name = "txtExcelUpload";
            txtExcelUpload.Size = new Size(217, 23);
            txtExcelUpload.TabIndex = 3;
            // 
            // txtInputFolder
            // 
            txtInputFolder.Location = new Point(108, 32);
            txtInputFolder.Name = "txtInputFolder";
            txtInputFolder.Size = new Size(218, 23);
            txtInputFolder.TabIndex = 4;
            // 
            // btnUploadInputFolder
            // 
            btnUploadInputFolder.Location = new Point(332, 30);
            btnUploadInputFolder.Name = "btnUploadInputFolder";
            btnUploadInputFolder.Size = new Size(107, 24);
            btnUploadInputFolder.TabIndex = 6;
            btnUploadInputFolder.Text = "Upload";
            btnUploadInputFolder.UseVisualStyleBackColor = true;
            btnUploadInputFolder.Click += btnUploadInputFolder_Click;
            // 
            // btnSaveBulkImage
            // 
            btnSaveBulkImage.BackColor = Color.DarkGreen;
            btnSaveBulkImage.ForeColor = SystemColors.ControlLightLight;
            btnSaveBulkImage.Location = new Point(118, 97);
            btnSaveBulkImage.Name = "btnSaveBulkImage";
            btnSaveBulkImage.Size = new Size(103, 29);
            btnSaveBulkImage.TabIndex = 7;
            btnSaveBulkImage.Text = "Start Execute";
            btnSaveBulkImage.UseVisualStyleBackColor = false;
            btnSaveBulkImage.Click += btnSaveBulkImage_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Red;
            btnCancel.ForeColor = SystemColors.ControlLightLight;
            btnCancel.Location = new Point(21, 97);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(91, 29);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Stop";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Rockwell", 12F);
            lblId.Location = new Point(291, 11);
            lblId.Name = "lblId";
            lblId.Size = new Size(18, 19);
            lblId.TabIndex = 43;
            lblId.Text = "0";
            lblId.Visible = false;
            // 
            // dgvData
            // 
            dgvData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Location = new Point(4, 169);
            dgvData.Name = "dgvData";
            dgvData.ScrollBars = ScrollBars.Vertical;
            dgvData.Size = new Size(616, 256);
            dgvData.TabIndex = 12;
            dgvData.CellClick += dgvData_CellClick;
            // 
            // lblBulkClose
            // 
            lblBulkClose.AutoSize = true;
            lblBulkClose.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblBulkClose.ForeColor = Color.Red;
            lblBulkClose.Location = new Point(596, 5);
            lblBulkClose.Name = "lblBulkClose";
            lblBulkClose.Size = new Size(24, 25);
            lblBulkClose.TabIndex = 10;
            lblBulkClose.Text = "X";
            lblBulkClose.Click += lblBulkClose_Click;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Rockwell", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label19.ForeColor = SystemColors.GrayText;
            label19.Location = new Point(4, 4);
            label19.Name = "label19";
            label19.Size = new Size(199, 23);
            label19.TabIndex = 0;
            label19.Text = "Bulk Image Process";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.Navy;
            panel1.Location = new Point(0, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(627, 12);
            panel1.TabIndex = 33;
            // 
            // ChangeStatusForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(626, 500);
            Controls.Add(panel1);
            Controls.Add(pnlBulkInsert);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ChangeStatusForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ChangeStatusForm";
            pnlBulkInsert.ResumeLayout(false);
            pnlBulkInsert.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_loader).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlBulkInsert;
        private Label lblBulkClose;
        private Button btnCancel;
        private Button btnSaveBulkImage;
        private Button btnUploadInputFolder;
        private Button btnExcelUpload;
        private TextBox txtInputFolder;
        private TextBox txtExcelUpload;
        private Label label18;
        private Label lblExcelUpload;
        private Label label19;
        private Panel panel1;
        private Label label1;
        private Label lblNoOfImages;
        private PictureBox _loader;
        private DataGridView dgvData;
        private Label lblId;
        private Label label2;
        private Label lblProcessCounter;
        private Panel panel2;
        private CheckBox chkIsExcel;
        private TableLayoutPanel tableLayoutPanel1;
    }
}