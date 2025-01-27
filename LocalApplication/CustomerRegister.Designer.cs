namespace LocalApplication
{
    partial class CustomerRegister
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
            CustomerBody = new Panel();
            label19 = new Label();
            lblClose = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            dgvCustomer = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            CustomerName = new DataGridViewTextBoxColumn();
            Activated = new DataGridViewCheckBoxColumn();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel3 = new Panel();
            label5 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            errCustomerName = new Label();
            txtCustomerName = new TextBox();
            label3 = new Label();
            txtAboutCustomer = new TextBox();
            label2 = new Label();
            chkIsActived = new CheckBox();
            lblID = new Label();
            btnSaveCustomer = new Button();
            panel1 = new Panel();
            CustomerBody.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomer).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // CustomerBody
            // 
            CustomerBody.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CustomerBody.Controls.Add(label19);
            CustomerBody.Controls.Add(lblClose);
            CustomerBody.Controls.Add(tableLayoutPanel2);
            CustomerBody.Controls.Add(tableLayoutPanel1);
            CustomerBody.Location = new Point(-5, 12);
            CustomerBody.Name = "CustomerBody";
            CustomerBody.Size = new Size(737, 485);
            CustomerBody.TabIndex = 2;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Rockwell", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label19.ForeColor = SystemColors.GrayText;
            label19.Location = new Point(7, 5);
            label19.Name = "label19";
            label19.Size = new Size(319, 33);
            label19.TabIndex = 22;
            label19.Text = "Customer Registration";
            // 
            // lblClose
            // 
            lblClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblClose.Cursor = Cursors.Hand;
            lblClose.Font = new Font("Calibri", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblClose.ForeColor = Color.Red;
            lblClose.Location = new Point(701, 5);
            lblClose.Name = "lblClose";
            lblClose.Size = new Size(24, 26);
            lblClose.TabIndex = 16;
            lblClose.Text = "X";
            lblClose.Click += lblClose_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(dgvCustomer, 0, 0);
            tableLayoutPanel2.Location = new Point(0, 199);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(736, 290);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // dgvCustomer
            // 
            dgvCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            dgvCustomer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dgvCustomer.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvCustomer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomer.Columns.AddRange(new DataGridViewColumn[] { Id, CustomerName, Activated });
            dgvCustomer.Location = new Point(26, 3);
            dgvCustomer.Name = "dgvCustomer";
            dgvCustomer.Size = new Size(684, 264);
            dgvCustomer.TabIndex = 0;
            dgvCustomer.CellMouseDoubleClick += dgvCustomer_CellClick;
            // 
            // Id
            // 
            Id.DataPropertyName = "Id";
            Id.HeaderText = "Id";
            Id.Name = "Id";
            Id.Width = 42;
            // 
            // CustomerName
            // 
            CustomerName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            CustomerName.DataPropertyName = "CustomerName";
            CustomerName.HeaderText = "Customer Name";
            CustomerName.Name = "CustomerName";
            // 
            // Activated
            // 
            Activated.DataPropertyName = "IsActive";
            Activated.HeaderText = "Activated";
            Activated.Name = "Activated";
            Activated.Resizable = DataGridViewTriState.True;
            Activated.SortMode = DataGridViewColumnSortMode.Automatic;
            Activated.Width = 82;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.8917465F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80.10825F));
            tableLayoutPanel1.Controls.Add(panel3, 0, 0);
            tableLayoutPanel1.Controls.Add(panel2, 1, 0);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(txtAboutCustomer, 1, 1);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(chkIsActived, 1, 2);
            tableLayoutPanel1.Controls.Add(btnSaveCustomer, 1, 3);
            tableLayoutPanel1.Location = new Point(72, 41);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 45.217392F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 54.782608F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.Size = new Size(586, 154);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel3.BackColor = SystemColors.Control;
            panel3.Controls.Add(label5);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(lblID);
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(110, 40);
            panel3.TabIndex = 4;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Location = new Point(4, 8);
            label5.Name = "label5";
            label5.Size = new Size(94, 15);
            label5.TabIndex = 9;
            label5.Text = "Customer Name";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.ForeColor = Color.OrangeRed;
            label1.Location = new Point(97, 11);
            label1.Name = "label1";
            label1.Size = new Size(12, 15);
            label1.TabIndex = 0;
            label1.Text = "*";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = SystemColors.Control;
            panel2.Controls.Add(errCustomerName);
            panel2.Controls.Add(txtCustomerName);
            panel2.Location = new Point(119, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(464, 40);
            panel2.TabIndex = 4;
            // 
            // errCustomerName
            // 
            errCustomerName.Anchor = AnchorStyles.None;
            errCustomerName.AutoSize = true;
            errCustomerName.ForeColor = Color.OrangeRed;
            errCustomerName.Location = new Point(3, 26);
            errCustomerName.Name = "errCustomerName";
            errCustomerName.Size = new Size(156, 15);
            errCustomerName.TabIndex = 10;
            errCustomerName.Text = "Please enter customer name";
            errCustomerName.Visible = false;
            // 
            // txtCustomerName
            // 
            txtCustomerName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtCustomerName.Location = new Point(0, 3);
            txtCustomerName.Multiline = true;
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(464, 23);
            txtCustomerName.TabIndex = 3;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Location = new Point(29, 104);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 5;
            label3.Text = "Activated";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtAboutCustomer
            // 
            txtAboutCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtAboutCustomer.Location = new Point(119, 49);
            txtAboutCustomer.Multiline = true;
            txtAboutCustomer.Name = "txtAboutCustomer";
            txtAboutCustomer.Size = new Size(464, 49);
            txtAboutCustomer.TabIndex = 4;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Location = new Point(10, 66);
            label2.Name = "label2";
            label2.Size = new Size(95, 15);
            label2.TabIndex = 1;
            label2.Text = "About Customer";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // chkIsActived
            // 
            chkIsActived.Anchor = AnchorStyles.None;
            chkIsActived.AutoSize = true;
            chkIsActived.Location = new Point(307, 104);
            chkIsActived.Name = "chkIsActived";
            chkIsActived.Size = new Size(87, 16);
            chkIsActived.TabIndex = 6;
            chkIsActived.Text = "Is Activated";
            chkIsActived.UseVisualStyleBackColor = true;
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.Location = new Point(26, 22);
            lblID.Name = "lblID";
            lblID.Size = new Size(13, 15);
            lblID.TabIndex = 8;
            lblID.Text = "0";
            lblID.Visible = false;
            // 
            // btnSaveCustomer
            // 
            btnSaveCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSaveCustomer.BackColor = Color.Navy;
            btnSaveCustomer.ForeColor = SystemColors.ControlLightLight;
            btnSaveCustomer.Location = new Point(458, 126);
            btnSaveCustomer.Name = "btnSaveCustomer";
            btnSaveCustomer.Size = new Size(125, 25);
            btnSaveCustomer.TabIndex = 7;
            btnSaveCustomer.Text = "Save ";
            btnSaveCustomer.UseVisualStyleBackColor = false;
            btnSaveCustomer.Click += btnSaveCustomer_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.Navy;
            panel1.Location = new Point(-5, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(737, 10);
            panel1.TabIndex = 3;
            // 
            // CustomerRegister
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(732, 504);
            Controls.Add(panel1);
            Controls.Add(CustomerBody);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CustomerRegister";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Customer Register";
            CustomerBody.ResumeLayout(false);
            CustomerBody.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCustomer).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel CustomerBody;
        private TableLayoutPanel tableLayoutPanel2;
        private DataGridView dgvCustomer;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label3;
        private TextBox txtAboutCustomer;
        private Label label1;
        private TextBox txtCustomerName;
        private Label label2;
        private CheckBox chkIsActived;
        private Button btnSaveCustomer;
        private Label lblID;
        private Label lblClose;
        private Panel panel1;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn CustomerName;
        private DataGridViewCheckBoxColumn Activated;
        private Label label19;
        private Panel panel2;
        private Label errCustomerName;
        private Label label5;
        private Panel panel3;
    }
}