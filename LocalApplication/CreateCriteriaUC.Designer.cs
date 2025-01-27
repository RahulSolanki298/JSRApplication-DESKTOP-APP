namespace LocalApplication
{
    partial class CreateCriteriaUC
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
            lblID = new Label();
            btnSave = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel2 = new Panel();
            label4 = new Label();
            errCriteriaBasket = new Label();
            dgvCustomer = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Name = new DataGridViewTextBoxColumn();
            txtBasketName = new TextBox();
            label2 = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel1 = new Panel();
            btnClear = new Button();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomer).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(3, 7);
            label1.Name = "label1";
            label1.Size = new Size(168, 25);
            label1.TabIndex = 1;
            label1.Text = "Criteria Basket";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblID
            // 
            lblID.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblID.AutoSize = true;
            lblID.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            lblID.ForeColor = SystemColors.ControlText;
            lblID.Location = new Point(188, 10);
            lblID.Name = "lblID";
            lblID.Size = new Size(15, 16);
            lblID.TabIndex = 18;
            lblID.Text = "0";
            lblID.Visible = false;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSave.BackColor = Color.Navy;
            btnSave.Cursor = Cursors.Hand;
            btnSave.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = SystemColors.ControlLightLight;
            btnSave.Location = new Point(307, -3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(110, 41);
            btnSave.TabIndex = 19;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 73.83178F));
            tableLayoutPanel1.Controls.Add(panel2, 0, 0);
            tableLayoutPanel1.Location = new Point(0, 50);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(535, 497);
            tableLayoutPanel1.TabIndex = 20;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(label4);
            panel2.Controls.Add(errCriteriaBasket);
            panel2.Controls.Add(dgvCustomer);
            panel2.Controls.Add(txtBasketName);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(529, 491);
            panel2.TabIndex = 1;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            label4.ForeColor = Color.OrangeRed;
            label4.Location = new Point(165, 12);
            label4.Name = "label4";
            label4.Size = new Size(13, 16);
            label4.TabIndex = 23;
            label4.Text = "*";
            label4.Visible = false;
            // 
            // errCriteriaBasket
            // 
            errCriteriaBasket.AutoSize = true;
            errCriteriaBasket.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            errCriteriaBasket.ForeColor = Color.OrangeRed;
            errCriteriaBasket.Location = new Point(178, 10);
            errCriteriaBasket.Name = "errCriteriaBasket";
            errCriteriaBasket.Size = new Size(205, 16);
            errCriteriaBasket.TabIndex = 22;
            errCriteriaBasket.Text = "Criteria basket already exist.";
            errCriteriaBasket.TextAlign = ContentAlignment.MiddleCenter;
            errCriteriaBasket.Visible = false;
            // 
            // dgvCustomer
            // 
            dgvCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCustomer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dgvCustomer.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvCustomer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomer.Columns.AddRange(new DataGridViewColumn[] { Id, Name });
            dgvCustomer.Location = new Point(17, 62);
            dgvCustomer.Name = "dgvCustomer";
            dgvCustomer.Size = new Size(495, 409);
            dgvCustomer.TabIndex = 21;
            dgvCustomer.CellClick += dgvCustomer_CellClick;
            // 
            // Id
            // 
            Id.DataPropertyName = "Id";
            Id.HeaderText = "Id";
            Id.Name = "Id";
            Id.Width = 42;
            // 
            // Name
            // 
            Name.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Name.DataPropertyName = "Name";
            Name.HeaderText = "Criteria Basket Name";
            Name.Name = "Name";
            // 
            // txtBasketName
            // 
            txtBasketName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtBasketName.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtBasketName.Location = new Point(156, 30);
            txtBasketName.Margin = new Padding(4, 3, 4, 3);
            txtBasketName.Name = "txtBasketName";
            txtBasketName.Size = new Size(356, 20);
            txtBasketName.TabIndex = 19;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 32);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(123, 15);
            label2.TabIndex = 20;
            label2.Text = "Criteria Basket Name :";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(panel1, 0, 0);
            tableLayoutPanel2.Location = new Point(0, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(535, 44);
            tableLayoutPanel2.TabIndex = 21;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.Lime;
            panel1.Controls.Add(btnClear);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(lblID);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(529, 38);
            panel1.TabIndex = 0;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClear.BackColor = Color.Navy;
            btnClear.Cursor = Cursors.Hand;
            btnClear.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.ForeColor = SystemColors.ControlLightLight;
            btnClear.Location = new Point(422, -3);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(110, 41);
            btnClear.TabIndex = 20;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // CreateCriteriaUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(tableLayoutPanel2);
            Controls.Add(tableLayoutPanel1);
            MinimumSize = new Size(535, 560);
            Size = new Size(535, 560);
            tableLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomer).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private CheckBox chkCustomer;
        private Label lblID;
        private Button btnSave;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel1;
        private TextBox txtBasketName;
        private Label label2;
        private DataGridView dgvCustomer;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Name;
        private Label label4;
        private Label errCriteriaBasket;
        private Button btnClear;
        //private CheckBox chkCustomer;
    }
}
