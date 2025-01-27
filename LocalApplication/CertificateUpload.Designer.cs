namespace LocalApplication
{
    partial class CertificateUpload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CertificateUpload));
            lblFileUpload = new Label();
            openFileDialog1 = new OpenFileDialog();
            txtCertificate = new TextBox();
            btnFileUpload = new Button();
            btnLogin = new Button();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            lblBulkClose = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblFileUpload
            // 
            lblFileUpload.AutoSize = true;
            lblFileUpload.Location = new Point(167, 231);
            lblFileUpload.Name = "lblFileUpload";
            lblFileUpload.Size = new Size(66, 15);
            lblFileUpload.TabIndex = 0;
            lblFileUpload.Text = "File Upload";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtCertificate
            // 
            txtCertificate.Location = new Point(247, 228);
            txtCertificate.Name = "txtCertificate";
            txtCertificate.Size = new Size(251, 23);
            txtCertificate.TabIndex = 1;
            // 
            // btnFileUpload
            // 
            btnFileUpload.Cursor = Cursors.Hand;
            btnFileUpload.Location = new Point(504, 228);
            btnFileUpload.Name = "btnFileUpload";
            btnFileUpload.Size = new Size(75, 24);
            btnFileUpload.TabIndex = 2;
            btnFileUpload.Text = "Upload";
            btnFileUpload.UseVisualStyleBackColor = true;
            btnFileUpload.Click += btnFileUpload_Click;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.MediumSeaGreen;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = SystemColors.ControlLightLight;
            btnLogin.Location = new Point(537, 377);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(251, 50);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Log In";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Visible = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.Navy;
            panel1.Location = new Point(-2, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(803, 12);
            panel1.TabIndex = 34;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 18);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(237, 69);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Navy;
            label1.Location = new Point(188, 135);
            label1.Name = "label1";
            label1.Size = new Size(395, 24);
            label1.TabIndex = 35;
            label1.Text = "Welcome to JSR Renewable Consultants ";
            // 
            // lblBulkClose
            // 
            lblBulkClose.AutoSize = true;
            lblBulkClose.Cursor = Cursors.Hand;
            lblBulkClose.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblBulkClose.ForeColor = Color.Red;
            lblBulkClose.Location = new Point(764, 18);
            lblBulkClose.Name = "lblBulkClose";
            lblBulkClose.Size = new Size(24, 25);
            lblBulkClose.TabIndex = 36;
            lblBulkClose.Text = "X";
            lblBulkClose.Click += lblBulkClose_Click;
            // 
            // CertificateUpload
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblBulkClose);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Controls.Add(btnLogin);
            Controls.Add(btnFileUpload);
            Controls.Add(txtCertificate);
            Controls.Add(lblFileUpload);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CertificateUpload";
            Text = "CertificateUpload";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFileUpload;
        private OpenFileDialog openFileDialog1;
        private TextBox txtCertificate;
        private Button btnFileUpload;
        private Button btnLogin;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label1;
        private Label lblBulkClose;
    }
}