namespace LocalApplication
{
    partial class Replicate
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
            panel8 = new Panel();
            btnImport = new Button();
            btnReplicate = new Button();
            label19 = new Label();
            panel1 = new Panel();
            lblClose = new Label();
            panel8.SuspendLayout();
            SuspendLayout();
            // 
            // panel8
            // 
            panel8.BackColor = Color.WhiteSmoke;
            panel8.BorderStyle = BorderStyle.FixedSingle;
            panel8.Controls.Add(btnImport);
            panel8.Controls.Add(btnReplicate);
            panel8.Controls.Add(label19);
            panel8.Controls.Add(panel1);
            panel8.Controls.Add(lblClose);
            panel8.Location = new Point(0, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(454, 240);
            panel8.TabIndex = 5;
            // 
            // btnImport
            // 
            btnImport.BackColor = Color.Navy;
            btnImport.ForeColor = SystemColors.ControlLight;
            btnImport.Location = new Point(229, 85);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(148, 55);
            btnImport.TabIndex = 26;
            btnImport.Text = "Import Data";
            btnImport.UseVisualStyleBackColor = false;
            btnImport.Click += btnImport_Click;
            // 
            // btnReplicate
            // 
            btnReplicate.BackColor = Color.Navy;
            btnReplicate.ForeColor = SystemColors.ControlLight;
            btnReplicate.Location = new Point(51, 85);
            btnReplicate.Name = "btnReplicate";
            btnReplicate.Size = new Size(155, 55);
            btnReplicate.TabIndex = 25;
            btnReplicate.Text = "Export Data";
            btnReplicate.UseVisualStyleBackColor = false;
            btnReplicate.Click += btnReplicate_Click;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Rockwell", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label19.ForeColor = SystemColors.GrayText;
            label19.Location = new Point(6, 16);
            label19.Name = "label19";
            label19.Size = new Size(143, 33);
            label19.TabIndex = 24;
            label19.Text = "Replicate";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.Navy;
            panel1.Location = new Point(-2, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(455, 10);
            panel1.TabIndex = 19;
            // 
            // lblClose
            // 
            lblClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblClose.Cursor = Cursors.Hand;
            lblClose.Font = new Font("Calibri", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblClose.ForeColor = Color.Red;
            lblClose.Location = new Point(420, 12);
            lblClose.Name = "lblClose";
            lblClose.Size = new Size(24, 26);
            lblClose.TabIndex = 18;
            lblClose.Text = "X";
            lblClose.Click += lblClose_Click;
            // 
            // Replicate
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(455, 241);
            Controls.Add(panel8);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Replicate";
            Text = "Replicate";
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel8;
        private Label lblClose;
        private Panel panel1;
        private Label label19;
        private Button btnReplicate;
        private Button btnImport;
    }
}