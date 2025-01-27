namespace LocalApplication
{
    partial class OnSiteTesting
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
            label2 = new Label();
            label3 = new Label();
            txtImageName = new TextBox();
            txtOutputFolder = new TextBox();
            txtLocation = new TextBox();
            label4 = new Label();
            btnUpload = new Button();
            btnNext = new Button();
            pnlStep1 = new Panel();
            pnlShowImage = new Panel();
            pnlChangeStatus = new Panel();
            button1 = new Button();
            btnSave = new Button();
            cmbStatus = new ComboBox();
            btnNxt = new Button();
            pnlProcessBody = new Panel();
            pictureBox1 = new PictureBox();
            lblProcessId = new Label();
            tblProcessButtons = new TableLayoutPanel();
            panel2 = new Panel();
            lblDate = new Label();
            panel3 = new Panel();
            lblImageName = new Label();
            label7 = new Label();
            panel4 = new Panel();
            btnCompanyName = new Label();
            panel5 = new Panel();
            lblWCCounter = new Label();
            label6 = new Label();
            lblDefCounter = new Label();
            label12 = new Label();
            lblOKCounter = new Label();
            label8 = new Label();
            panel6 = new Panel();
            lblStatus = new Label();
            panel7 = new Panel();
            lblSeverityScore = new Label();
            panel8 = new Panel();
            btnFullScreen = new Button();
            panel9 = new Panel();
            lblCriteriaName = new Label();
            btnRecapture = new Button();
            btnChangeStatus = new Button();
            btnProcess = new Button();
            txtImgName = new TextBox();
            txtImagePath = new TextBox();
            label1 = new Label();
            txtModuleSerialNo = new TextBox();
            label5 = new Label();
            pnlStep1.SuspendLayout();
            pnlShowImage.SuspendLayout();
            pnlChangeStatus.SuspendLayout();
            pnlProcessBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tblProcessButtons.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
            panel9.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(36, 146);
            label2.Name = "label2";
            label2.Size = new Size(75, 15);
            label2.TabIndex = 1;
            label2.Text = "Image Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(36, 228);
            label3.Name = "label3";
            label3.Size = new Size(81, 15);
            label3.TabIndex = 2;
            label3.Text = "Output Folder";
            // 
            // txtImageName
            // 
            txtImageName.Location = new Point(140, 143);
            txtImageName.Name = "txtImageName";
            txtImageName.Size = new Size(333, 23);
            txtImageName.TabIndex = 3;
            // 
            // txtOutputFolder
            // 
            txtOutputFolder.Location = new Point(140, 225);
            txtOutputFolder.Name = "txtOutputFolder";
            txtOutputFolder.Size = new Size(242, 23);
            txtOutputFolder.TabIndex = 4;
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(140, 183);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(333, 23);
            txtLocation.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(36, 186);
            label4.Name = "label4";
            label4.Size = new Size(97, 15);
            label4.TabIndex = 5;
            label4.Text = "Module Location";
            // 
            // btnUpload
            // 
            btnUpload.Location = new Point(388, 225);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(85, 23);
            btnUpload.TabIndex = 7;
            btnUpload.Text = "Upload";
            btnUpload.UseVisualStyleBackColor = true;
            btnUpload.Click += btnUpload_Click;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(319, 279);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(154, 28);
            btnNext.TabIndex = 8;
            btnNext.Text = "Save and Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // pnlStep1
            // 
            pnlStep1.BackColor = Color.Navy;
            pnlStep1.Controls.Add(pnlShowImage);
            pnlStep1.Controls.Add(label1);
            pnlStep1.Controls.Add(txtModuleSerialNo);
            pnlStep1.Controls.Add(label5);
            pnlStep1.Controls.Add(txtLocation);
            pnlStep1.Controls.Add(btnNext);
            pnlStep1.Controls.Add(label2);
            pnlStep1.Controls.Add(btnUpload);
            pnlStep1.Controls.Add(label3);
            pnlStep1.Controls.Add(txtImageName);
            pnlStep1.Controls.Add(label4);
            pnlStep1.Controls.Add(txtOutputFolder);
            pnlStep1.Dock = DockStyle.Fill;
            pnlStep1.Location = new Point(0, 0);
            pnlStep1.Name = "pnlStep1";
            pnlStep1.Size = new Size(911, 600);
            pnlStep1.TabIndex = 9;
            // 
            // pnlShowImage
            // 
            pnlShowImage.Controls.Add(pnlChangeStatus);
            pnlShowImage.Controls.Add(btnNxt);
            pnlShowImage.Controls.Add(pnlProcessBody);
            pnlShowImage.Controls.Add(lblProcessId);
            pnlShowImage.Controls.Add(tblProcessButtons);
            pnlShowImage.Controls.Add(btnProcess);
            pnlShowImage.Controls.Add(txtImgName);
            pnlShowImage.Controls.Add(txtImagePath);
            pnlShowImage.Location = new Point(40, 459);
            pnlShowImage.Name = "pnlShowImage";
            pnlShowImage.Size = new Size(52, 65);
            pnlShowImage.TabIndex = 10;
            pnlShowImage.Visible = false;
            pnlShowImage.Click += pnlShowImage_Click;
            // 
            // pnlChangeStatus
            // 
            pnlChangeStatus.Controls.Add(button1);
            pnlChangeStatus.Controls.Add(btnSave);
            pnlChangeStatus.Controls.Add(cmbStatus);
            pnlChangeStatus.Location = new Point(705, 123);
            pnlChangeStatus.Name = "pnlChangeStatus";
            pnlChangeStatus.Size = new Size(200, 100);
            pnlChangeStatus.TabIndex = 6;
            // 
            // button1
            // 
            button1.BackColor = Color.Red;
            button1.FlatAppearance.BorderColor = Color.Red;
            button1.ForeColor = SystemColors.ControlLightLight;
            button1.Location = new Point(15, 43);
            button1.Name = "button1";
            button1.Size = new Size(77, 25);
            button1.TabIndex = 5;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.DarkGreen;
            btnSave.FlatAppearance.BorderColor = Color.Lime;
            btnSave.ForeColor = SystemColors.ControlLightLight;
            btnSave.Location = new Point(113, 43);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(74, 25);
            btnSave.TabIndex = 4;
            btnSave.Text = "Change";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "OK", "DEFECTIVE", "WITHIN CRITERIA" });
            cmbStatus.Location = new Point(15, 14);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(172, 23);
            cmbStatus.TabIndex = 2;
            // 
            // btnNxt
            // 
            btnNxt.Location = new Point(511, 547);
            btnNxt.Name = "btnNxt";
            btnNxt.Size = new Size(194, 46);
            btnNxt.TabIndex = 6;
            btnNxt.Text = "Next";
            btnNxt.UseVisualStyleBackColor = true;
            btnNxt.Click += btnNxt_Click;
            // 
            // pnlProcessBody
            // 
            pnlProcessBody.Controls.Add(pictureBox1);
            pnlProcessBody.Location = new Point(12, 123);
            pnlProcessBody.Name = "pnlProcessBody";
            pnlProcessBody.Size = new Size(687, 421);
            pnlProcessBody.TabIndex = 5;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(15, 11);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(655, 390);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // lblProcessId
            // 
            lblProcessId.AutoSize = true;
            lblProcessId.Location = new Point(374, 565);
            lblProcessId.Name = "lblProcessId";
            lblProcessId.Size = new Size(13, 15);
            lblProcessId.TabIndex = 4;
            lblProcessId.Text = "0";
            lblProcessId.Visible = false;
            // 
            // tblProcessButtons
            // 
            tblProcessButtons.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tblProcessButtons.ColumnCount = 5;
            tblProcessButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 43.5897446F));
            tblProcessButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 56.4102554F));
            tblProcessButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 212F));
            tblProcessButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 178F));
            tblProcessButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 169F));
            tblProcessButtons.Controls.Add(panel2, 0, 0);
            tblProcessButtons.Controls.Add(panel3, 1, 0);
            tblProcessButtons.Controls.Add(panel4, 0, 1);
            tblProcessButtons.Controls.Add(panel5, 1, 1);
            tblProcessButtons.Controls.Add(panel6, 2, 0);
            tblProcessButtons.Controls.Add(panel7, 2, 1);
            tblProcessButtons.Controls.Add(panel8, 3, 0);
            tblProcessButtons.Controls.Add(panel9, 3, 1);
            tblProcessButtons.Controls.Add(btnRecapture, 4, 0);
            tblProcessButtons.Controls.Add(btnChangeStatus, 4, 1);
            tblProcessButtons.Location = new Point(122, 29);
            tblProcessButtons.Name = "tblProcessButtons";
            tblProcessButtons.RowCount = 2;
            tblProcessButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblProcessButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblProcessButtons.Size = new Size(0, 0);
            tblProcessButtons.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(lblDate);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(1, 1);
            panel2.TabIndex = 0;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(57, 19);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(31, 15);
            lblDate.TabIndex = 0;
            lblDate.Text = "Date";
            // 
            // panel3
            // 
            panel3.Controls.Add(lblImageName);
            panel3.Controls.Add(label7);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(-240, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(1, 1);
            panel3.TabIndex = 1;
            // 
            // lblImageName
            // 
            lblImageName.AutoSize = true;
            lblImageName.Location = new Point(63, 17);
            lblImageName.Name = "lblImageName";
            lblImageName.Size = new Size(75, 15);
            lblImageName.TabIndex = 1;
            lblImageName.Text = "Image Name";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(73, 15);
            label7.Name = "label7";
            label7.Size = new Size(38, 15);
            label7.TabIndex = 0;
            label7.Text = "label7";
            // 
            // panel4
            // 
            panel4.Controls.Add(btnCompanyName);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(3, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(1, 1);
            panel4.TabIndex = 2;
            // 
            // btnCompanyName
            // 
            btnCompanyName.AutoSize = true;
            btnCompanyName.Location = new Point(24, 15);
            btnCompanyName.Name = "btnCompanyName";
            btnCompanyName.Size = new Size(94, 15);
            btnCompanyName.TabIndex = 1;
            btnCompanyName.Text = "Company Name";
            // 
            // panel5
            // 
            panel5.Controls.Add(lblWCCounter);
            panel5.Controls.Add(label6);
            panel5.Controls.Add(lblDefCounter);
            panel5.Controls.Add(label12);
            panel5.Controls.Add(lblOKCounter);
            panel5.Controls.Add(label8);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(-240, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(1, 1);
            panel5.TabIndex = 3;
            // 
            // lblWCCounter
            // 
            lblWCCounter.AutoSize = true;
            lblWCCounter.Location = new Point(162, 30);
            lblWCCounter.Name = "lblWCCounter";
            lblWCCounter.Size = new Size(13, 15);
            lblWCCounter.TabIndex = 6;
            lblWCCounter.Text = "0";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(70, 10);
            label6.Name = "label6";
            label6.Size = new Size(56, 15);
            label6.TabIndex = 2;
            label6.Text = "Defective";
            // 
            // lblDefCounter
            // 
            lblDefCounter.AutoSize = true;
            lblDefCounter.Location = new Point(84, 31);
            lblDefCounter.Name = "lblDefCounter";
            lblDefCounter.Size = new Size(13, 15);
            lblDefCounter.TabIndex = 5;
            lblDefCounter.Text = "0";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(9, 10);
            label12.Name = "label12";
            label12.Size = new Size(23, 15);
            label12.TabIndex = 1;
            label12.Text = "OK";
            // 
            // lblOKCounter
            // 
            lblOKCounter.AutoSize = true;
            lblOKCounter.Location = new Point(14, 30);
            lblOKCounter.Name = "lblOKCounter";
            lblOKCounter.Size = new Size(13, 15);
            lblOKCounter.TabIndex = 4;
            lblOKCounter.Text = "0";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(156, 10);
            label8.Name = "label8";
            label8.Size = new Size(26, 15);
            label8.TabIndex = 3;
            label8.Text = "WC";
            // 
            // panel6
            // 
            panel6.Controls.Add(lblStatus);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(-554, 3);
            panel6.Name = "panel6";
            panel6.Size = new Size(206, 1);
            panel6.TabIndex = 4;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(85, 18);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(39, 15);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Status";
            // 
            // panel7
            // 
            panel7.Controls.Add(lblSeverityScore);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(-554, 3);
            panel7.Name = "panel7";
            panel7.Size = new Size(206, 1);
            panel7.TabIndex = 5;
            // 
            // lblSeverityScore
            // 
            lblSeverityScore.AutoSize = true;
            lblSeverityScore.Location = new Point(69, 16);
            lblSeverityScore.Name = "lblSeverityScore";
            lblSeverityScore.Size = new Size(80, 15);
            lblSeverityScore.TabIndex = 1;
            lblSeverityScore.Text = "Severity Score";
            // 
            // panel8
            // 
            panel8.Controls.Add(btnFullScreen);
            panel8.Dock = DockStyle.Fill;
            panel8.Location = new Point(-342, 3);
            panel8.Name = "panel8";
            panel8.Size = new Size(172, 1);
            panel8.TabIndex = 6;
            // 
            // btnFullScreen
            // 
            btnFullScreen.Location = new Point(0, 0);
            btnFullScreen.Name = "btnFullScreen";
            btnFullScreen.Size = new Size(172, 54);
            btnFullScreen.TabIndex = 9;
            btnFullScreen.Text = "Full Screen";
            btnFullScreen.UseVisualStyleBackColor = true;
            btnFullScreen.Click += btnFullScreen_Click;
            // 
            // panel9
            // 
            panel9.Controls.Add(lblCriteriaName);
            panel9.Dock = DockStyle.Fill;
            panel9.Location = new Point(-342, 3);
            panel9.Name = "panel9";
            panel9.Size = new Size(172, 1);
            panel9.TabIndex = 7;
            // 
            // lblCriteriaName
            // 
            lblCriteriaName.AutoSize = true;
            lblCriteriaName.Location = new Point(49, 15);
            lblCriteriaName.Name = "lblCriteriaName";
            lblCriteriaName.Size = new Size(80, 15);
            lblCriteriaName.TabIndex = 1;
            lblCriteriaName.Text = "Criteria Name";
            // 
            // btnRecapture
            // 
            btnRecapture.Location = new Point(-164, 3);
            btnRecapture.Name = "btnRecapture";
            btnRecapture.Size = new Size(158, 1);
            btnRecapture.TabIndex = 8;
            btnRecapture.Text = "Recapture";
            btnRecapture.UseVisualStyleBackColor = true;
            btnRecapture.Click += btnRecapture_Click;
            // 
            // btnChangeStatus
            // 
            btnChangeStatus.Location = new Point(-164, 3);
            btnChangeStatus.Name = "btnChangeStatus";
            btnChangeStatus.Size = new Size(158, 1);
            btnChangeStatus.TabIndex = 9;
            btnChangeStatus.Text = "Change Status";
            btnChangeStatus.UseVisualStyleBackColor = true;
            btnChangeStatus.Click += btnChangeStatus_Click;
            // 
            // btnProcess
            // 
            btnProcess.Location = new Point(711, 547);
            btnProcess.Name = "btnProcess";
            btnProcess.Size = new Size(194, 46);
            btnProcess.TabIndex = 1;
            btnProcess.Text = "Process";
            btnProcess.UseVisualStyleBackColor = true;
            btnProcess.Click += btnProcess_Click;
            // 
            // txtImgName
            // 
            txtImgName.Location = new Point(186, 562);
            txtImgName.Name = "txtImgName";
            txtImgName.Size = new Size(169, 23);
            txtImgName.TabIndex = 3;
            txtImgName.Visible = false;
            // 
            // txtImagePath
            // 
            txtImagePath.Location = new Point(12, 562);
            txtImagePath.Name = "txtImagePath";
            txtImagePath.Size = new Size(169, 23);
            txtImagePath.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(36, 108);
            label1.Name = "label1";
            label1.Size = new Size(98, 15);
            label1.TabIndex = 10;
            label1.Text = "Module Serial No";
            // 
            // txtModuleSerialNo
            // 
            txtModuleSerialNo.Location = new Point(140, 105);
            txtModuleSerialNo.Name = "txtModuleSerialNo";
            txtModuleSerialNo.Size = new Size(333, 23);
            txtModuleSerialNo.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(40, 37);
            label5.Name = "label5";
            label5.Size = new Size(185, 32);
            label5.TabIndex = 9;
            label5.Text = "On Site Testing";
            // 
            // OnSiteTesting
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlStep1);
            Name = "OnSiteTesting";
            Size = new Size(911, 600);
            Load += OnSiteTesting_Load;
            pnlStep1.ResumeLayout(false);
            pnlStep1.PerformLayout();
            pnlShowImage.ResumeLayout(false);
            pnlShowImage.PerformLayout();
            pnlChangeStatus.ResumeLayout(false);
            pnlProcessBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tblProcessButtons.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel8.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label2;
        private Label label3;
        private TextBox txtImageName;
        private TextBox txtOutputFolder;
        private TextBox txtLocation;
        private Label label4;
        private Button btnUpload;
        private Button btnNext;
        private Panel pnlStep1;
        private Label label5;
        private Label label1;
        private TextBox txtModuleSerialNo;
        private Panel pnlShowImage;
        private Panel pnlChangeStatus;
        private Button button1;
        private Button btnSave;
        private ComboBox cmbStatus;
        private Button btnNxt;
        private Panel pnlProcessBody;
        private PictureBox pictureBox1;
        private Label lblProcessId;
        private TableLayoutPanel tblProcessButtons;
        private Panel panel2;
        private Label lblDate;
        private Panel panel3;
        private Label lblImageName;
        private Label label7;
        private Panel panel4;
        private Label btnCompanyName;
        private Panel panel5;
        private Label lblWCCounter;
        private Label label6;
        private Label lblDefCounter;
        private Label label12;
        private Label lblOKCounter;
        private Label label8;
        private Panel panel6;
        private Label lblStatus;
        private Panel panel7;
        private Label lblSeverityScore;
        private Panel panel8;
        private Button btnFullScreen;
        private Panel panel9;
        private Label lblCriteriaName;
        private Button btnRecapture;
        private Button btnChangeStatus;
        private Button btnProcess;
        private TextBox txtImgName;
        private TextBox txtImagePath;
    }
}
