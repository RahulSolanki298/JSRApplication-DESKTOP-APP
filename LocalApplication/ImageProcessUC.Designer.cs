namespace LocalApplication
{
    partial class ImageProcessUC
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            btnSave = new Button();
            chkExposure = new CheckBox();
            chkDefect = new CheckBox();
            chkPerspective = new CheckBox();
            chkImageRename = new CheckBox();
            ImageFullScreen = new CheckBox();
            chkSeverity = new CheckBox();
            chkIsertImages = new CheckBox();
            cmbRename = new ComboBox();
            txtExposureSet = new TextBox();
            lblID = new Label();
            panel2 = new Panel();
            lblProjectList = new Label();
            checkAll = new CheckBox();
            label9 = new Label();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, -33);
            label1.Name = "label1";
            label1.Size = new Size(354, 30);
            label1.TabIndex = 0;
            label1.Text = "Image Processing  Requirements ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ControlText;
            label2.Location = new Point(27, 98);
            label2.Name = "label2";
            label2.Size = new Size(73, 15);
            label2.TabIndex = 1;
            label2.Text = "Exposure set";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ControlText;
            label3.Location = new Point(27, 137);
            label3.Name = "label3";
            label3.Size = new Size(88, 15);
            label3.TabIndex = 2;
            label3.Text = "Defect Marking";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ControlText;
            label4.Location = new Point(27, 179);
            label4.Name = "label4";
            label4.Size = new Size(126, 15);
            label4.TabIndex = 3;
            label4.Text = "Perspective Correction";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.ControlText;
            label5.Location = new Point(27, 224);
            label5.Name = "label5";
            label5.Size = new Size(86, 15);
            label5.TabIndex = 4;
            label5.Text = "Image Rename";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = SystemColors.ControlText;
            label6.Location = new Point(27, 273);
            label6.Name = "label6";
            label6.Size = new Size(114, 15);
            label6.TabIndex = 5;
            label6.Text = "Insert Text in images";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = SystemColors.ControlText;
            label7.Location = new Point(27, 328);
            label7.Name = "label7";
            label7.Size = new Size(97, 15);
            label7.TabIndex = 6;
            label7.Text = "Image full screen";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = SystemColors.ControlText;
            label8.Location = new Point(27, 374);
            label8.Name = "label8";
            label8.Size = new Size(116, 15);
            label8.TabIndex = 7;
            label8.Text = "Image Severity Score";
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSave.BackColor = Color.Navy;
            btnSave.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = SystemColors.ControlLightLight;
            btnSave.Location = new Point(452, 0);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(139, 42);
            btnSave.TabIndex = 10;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // chkExposure
            // 
            chkExposure.AutoSize = true;
            chkExposure.ForeColor = SystemColors.ControlText;
            chkExposure.Location = new Point(317, 98);
            chkExposure.Name = "chkExposure";
            chkExposure.Size = new Size(15, 14);
            chkExposure.TabIndex = 11;
            chkExposure.UseVisualStyleBackColor = true;
            chkExposure.CheckedChanged += chkExposure_CheckedChanged;
            // 
            // chkDefect
            // 
            chkDefect.AutoSize = true;
            chkDefect.ForeColor = SystemColors.ControlText;
            chkDefect.Location = new Point(317, 138);
            chkDefect.Name = "chkDefect";
            chkDefect.Size = new Size(15, 14);
            chkDefect.TabIndex = 12;
            chkDefect.UseVisualStyleBackColor = true;
            // 
            // chkPerspective
            // 
            chkPerspective.AutoSize = true;
            chkPerspective.ForeColor = SystemColors.ControlText;
            chkPerspective.Location = new Point(317, 180);
            chkPerspective.Name = "chkPerspective";
            chkPerspective.Size = new Size(15, 14);
            chkPerspective.TabIndex = 13;
            chkPerspective.UseVisualStyleBackColor = true;
            // 
            // chkImageRename
            // 
            chkImageRename.AutoSize = true;
            chkImageRename.ForeColor = SystemColors.ControlText;
            chkImageRename.Location = new Point(317, 224);
            chkImageRename.Name = "chkImageRename";
            chkImageRename.Size = new Size(15, 14);
            chkImageRename.TabIndex = 14;
            chkImageRename.UseVisualStyleBackColor = true;
            chkImageRename.CheckedChanged += chkImageRename_CheckedChanged;
            // 
            // ImageFullScreen
            // 
            ImageFullScreen.AutoSize = true;
            ImageFullScreen.ForeColor = SystemColors.ControlText;
            ImageFullScreen.Location = new Point(317, 328);
            ImageFullScreen.Name = "ImageFullScreen";
            ImageFullScreen.Size = new Size(15, 14);
            ImageFullScreen.TabIndex = 15;
            ImageFullScreen.UseVisualStyleBackColor = true;
            // 
            // chkSeverity
            // 
            chkSeverity.AutoSize = true;
            chkSeverity.ForeColor = SystemColors.ControlText;
            chkSeverity.Location = new Point(317, 375);
            chkSeverity.Name = "chkSeverity";
            chkSeverity.Size = new Size(15, 14);
            chkSeverity.TabIndex = 16;
            chkSeverity.UseVisualStyleBackColor = true;
            // 
            // chkIsertImages
            // 
            chkIsertImages.AutoSize = true;
            chkIsertImages.ForeColor = SystemColors.ControlText;
            chkIsertImages.Location = new Point(317, 274);
            chkIsertImages.Name = "chkIsertImages";
            chkIsertImages.Size = new Size(15, 14);
            chkIsertImages.TabIndex = 18;
            chkIsertImages.UseVisualStyleBackColor = true;
            // 
            // cmbRename
            // 
            cmbRename.ForeColor = SystemColors.ControlText;
            cmbRename.FormattingEnabled = true;
            cmbRename.Items.AddRange(new object[] { "Excel", "Insert Name" });
            cmbRename.Location = new Point(366, 216);
            cmbRename.Name = "cmbRename";
            cmbRename.Size = new Size(181, 23);
            cmbRename.TabIndex = 20;
            cmbRename.Visible = false;
            // 
            // txtExposureSet
            // 
            txtExposureSet.ForeColor = SystemColors.ControlText;
            txtExposureSet.Location = new Point(366, 95);
            txtExposureSet.Name = "txtExposureSet";
            txtExposureSet.Size = new Size(181, 23);
            txtExposureSet.TabIndex = 22;
            txtExposureSet.Visible = false;
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.ForeColor = SystemColors.ControlText;
            lblID.Location = new Point(27, 61);
            lblID.Name = "lblID";
            lblID.Size = new Size(13, 15);
            lblID.TabIndex = 23;
            lblID.Text = "0";
            lblID.Visible = false;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.Lime;
            panel2.Controls.Add(lblProjectList);
            panel2.Controls.Add(btnSave);
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(589, 43);
            panel2.TabIndex = 24;
            // 
            // lblProjectList
            // 
            lblProjectList.AutoSize = true;
            lblProjectList.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProjectList.ForeColor = SystemColors.HighlightText;
            lblProjectList.Location = new Point(3, 10);
            lblProjectList.Margin = new Padding(3, 10, 3, 0);
            lblProjectList.Name = "lblProjectList";
            lblProjectList.Size = new Size(195, 24);
            lblProjectList.TabIndex = 1;
            lblProjectList.Text = "Image Process Data";
            lblProjectList.TextAlign = ContentAlignment.TopCenter;
            // 
            // checkAll
            // 
            checkAll.AutoSize = true;
            checkAll.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            checkAll.ForeColor = SystemColors.ControlText;
            checkAll.Location = new Point(317, 61);
            checkAll.Name = "checkAll";
            checkAll.Size = new Size(15, 14);
            checkAll.TabIndex = 25;
            checkAll.UseVisualStyleBackColor = true;
            checkAll.CheckedChanged += checkAll_CheckedChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label9.ForeColor = SystemColors.ControlText;
            label9.Location = new Point(27, 61);
            label9.Name = "label9";
            label9.Size = new Size(59, 15);
            label9.TabIndex = 26;
            label9.Text = "Select All";
            // 
            // ImageProcessUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(label9);
            Controls.Add(checkAll);
            Controls.Add(panel2);
            Controls.Add(lblID);
            Controls.Add(txtExposureSet);
            Controls.Add(cmbRename);
            Controls.Add(chkIsertImages);
            Controls.Add(chkSeverity);
            Controls.Add(ImageFullScreen);
            Controls.Add(chkImageRename);
            Controls.Add(chkPerspective);
            Controls.Add(chkDefect);
            Controls.Add(chkExposure);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ImageProcessUC";
            Size = new Size(589, 507);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Button btnSave;
        private CheckBox chkExposure;
        private CheckBox chkDefect;
        private CheckBox chkPerspective;
        private CheckBox chkImageRename;
        private CheckBox ImageFullScreen;
        private CheckBox chkSeverity;
        private CheckBox chkIsertImages;
        private ComboBox cmbRename;
        private TextBox txtExposureSet;
        private Label lblID;
        private Panel panel2;
        private Label lblProjectList;
        private CheckBox checkAll;
        private Label label9;
    }
}
