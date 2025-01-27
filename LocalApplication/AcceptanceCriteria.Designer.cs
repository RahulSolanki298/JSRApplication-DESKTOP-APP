namespace LocalApplication
{
    partial class AcceptanceCriteria
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
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel2 = new Panel();
            gvAcceptance = new DataGridView();
            DefectType = new DataGridViewComboBoxColumn();
            UnitOfMeasurement = new DataGridViewComboBoxColumn();
            AcceptableMeasurement = new DataGridViewTextBoxColumn();
            QuantityAcceptable = new DataGridViewTextBoxColumn();
            Id = new DataGridViewTextBoxColumn();
            tableLayoutPanel3 = new TableLayoutPanel();
            panel4 = new Panel();
            btnSave = new Button();
            lblId = new Label();
            label6 = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            txtCriteriaBasket = new TextBox();
            lblKey = new Label();
            txtKey = new TextBox();
            label4 = new Label();
            txtCustomerName = new TextBox();
            label2 = new Label();
            cmbOption = new ComboBox();
            label3 = new Label();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvAcceptance).BeginInit();
            tableLayoutPanel3.SuspendLayout();
            panel4.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Controls.Add(tableLayoutPanel3);
            panel1.Controls.Add(tableLayoutPanel2);
            panel1.Dock = DockStyle.Fill;
            panel1.ForeColor = SystemColors.InfoText;
            panel1.Location = new Point(0, 0);
            panel1.MinimumSize = new Size(529, 507);
            panel1.Name = "panel1";
            panel1.Size = new Size(874, 600);
            panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(panel2, 0, 0);
            tableLayoutPanel1.Location = new Point(3, 145);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(871, 415);
            tableLayoutPanel1.TabIndex = 36;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(gvAcceptance);
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(865, 409);
            panel2.TabIndex = 0;
            // 
            // gvAcceptance
            // 
            gvAcceptance.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gvAcceptance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gvAcceptance.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            gvAcceptance.BorderStyle = BorderStyle.None;
            gvAcceptance.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
            gvAcceptance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvAcceptance.Columns.AddRange(new DataGridViewColumn[] { DefectType, UnitOfMeasurement, AcceptableMeasurement, QuantityAcceptable, Id });
            gvAcceptance.Location = new Point(3, 8);
            gvAcceptance.Name = "gvAcceptance";
            gvAcceptance.Size = new Size(856, 398);
            gvAcceptance.TabIndex = 9;
            // 
            // DefectType
            // 
            DefectType.DataPropertyName = "DefectTypeId";
            DefectType.HeaderText = "Defect Type";
            DefectType.Name = "DefectType";
            // 
            // UnitOfMeasurement
            // 
            UnitOfMeasurement.DataPropertyName = "UnitOfMeasurement";
            UnitOfMeasurement.HeaderText = "Unit of Measurement";
            UnitOfMeasurement.Items.AddRange(new object[] { "mm", "nos", "qty", "mm2" });
            UnitOfMeasurement.Name = "UnitOfMeasurement";
            // 
            // AcceptableMeasurement
            // 
            AcceptableMeasurement.DataPropertyName = "AcceptableMeasurement";
            AcceptableMeasurement.HeaderText = "Acceptable Measurement";
            AcceptableMeasurement.Name = "AcceptableMeasurement";
            // 
            // QuantityAcceptable
            // 
            QuantityAcceptable.DataPropertyName = "QuantityAcceptable";
            QuantityAcceptable.HeaderText = "Quantity Acceptable per module";
            QuantityAcceptable.Name = "QuantityAcceptable";
            // 
            // Id
            // 
            Id.DataPropertyName = "Id";
            Id.HeaderText = "Id";
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Visible = false;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel3.BackColor = Color.LimeGreen;
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 134F));
            tableLayoutPanel3.Controls.Add(btnSave, 1, 0);
            tableLayoutPanel3.Controls.Add(panel4, 0, 0);
            tableLayoutPanel3.Location = new Point(0, 1);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 51F));
            tableLayoutPanel3.Size = new Size(874, 48);
            tableLayoutPanel3.TabIndex = 35;
            // 
            // panel4
            // 
            panel4.Controls.Add(lblId);
            panel4.Controls.Add(label6);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(3, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(734, 42);
            panel4.TabIndex = 0;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSave.BackColor = Color.Navy;
            btnSave.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            btnSave.ForeColor = SystemColors.ControlLightLight;
            btnSave.Location = new Point(743, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(128, 42);
            btnSave.TabIndex = 14;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(428, 14);
            lblId.Name = "lblId";
            lblId.Size = new Size(13, 15);
            lblId.TabIndex = 13;
            lblId.Text = "0";
            lblId.Visible = false;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top;
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.HighlightText;
            label6.Location = new Point(6, 6);
            label6.Margin = new Padding(3, 10, 3, 0);
            label6.Name = "label6";
            label6.Size = new Size(193, 24);
            label6.TabIndex = 2;
            label6.Text = "Acceptance Criteria";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel2.Controls.Add(txtCriteriaBasket, 1, 0);
            tableLayoutPanel2.Controls.Add(lblKey, 2, 0);
            tableLayoutPanel2.Controls.Add(txtKey, 3, 0);
            tableLayoutPanel2.Controls.Add(label4, 0, 1);
            tableLayoutPanel2.Controls.Add(txtCustomerName, 1, 1);
            tableLayoutPanel2.Controls.Add(label2, 0, 0);
            tableLayoutPanel2.Controls.Add(cmbOption, 3, 1);
            tableLayoutPanel2.Controls.Add(label3, 2, 1);
            tableLayoutPanel2.Location = new Point(3, 55);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(871, 84);
            tableLayoutPanel2.TabIndex = 13;
            // 
            // txtCriteriaBasket
            // 
            txtCriteriaBasket.Location = new Point(177, 3);
            txtCriteriaBasket.Name = "txtCriteriaBasket";
            txtCriteriaBasket.Size = new Size(255, 23);
            txtCriteriaBasket.TabIndex = 5;
            // 
            // lblKey
            // 
            lblKey.AutoSize = true;
            lblKey.BackColor = Color.WhiteSmoke;
            lblKey.Font = new Font("Microsoft Sans Serif", 9F);
            lblKey.ForeColor = SystemColors.InfoText;
            lblKey.Location = new Point(438, 0);
            lblKey.Name = "lblKey";
            lblKey.Size = new Size(148, 15);
            lblKey.TabIndex = 4;
            lblKey.Text = "Sub Criteria Basket Name";
            // 
            // txtKey
            // 
            txtKey.Location = new Point(612, 3);
            txtKey.Name = "txtKey";
            txtKey.Size = new Size(256, 23);
            txtKey.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.WhiteSmoke;
            label4.Font = new Font("Microsoft Sans Serif", 9F);
            label4.ForeColor = SystemColors.InfoText;
            label4.Location = new Point(3, 42);
            label4.Name = "label4";
            label4.Size = new Size(97, 15);
            label4.TabIndex = 3;
            label4.Text = "Customer Name";
            label4.Visible = false;
            // 
            // txtCustomerName
            // 
            txtCustomerName.Location = new Point(177, 45);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(255, 23);
            txtCustomerName.TabIndex = 6;
            txtCustomerName.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.WhiteSmoke;
            label2.Font = new Font("Microsoft Sans Serif", 9F);
            label2.ForeColor = SystemColors.InfoText;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(123, 15);
            label2.TabIndex = 1;
            label2.Text = "Criteria Basket Name";
            // 
            // cmbOption
            // 
            cmbOption.FormattingEnabled = true;
            cmbOption.Items.AddRange(new object[] { "Manufacturer Name", "Site Name", "Factory Line" });
            cmbOption.Location = new Point(612, 45);
            cmbOption.Name = "cmbOption";
            cmbOption.Size = new Size(256, 23);
            cmbOption.TabIndex = 7;
            cmbOption.Visible = false;
            cmbOption.SelectedIndexChanged += cmbOption_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.WhiteSmoke;
            label3.Font = new Font("Microsoft Sans Serif", 9F);
            label3.ForeColor = SystemColors.InfoText;
            label3.Location = new Point(438, 42);
            label3.Name = "label3";
            label3.Size = new Size(80, 15);
            label3.TabIndex = 2;
            label3.Text = "Select Option";
            label3.Visible = false;
            // 
            // AcceptanceCriteria
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.GhostWhite;
            Controls.Add(panel1);
            Name = "AcceptanceCriteria";
            Size = new Size(874, 600);
            Load += AcceptanceCriteria_Load;
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gvAcceptance).EndInit();
            tableLayoutPanel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label3;
        private Label label2;
        private Label label4;
        private ComboBox cmbOption;
        private TextBox txtCustomerName;
        private TextBox txtCriteriaBasket;
        private TextBox txtKey;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel2;
        private Label lblKey;
        private Panel panel4;
        private Button btnSave;
        private Label lblId;
        private Label label6;
        private DataGridView gvAcceptance;
        private DataGridViewComboBoxColumn DefectType;
        private DataGridViewComboBoxColumn UnitOfMeasurement;
        private DataGridViewTextBoxColumn AcceptableMeasurement;
        private DataGridViewTextBoxColumn QuantityAcceptable;
        private DataGridViewTextBoxColumn Id;
    }
}
