namespace LocalApplication
{
    partial class ProjectGroup
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
            tableLayoutPanel2 = new TableLayoutPanel();
            pnlBody = new Panel();
            lblProjectId = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnProjectDetails = new Button();
            btnAcceptance = new Button();
            btnTextInImage = new Button();
            btnImgProcessing = new Button();
            panel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            pnlBody.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(tableLayoutPanel2);
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(535, 560);
            panel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(pnlBody, 0, 0);
            tableLayoutPanel2.Location = new Point(2, 41);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(528, 519);
            tableLayoutPanel2.TabIndex = 9;
            // 
            // pnlBody
            // 
            pnlBody.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlBody.BackColor = Color.WhiteSmoke;
            pnlBody.BorderStyle = BorderStyle.FixedSingle;
            pnlBody.Controls.Add(lblProjectId);
            pnlBody.Location = new Point(3, 3);
            pnlBody.Name = "pnlBody";
            pnlBody.Size = new Size(522, 513);
            pnlBody.TabIndex = 1;
            // 
            // lblProjectId
            // 
            lblProjectId.AutoSize = true;
            lblProjectId.Location = new Point(13, 12);
            lblProjectId.Name = "lblProjectId";
            lblProjectId.Size = new Size(13, 15);
            lblProjectId.TabIndex = 1;
            lblProjectId.Text = "0";
            lblProjectId.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40.9894F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 59.0106F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 133F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 114F));
            tableLayoutPanel1.Controls.Add(btnProjectDetails, 0, 0);
            tableLayoutPanel1.Controls.Add(btnAcceptance, 2, 0);
            tableLayoutPanel1.Controls.Add(btnTextInImage, 3, 0);
            tableLayoutPanel1.Controls.Add(btnImgProcessing, 1, 0);
            tableLayoutPanel1.Location = new Point(0, 1);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(535, 37);
            tableLayoutPanel1.TabIndex = 8;
            // 
            // btnProjectDetails
            // 
            btnProjectDetails.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnProjectDetails.BackColor = Color.Navy;
            btnProjectDetails.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            btnProjectDetails.ForeColor = SystemColors.ControlLightLight;
            btnProjectDetails.Location = new Point(3, 3);
            btnProjectDetails.Name = "btnProjectDetails";
            btnProjectDetails.Size = new Size(112, 31);
            btnProjectDetails.TabIndex = 4;
            btnProjectDetails.Text = "Project Details";
            btnProjectDetails.UseVisualStyleBackColor = false;
            btnProjectDetails.Click += btnProjectDetails_Click;
            // 
            // btnAcceptance
            // 
            btnAcceptance.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnAcceptance.BackColor = Color.Navy;
            btnAcceptance.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            btnAcceptance.ForeColor = SystemColors.ControlLightLight;
            btnAcceptance.Location = new Point(290, 3);
            btnAcceptance.Name = "btnAcceptance";
            btnAcceptance.Size = new Size(127, 31);
            btnAcceptance.TabIndex = 6;
            btnAcceptance.Text = "Acceptance Criteria";
            btnAcceptance.UseVisualStyleBackColor = false;
            btnAcceptance.Click += btnAcceptance_Click;
            // 
            // btnTextInImage
            // 
            btnTextInImage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnTextInImage.BackColor = Color.Navy;
            btnTextInImage.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            btnTextInImage.ForeColor = SystemColors.ControlLightLight;
            btnTextInImage.Location = new Point(423, 3);
            btnTextInImage.Name = "btnTextInImage";
            btnTextInImage.Size = new Size(109, 31);
            btnTextInImage.TabIndex = 7;
            btnTextInImage.Text = "Text in image";
            btnTextInImage.UseVisualStyleBackColor = false;
            btnTextInImage.Click += btnTextInImage_Click;
            // 
            // btnImgProcessing
            // 
            btnImgProcessing.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnImgProcessing.BackColor = Color.Navy;
            btnImgProcessing.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            btnImgProcessing.ForeColor = SystemColors.ControlLightLight;
            btnImgProcessing.Location = new Point(121, 3);
            btnImgProcessing.Name = "btnImgProcessing";
            btnImgProcessing.Size = new Size(163, 31);
            btnImgProcessing.TabIndex = 5;
            btnImgProcessing.Text = "Processing Requirements ";
            btnImgProcessing.UseVisualStyleBackColor = false;
            btnImgProcessing.Click += btnImgProcessing_Click;
            // 
            // ProjectGroup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            MinimumSize = new Size(535, 560);
            Name = "ProjectGroup";
            Size = new Size(535, 560);
            panel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            pnlBody.ResumeLayout(false);
            pnlBody.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel pnlBody;
        private Label lblProjectId;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnProjectDetails;
        private Button btnAcceptance;
        private Button btnTextInImage;
        private Button btnImgProcessing;
    }
}
