namespace LocalApplication
{
    partial class ImportData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportData));
            bntUpload = new Button();
            btnImport = new Button();
            lblClose = new Label();
            _loader = new PictureBox();
            panel2 = new Panel();
            label19 = new Label();
            dtGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)_loader).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtGridView).BeginInit();
            SuspendLayout();
            // 
            // bntUpload
            // 
            bntUpload.BackColor = Color.Navy;
            bntUpload.Font = new Font("Rockwell", 9F, FontStyle.Bold);
            bntUpload.ForeColor = SystemColors.ControlLightLight;
            bntUpload.Location = new Point(136, 59);
            bntUpload.Name = "bntUpload";
            bntUpload.Size = new Size(127, 30);
            bntUpload.TabIndex = 30;
            bntUpload.Text = "Upload Data";
            bntUpload.UseVisualStyleBackColor = false;
            bntUpload.Click += bntUpload_Click;
            // 
            // btnImport
            // 
            btnImport.BackColor = Color.Navy;
            btnImport.Font = new Font("Rockwell", 9F, FontStyle.Bold);
            btnImport.ForeColor = SystemColors.ControlLightLight;
            btnImport.Location = new Point(10, 59);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(120, 30);
            btnImport.TabIndex = 32;
            btnImport.Text = "Import Data";
            btnImport.UseVisualStyleBackColor = false;
            btnImport.Click += btnImport_Click;
            // 
            // lblClose
            // 
            lblClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblClose.Cursor = Cursors.Hand;
            lblClose.Font = new Font("Calibri", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblClose.ForeColor = Color.Red;
            lblClose.Location = new Point(678, 9);
            lblClose.Name = "lblClose";
            lblClose.Size = new Size(24, 26);
            lblClose.TabIndex = 33;
            lblClose.Text = "X";
            lblClose.Click += lblClose_Click;
            // 
            // _loader
            // 
            _loader.Image = (Image)resources.GetObject("_loader.Image");
            _loader.Location = new Point(270, 59);
            _loader.Name = "_loader";
            _loader.Size = new Size(40, 30);
            _loader.SizeMode = PictureBoxSizeMode.StretchImage;
            _loader.TabIndex = 42;
            _loader.TabStop = false;
            _loader.Visible = false;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.Navy;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(714, 10);
            panel2.TabIndex = 43;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Rockwell", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label19.ForeColor = SystemColors.GrayText;
            label19.Location = new Point(10, 17);
            label19.Name = "label19";
            label19.Size = new Size(143, 33);
            label19.TabIndex = 44;
            label19.Text = "Replicate";
            // 
            // dtGridView
            // 
            dtGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dtGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtGridView.Location = new Point(10, 95);
            dtGridView.Name = "dtGridView";
            dtGridView.Size = new Size(692, 346);
            dtGridView.TabIndex = 45;
            // 
            // ImportData
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(714, 453);
            Controls.Add(dtGridView);
            Controls.Add(label19);
            Controls.Add(panel2);
            Controls.Add(_loader);
            Controls.Add(lblClose);
            Controls.Add(btnImport);
            Controls.Add(bntUpload);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ImportData";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Import Data ";
            ((System.ComponentModel.ISupportInitialize)_loader).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button bntUpload;
        private Button btnImport;
        private Label lblClose;
        private PictureBox _loader;
        private Panel panel2;
        private Label label19;
        private DataGridView dtGridView;
    }
}