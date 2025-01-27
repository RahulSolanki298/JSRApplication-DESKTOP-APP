namespace LocalApplication
{
    partial class InspectionProcess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InspectionProcess));
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            btnNext = new Button();
            btnProcess = new Button();
            btnRecapture = new Button();
            btnBack = new Button();
            btnChangeStatus = new Button();
            pnlImage = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            label3 = new Label();
            lblOKCounter = new Label();
            label4 = new Label();
            lblDefCounter = new Label();
            label5 = new Label();
            lblWCCounter = new Label();
            txtModuleSerialNo = new TextBox();
            lblProcessId = new Label();
            txtModuleLocation = new TextBox();
            btnNextImage = new Button();
            picSetting = new PictureBox();
            panel1 = new Panel();
            lblImageName = new Label();
            panel2 = new Panel();
            _loader = new PictureBox();
            pnlSetting = new Panel();
            pnlModuleLocationFrm = new Panel();
            txtBlock = new TextBox();
            label8 = new Label();
            cmbPosition = new ComboBox();
            label9 = new Label();
            cmbEW = new ComboBox();
            label12 = new Label();
            label7 = new Label();
            label6 = new Label();
            label2 = new Label();
            cmbCurrentSTRValue = new ComboBox();
            cmbCurrentValue = new ComboBox();
            cmbINV_CB = new ComboBox();
            chkIsModuleLocation = new CheckBox();
            lblClose = new Label();
            lblID = new Label();
            txtModuleEnd = new TextBox();
            txtModuleStart = new TextBox();
            btnCancelLocation = new Button();
            btnSave = new Button();
            label1 = new Label();
            pnlStatusChange = new Panel();
            lblStatus = new Label();
            label20 = new Label();
            btnCancelStatus = new Button();
            UpdateStatus = new Button();
            comboBox1 = new ComboBox();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            lblProjectId = new Label();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            pnlImage.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picSetting).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_loader).BeginInit();
            pnlSetting.SuspendLayout();
            pnlModuleLocationFrm.SuspendLayout();
            pnlStatusChange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 2);
            tableLayoutPanel1.Controls.Add(pnlImage, 0, 0);
            tableLayoutPanel1.Controls.Add(panel2, 0, 1);
            tableLayoutPanel1.Location = new Point(0, 1);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 13.3623514F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 78.57833F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8.059316F));
            tableLayoutPanel1.Size = new Size(537, 562);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel3.ColumnCount = 5;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.3271027F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.2336445F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 29.4392529F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 84F));
            tableLayoutPanel3.Controls.Add(btnNext, 4, 0);
            tableLayoutPanel3.Controls.Add(btnProcess, 3, 0);
            tableLayoutPanel3.Controls.Add(btnRecapture, 1, 0);
            tableLayoutPanel3.Controls.Add(btnBack, 0, 0);
            tableLayoutPanel3.Controls.Add(btnChangeStatus, 2, 0);
            tableLayoutPanel3.Location = new Point(3, 519);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(531, 40);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // btnNext
            // 
            btnNext.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnNext.BackColor = Color.ForestGreen;
            btnNext.Cursor = Cursors.Hand;
            btnNext.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            btnNext.ForeColor = SystemColors.ControlLightLight;
            btnNext.Location = new Point(447, 3);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(81, 34);
            btnNext.TabIndex = 7;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Click += btnNext_Click;
            // 
            // btnProcess
            // 
            btnProcess.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnProcess.BackColor = Color.ForestGreen;
            btnProcess.Cursor = Cursors.Hand;
            btnProcess.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            btnProcess.ForeColor = SystemColors.ControlLightLight;
            btnProcess.Location = new Point(336, 3);
            btnProcess.Name = "btnProcess";
            btnProcess.Size = new Size(105, 34);
            btnProcess.TabIndex = 6;
            btnProcess.Text = "Process";
            btnProcess.UseVisualStyleBackColor = false;
            btnProcess.Click += btnProcess_Click;
            // 
            // btnRecapture
            // 
            btnRecapture.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnRecapture.BackColor = Color.ForestGreen;
            btnRecapture.Cursor = Cursors.Hand;
            btnRecapture.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            btnRecapture.ForeColor = SystemColors.ControlLightLight;
            btnRecapture.Location = new Point(93, 3);
            btnRecapture.Name = "btnRecapture";
            btnRecapture.Size = new Size(106, 34);
            btnRecapture.TabIndex = 4;
            btnRecapture.Text = "Recapture";
            btnRecapture.UseVisualStyleBackColor = false;
            btnRecapture.Click += btnRecapture_Click;
            // 
            // btnBack
            // 
            btnBack.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnBack.BackColor = Color.Red;
            btnBack.Cursor = Cursors.Hand;
            btnBack.ForeColor = SystemColors.ControlLightLight;
            btnBack.Location = new Point(3, 3);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(84, 34);
            btnBack.TabIndex = 8;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // btnChangeStatus
            // 
            btnChangeStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnChangeStatus.BackColor = Color.ForestGreen;
            btnChangeStatus.Cursor = Cursors.Hand;
            btnChangeStatus.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            btnChangeStatus.ForeColor = SystemColors.ControlLightLight;
            btnChangeStatus.Location = new Point(205, 3);
            btnChangeStatus.Name = "btnChangeStatus";
            btnChangeStatus.Size = new Size(125, 34);
            btnChangeStatus.TabIndex = 5;
            btnChangeStatus.Text = "Change Status";
            btnChangeStatus.UseVisualStyleBackColor = false;
            btnChangeStatus.Click += btnChangeStatus_Click;
            // 
            // pnlImage
            // 
            pnlImage.Controls.Add(tableLayoutPanel2);
            pnlImage.Dock = DockStyle.Fill;
            pnlImage.Location = new Point(3, 3);
            pnlImage.Name = "pnlImage";
            pnlImage.Size = new Size(531, 69);
            pnlImage.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 6;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.823183F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.3241653F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.1984282F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.8801575F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24.5579567F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.Controls.Add(label3, 0, 0);
            tableLayoutPanel2.Controls.Add(lblOKCounter, 0, 1);
            tableLayoutPanel2.Controls.Add(label4, 1, 0);
            tableLayoutPanel2.Controls.Add(lblDefCounter, 1, 1);
            tableLayoutPanel2.Controls.Add(label5, 2, 0);
            tableLayoutPanel2.Controls.Add(lblWCCounter, 2, 1);
            tableLayoutPanel2.Controls.Add(txtModuleSerialNo, 3, 1);
            tableLayoutPanel2.Controls.Add(lblProcessId, 3, 0);
            tableLayoutPanel2.Controls.Add(txtModuleLocation, 4, 1);
            tableLayoutPanel2.Controls.Add(btnNextImage, 5, 1);
            tableLayoutPanel2.Controls.Add(picSetting, 5, 0);
            tableLayoutPanel2.Controls.Add(panel1, 4, 0);
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 40.625F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 59.375F));
            tableLayoutPanel2.Size = new Size(525, 64);
            tableLayoutPanel2.TabIndex = 27;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(13, 6);
            label3.Name = "label3";
            label3.Size = new Size(24, 13);
            label3.TabIndex = 7;
            label3.Text = "OK";
            // 
            // lblOKCounter
            // 
            lblOKCounter.Anchor = AnchorStyles.None;
            lblOKCounter.AutoSize = true;
            lblOKCounter.Font = new Font("Microsoft Sans Serif", 8.25F);
            lblOKCounter.ForeColor = SystemColors.ActiveCaptionText;
            lblOKCounter.Location = new Point(19, 38);
            lblOKCounter.Name = "lblOKCounter";
            lblOKCounter.Size = new Size(13, 13);
            lblOKCounter.TabIndex = 10;
            lblOKCounter.Text = "0";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(60, 6);
            label4.Name = "label4";
            label4.Size = new Size(62, 13);
            label4.TabIndex = 8;
            label4.Text = "Defective";
            // 
            // lblDefCounter
            // 
            lblDefCounter.Anchor = AnchorStyles.None;
            lblDefCounter.AutoSize = true;
            lblDefCounter.Font = new Font("Microsoft Sans Serif", 8.25F);
            lblDefCounter.ForeColor = SystemColors.ActiveCaptionText;
            lblDefCounter.Location = new Point(84, 38);
            lblDefCounter.Name = "lblDefCounter";
            lblDefCounter.Size = new Size(13, 13);
            lblDefCounter.TabIndex = 11;
            lblDefCounter.Text = "0";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            label5.ForeColor = SystemColors.ActiveCaptionText;
            label5.Location = new Point(146, 6);
            label5.Name = "label5";
            label5.Size = new Size(27, 13);
            label5.TabIndex = 9;
            label5.Text = "WC";
            // 
            // lblWCCounter
            // 
            lblWCCounter.Anchor = AnchorStyles.None;
            lblWCCounter.AutoSize = true;
            lblWCCounter.Font = new Font("Microsoft Sans Serif", 8.25F);
            lblWCCounter.ForeColor = SystemColors.ActiveCaptionText;
            lblWCCounter.Location = new Point(153, 38);
            lblWCCounter.Name = "lblWCCounter";
            lblWCCounter.Size = new Size(13, 13);
            lblWCCounter.TabIndex = 12;
            lblWCCounter.Text = "0";
            // 
            // txtModuleSerialNo
            // 
            txtModuleSerialNo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtModuleSerialNo.Location = new Point(192, 33);
            txtModuleSerialNo.Name = "txtModuleSerialNo";
            txtModuleSerialNo.PlaceholderText = "Module Serial No";
            txtModuleSerialNo.Size = new Size(145, 23);
            txtModuleSerialNo.TabIndex = 1;
            // 
            // lblProcessId
            // 
            lblProcessId.AutoSize = true;
            lblProcessId.Location = new Point(192, 0);
            lblProcessId.Name = "lblProcessId";
            lblProcessId.Size = new Size(13, 15);
            lblProcessId.TabIndex = 14;
            lblProcessId.Text = "0";
            lblProcessId.Visible = false;
            // 
            // txtModuleLocation
            // 
            txtModuleLocation.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtModuleLocation.Location = new Point(343, 33);
            txtModuleLocation.Name = "txtModuleLocation";
            txtModuleLocation.PlaceholderText = "Module Location";
            txtModuleLocation.Size = new Size(123, 23);
            txtModuleLocation.TabIndex = 2;
            // 
            // btnNextImage
            // 
            btnNextImage.BackColor = Color.Navy;
            btnNextImage.Cursor = Cursors.Hand;
            btnNextImage.Font = new Font("Rockwell", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNextImage.ForeColor = SystemColors.ControlLight;
            btnNextImage.Location = new Point(472, 29);
            btnNextImage.Name = "btnNextImage";
            btnNextImage.Size = new Size(46, 32);
            btnNextImage.TabIndex = 3;
            btnNextImage.Text = "GO";
            btnNextImage.UseVisualStyleBackColor = false;
            btnNextImage.Click += btnNextImage_Click;
            // 
            // picSetting
            // 
            picSetting.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            picSetting.Cursor = Cursors.Hand;
            picSetting.Image = (Image)resources.GetObject("picSetting.Image");
            picSetting.Location = new Point(495, 3);
            picSetting.Name = "picSetting";
            picSetting.Size = new Size(27, 17);
            picSetting.SizeMode = PictureBoxSizeMode.StretchImage;
            picSetting.TabIndex = 15;
            picSetting.TabStop = false;
            picSetting.Click += picSetting_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblImageName);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(343, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(123, 20);
            panel1.TabIndex = 16;
            panel1.Visible = false;
            // 
            // lblImageName
            // 
            lblImageName.AutoSize = true;
            lblImageName.Location = new Point(31, 5);
            lblImageName.Name = "lblImageName";
            lblImageName.Size = new Size(0, 15);
            lblImageName.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(_loader);
            panel2.Controls.Add(pnlSetting);
            panel2.Controls.Add(pnlStatusChange);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(lblProjectId);
            panel2.Location = new Point(3, 78);
            panel2.Name = "panel2";
            panel2.Size = new Size(531, 435);
            panel2.TabIndex = 3;
            // 
            // _loader
            // 
            _loader.Anchor = AnchorStyles.None;
            _loader.Image = (Image)resources.GetObject("_loader.Image");
            _loader.Location = new Point(223, 176);
            _loader.Name = "_loader";
            _loader.Size = new Size(58, 61);
            _loader.SizeMode = PictureBoxSizeMode.StretchImage;
            _loader.TabIndex = 42;
            _loader.TabStop = false;
            _loader.Visible = false;
            // 
            // pnlSetting
            // 
            pnlSetting.Controls.Add(pnlModuleLocationFrm);
            pnlSetting.Controls.Add(chkIsModuleLocation);
            pnlSetting.Controls.Add(lblClose);
            pnlSetting.Controls.Add(lblID);
            pnlSetting.Controls.Add(txtModuleEnd);
            pnlSetting.Controls.Add(txtModuleStart);
            pnlSetting.Controls.Add(btnCancelLocation);
            pnlSetting.Controls.Add(btnSave);
            pnlSetting.Controls.Add(label1);
            pnlSetting.Location = new Point(258, 96);
            pnlSetting.Name = "pnlSetting";
            pnlSetting.Size = new Size(256, 327);
            pnlSetting.TabIndex = 27;
            // 
            // pnlModuleLocationFrm
            // 
            pnlModuleLocationFrm.BorderStyle = BorderStyle.FixedSingle;
            pnlModuleLocationFrm.Controls.Add(txtBlock);
            pnlModuleLocationFrm.Controls.Add(label8);
            pnlModuleLocationFrm.Controls.Add(cmbPosition);
            pnlModuleLocationFrm.Controls.Add(label9);
            pnlModuleLocationFrm.Controls.Add(cmbEW);
            pnlModuleLocationFrm.Controls.Add(label12);
            pnlModuleLocationFrm.Controls.Add(label7);
            pnlModuleLocationFrm.Controls.Add(label6);
            pnlModuleLocationFrm.Controls.Add(label2);
            pnlModuleLocationFrm.Controls.Add(cmbCurrentSTRValue);
            pnlModuleLocationFrm.Controls.Add(cmbCurrentValue);
            pnlModuleLocationFrm.Controls.Add(cmbINV_CB);
            pnlModuleLocationFrm.Location = new Point(15, 59);
            pnlModuleLocationFrm.Name = "pnlModuleLocationFrm";
            pnlModuleLocationFrm.Size = new Size(234, 227);
            pnlModuleLocationFrm.TabIndex = 54;
            // 
            // txtBlock
            // 
            txtBlock.Location = new Point(149, 197);
            txtBlock.Name = "txtBlock";
            txtBlock.Size = new Size(68, 23);
            txtBlock.TabIndex = 62;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Left;
            label8.AutoSize = true;
            label8.Location = new Point(15, 201);
            label8.Name = "label8";
            label8.Size = new Size(36, 15);
            label8.TabIndex = 61;
            label8.Text = "Block";
            // 
            // cmbPosition
            // 
            cmbPosition.FormattingEnabled = true;
            cmbPosition.Items.AddRange(new object[] { "Up", "Middle", "Down" });
            cmbPosition.Location = new Point(149, 164);
            cmbPosition.Name = "cmbPosition";
            cmbPosition.Size = new Size(68, 23);
            cmbPosition.TabIndex = 60;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Left;
            label9.AutoSize = true;
            label9.Location = new Point(13, 168);
            label9.Name = "label9";
            label9.Size = new Size(50, 15);
            label9.TabIndex = 59;
            label9.Text = "Position";
            // 
            // cmbEW
            // 
            cmbEW.FormattingEnabled = true;
            cmbEW.Items.AddRange(new object[] { "E", "W", "N", "S" });
            cmbEW.Location = new Point(149, 129);
            cmbEW.Name = "cmbEW";
            cmbEW.Size = new Size(68, 23);
            cmbEW.TabIndex = 58;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label12.AutoSize = true;
            label12.Location = new Point(11, 134);
            label12.Name = "label12";
            label12.Size = new Size(55, 15);
            label12.TabIndex = 57;
            label12.Text = "Direction";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 98);
            label7.Name = "label7";
            label7.Size = new Size(100, 15);
            label7.TabIndex = 56;
            label7.Text = "Current Value STR";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 54);
            label6.Name = "label6";
            label6.Size = new Size(124, 15);
            label6.TabIndex = 55;
            label6.Text = "Current Value INV | CB";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 15);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 54;
            label2.Text = "Inv | CB";
            // 
            // cmbCurrentSTRValue
            // 
            cmbCurrentSTRValue.FormattingEnabled = true;
            cmbCurrentSTRValue.Location = new Point(149, 91);
            cmbCurrentSTRValue.Name = "cmbCurrentSTRValue";
            cmbCurrentSTRValue.Size = new Size(68, 23);
            cmbCurrentSTRValue.TabIndex = 53;
            // 
            // cmbCurrentValue
            // 
            cmbCurrentValue.FormattingEnabled = true;
            cmbCurrentValue.Location = new Point(149, 49);
            cmbCurrentValue.Name = "cmbCurrentValue";
            cmbCurrentValue.Size = new Size(68, 23);
            cmbCurrentValue.TabIndex = 52;
            // 
            // cmbINV_CB
            // 
            cmbINV_CB.FormattingEnabled = true;
            cmbINV_CB.Items.AddRange(new object[] { "Inv", "CB" });
            cmbINV_CB.Location = new Point(149, 10);
            cmbINV_CB.Name = "cmbINV_CB";
            cmbINV_CB.Size = new Size(68, 23);
            cmbINV_CB.TabIndex = 51;
            // 
            // chkIsModuleLocation
            // 
            chkIsModuleLocation.AutoSize = true;
            chkIsModuleLocation.Location = new Point(18, 34);
            chkIsModuleLocation.Name = "chkIsModuleLocation";
            chkIsModuleLocation.Size = new Size(135, 19);
            chkIsModuleLocation.TabIndex = 53;
            chkIsModuleLocation.Text = "Set Module Location";
            chkIsModuleLocation.UseVisualStyleBackColor = true;
            chkIsModuleLocation.CheckedChanged += chkIsModuleLocation_CheckedChanged;
            // 
            // lblClose
            // 
            lblClose.AutoSize = true;
            lblClose.Cursor = Cursors.Hand;
            lblClose.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblClose.ForeColor = Color.Red;
            lblClose.Location = new Point(235, 7);
            lblClose.Name = "lblClose";
            lblClose.Size = new Size(15, 15);
            lblClose.TabIndex = 52;
            lblClose.Text = "X";
            lblClose.Click += lblClose_Click;
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.Location = new Point(4, 4);
            lblID.Name = "lblID";
            lblID.Size = new Size(13, 15);
            lblID.TabIndex = 51;
            lblID.Text = "0";
            lblID.Visible = false;
            // 
            // txtModuleEnd
            // 
            txtModuleEnd.Location = new Point(243, 273);
            txtModuleEnd.Name = "txtModuleEnd";
            txtModuleEnd.Size = new Size(10, 23);
            txtModuleEnd.TabIndex = 46;
            txtModuleEnd.Visible = false;
            // 
            // txtModuleStart
            // 
            txtModuleStart.Location = new Point(243, 245);
            txtModuleStart.Name = "txtModuleStart";
            txtModuleStart.Size = new Size(10, 23);
            txtModuleStart.TabIndex = 45;
            txtModuleStart.Visible = false;
            // 
            // btnCancelLocation
            // 
            btnCancelLocation.BackColor = Color.Red;
            btnCancelLocation.Cursor = Cursors.Hand;
            btnCancelLocation.FlatAppearance.BorderColor = Color.Red;
            btnCancelLocation.Font = new Font("Microsoft Sans Serif", 8.25F);
            btnCancelLocation.ForeColor = SystemColors.ControlLightLight;
            btnCancelLocation.Location = new Point(54, 292);
            btnCancelLocation.Name = "btnCancelLocation";
            btnCancelLocation.Size = new Size(83, 25);
            btnCancelLocation.TabIndex = 38;
            btnCancelLocation.Text = "Cancel";
            btnCancelLocation.UseVisualStyleBackColor = false;
            btnCancelLocation.Click += btnCancelLocation_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.DarkGreen;
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderColor = Color.Lime;
            btnSave.Font = new Font("Microsoft Sans Serif", 8.25F);
            btnSave.ForeColor = SystemColors.ControlLightLight;
            btnSave.Location = new Point(143, 292);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(93, 25);
            btnSave.TabIndex = 37;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(13, 7);
            label1.Name = "label1";
            label1.Size = new Size(183, 17);
            label1.TabIndex = 33;
            label1.Text = "Module Location Setting";
            // 
            // pnlStatusChange
            // 
            pnlStatusChange.Anchor = AnchorStyles.None;
            pnlStatusChange.BorderStyle = BorderStyle.FixedSingle;
            pnlStatusChange.Controls.Add(lblStatus);
            pnlStatusChange.Controls.Add(label20);
            pnlStatusChange.Controls.Add(btnCancelStatus);
            pnlStatusChange.Controls.Add(UpdateStatus);
            pnlStatusChange.Controls.Add(comboBox1);
            pnlStatusChange.Location = new Point(24, 315);
            pnlStatusChange.Name = "pnlStatusChange";
            pnlStatusChange.Size = new Size(165, 107);
            pnlStatusChange.TabIndex = 25;
            pnlStatusChange.Visible = false;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(132, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(13, 15);
            lblStatus.TabIndex = 33;
            lblStatus.Text = "0";
            lblStatus.Visible = false;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label20.Location = new Point(12, 12);
            label20.Name = "label20";
            label20.Size = new Size(114, 17);
            label20.TabIndex = 32;
            label20.Text = "Change Status";
            // 
            // btnCancelStatus
            // 
            btnCancelStatus.BackColor = Color.Red;
            btnCancelStatus.Cursor = Cursors.Hand;
            btnCancelStatus.FlatAppearance.BorderColor = Color.Red;
            btnCancelStatus.Font = new Font("Microsoft Sans Serif", 8.25F);
            btnCancelStatus.ForeColor = SystemColors.ControlLightLight;
            btnCancelStatus.Location = new Point(9, 64);
            btnCancelStatus.Name = "btnCancelStatus";
            btnCancelStatus.Size = new Size(61, 25);
            btnCancelStatus.TabIndex = 8;
            btnCancelStatus.Text = "Cancel";
            btnCancelStatus.UseVisualStyleBackColor = false;
            btnCancelStatus.Click += btnCancelStatus_Click;
            // 
            // UpdateStatus
            // 
            UpdateStatus.BackColor = Color.DarkGreen;
            UpdateStatus.Cursor = Cursors.Hand;
            UpdateStatus.FlatAppearance.BorderColor = Color.Lime;
            UpdateStatus.Font = new Font("Microsoft Sans Serif", 8.25F);
            UpdateStatus.ForeColor = SystemColors.ControlLightLight;
            UpdateStatus.Location = new Point(77, 64);
            UpdateStatus.Name = "UpdateStatus";
            UpdateStatus.Size = new Size(68, 25);
            UpdateStatus.TabIndex = 7;
            UpdateStatus.Text = "Update";
            UpdateStatus.UseVisualStyleBackColor = false;
            UpdateStatus.Click += UpdateStatus_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "OK", "Defective", "WithinCriteria", "Pending" });
            comboBox1.Location = new Point(14, 35);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(131, 23);
            comboBox1.TabIndex = 6;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.NBM_1786_Inv_02_Str_04_E_12_Up;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(531, 435);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.None;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(242, 198);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(49, 39);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 26;
            pictureBox2.TabStop = false;
            // 
            // lblProjectId
            // 
            lblProjectId.AutoSize = true;
            lblProjectId.Location = new Point(285, 33);
            lblProjectId.Name = "lblProjectId";
            lblProjectId.Size = new Size(13, 15);
            lblProjectId.TabIndex = 13;
            lblProjectId.Text = "0";
            lblProjectId.Visible = false;
            // 
            // InspectionProcess
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(535, 560);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            MinimumSize = new Size(535, 560);
            Name = "InspectionProcess";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "InspectionProcess";
            WindowState = FormWindowState.Maximized;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            pnlImage.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picSetting).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_loader).EndInit();
            pnlSetting.ResumeLayout(false);
            pnlSetting.PerformLayout();
            pnlModuleLocationFrm.ResumeLayout(false);
            pnlModuleLocationFrm.PerformLayout();
            pnlStatusChange.ResumeLayout(false);
            pnlStatusChange.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBox1;
        private Button btnRecapture;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel3;
        private Button btnNext;
        private Button btnProcess;
        private Button btnChangeStatus;
        private Panel pnlStatusChange;
        private Button btnCancelStatus;
        private Button UpdateStatus;
        private ComboBox comboBox1;
        private Label label20;
        private Label lblProjectId;
        private PictureBox pictureBox2;
        private Panel pnlSetting;
        private Label label1;
        private Button btnSave;
        private Button btnCancelLocation;
        private TextBox txtModuleEnd;
        private TextBox txtModuleStart;
        private Label lblID;
        private Label lblClose;
        private Button btnBack;
        private PictureBox _loader;
        private CheckBox chkIsModuleLocation;
        private Panel pnlModuleLocationFrm;
        private ComboBox cmbPosition;
        private Label label9;
        private ComboBox cmbEW;
        private Label label12;
        private Label label7;
        private Label label6;
        private Label label2;
        private ComboBox cmbCurrentSTRValue;
        private ComboBox cmbCurrentValue;
        private ComboBox cmbINV_CB;
        private Label lblStatus;
        private Panel pnlImage;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label4;
        private Label lblDefCounter;
        private Label label5;
        private Label lblWCCounter;
        private TextBox txtModuleSerialNo;
        private Label lblProcessId;
        private TextBox txtModuleLocation;
        private Button btnNextImage;
        private PictureBox picSetting;
        private Panel panel1;
        private Label lblImageName;
        private Label label3;
        private Label lblOKCounter;
        private TextBox txtBlock;
        private Label label8;
    }
}