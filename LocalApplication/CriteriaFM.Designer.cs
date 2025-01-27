namespace LocalApplication
{
    partial class CriteriaFM
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
            tableLayoutPanel2 = new TableLayoutPanel();
            btnProjectDetails = new Button();
            btnAcceptance = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            pnlBody = new Panel();
            lblCriteriaId = new Label();
            panel1 = new Panel();
            lblClose = new Label();
            label19 = new Label();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            pnlBody.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.BackColor = Color.WhiteSmoke;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31.8042812F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 68.19572F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Controls.Add(btnProjectDetails, 0, 0);
            tableLayoutPanel2.Controls.Add(btnAcceptance, 1, 0);
            tableLayoutPanel2.Location = new Point(2, 47);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(434, 38);
            tableLayoutPanel2.TabIndex = 9;
            // 
            // btnProjectDetails
            // 
            btnProjectDetails.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnProjectDetails.BackColor = Color.Navy;
            btnProjectDetails.Cursor = Cursors.Hand;
            btnProjectDetails.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            btnProjectDetails.ForeColor = SystemColors.ControlLightLight;
            btnProjectDetails.Location = new Point(0, 0);
            btnProjectDetails.Margin = new Padding(0);
            btnProjectDetails.Name = "btnProjectDetails";
            btnProjectDetails.Padding = new Padding(1);
            btnProjectDetails.Size = new Size(138, 38);
            btnProjectDetails.TabIndex = 4;
            btnProjectDetails.Text = "Criteria";
            btnProjectDetails.UseVisualStyleBackColor = false;
            btnProjectDetails.Click += btnProjectDetails_Click;
            // 
            // btnAcceptance
            // 
            btnAcceptance.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnAcceptance.BackColor = Color.Navy;
            btnAcceptance.Cursor = Cursors.Hand;
            btnAcceptance.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            btnAcceptance.ForeColor = SystemColors.ControlLightLight;
            btnAcceptance.Location = new Point(138, 0);
            btnAcceptance.Margin = new Padding(0);
            btnAcceptance.Name = "btnAcceptance";
            btnAcceptance.Padding = new Padding(1);
            btnAcceptance.Size = new Size(296, 36);
            btnAcceptance.TabIndex = 6;
            btnAcceptance.Text = "Acceptance Criteria";
            btnAcceptance.UseVisualStyleBackColor = false;
            btnAcceptance.Click += btnAcceptance_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.BackColor = Color.WhiteSmoke;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(pnlBody, 0, 0);
            tableLayoutPanel1.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanel1.Location = new Point(2, 91);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.742424F));
            tableLayoutPanel1.Size = new Size(633, 457);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // pnlBody
            // 
            pnlBody.AutoScroll = true;
            pnlBody.AutoSize = true;
            pnlBody.BorderStyle = BorderStyle.FixedSingle;
            pnlBody.Controls.Add(lblCriteriaId);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(3, 3);
            pnlBody.Name = "pnlBody";
            pnlBody.Size = new Size(627, 451);
            pnlBody.TabIndex = 1;
            // 
            // lblCriteriaId
            // 
            lblCriteriaId.AutoSize = true;
            lblCriteriaId.Location = new Point(7, 9);
            lblCriteriaId.Name = "lblCriteriaId";
            lblCriteriaId.Size = new Size(13, 15);
            lblCriteriaId.TabIndex = 0;
            lblCriteriaId.Text = "0";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.Navy;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(642, 13);
            panel1.TabIndex = 19;
            // 
            // lblClose
            // 
            lblClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblClose.Cursor = Cursors.Hand;
            lblClose.Font = new Font("Calibri", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblClose.ForeColor = Color.Red;
            lblClose.Location = new Point(611, 16);
            lblClose.Name = "lblClose";
            lblClose.Size = new Size(24, 26);
            lblClose.TabIndex = 21;
            lblClose.Text = "X";
            lblClose.Click += lblClose_Click;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Rockwell", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label19.ForeColor = SystemColors.GrayText;
            label19.Location = new Point(4, 14);
            label19.Name = "label19";
            label19.Size = new Size(318, 33);
            label19.TabIndex = 21;
            label19.Text = "Criteria && Sub Criteria";
            // 
            // CriteriaFM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(642, 560);
            Controls.Add(label19);
            Controls.Add(lblClose);
            Controls.Add(panel1);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            MinimumSize = new Size(535, 560);
            Name = "CriteriaFM";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Criteria Management";
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            pnlBody.ResumeLayout(false);
            pnlBody.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Button btnProjectDetails;
        private Button btnAcceptance;
        private Panel pnlBody;
        private Label lblCriteriaId;
        private Panel panel1;
        private Label lblClose;
        private Label label19;
    }
}