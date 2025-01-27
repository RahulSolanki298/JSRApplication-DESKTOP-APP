namespace LocalApplication
{
    partial class _Loader
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
            components = new System.ComponentModel.Container();
            label4 = new Label();
            lblCounter = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            progressBar1 = new ProgressBar();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.DarkCyan;
            label4.Font = new Font("Rockwell Extra Bold", 14F);
            label4.ForeColor = SystemColors.InfoText;
            label4.Location = new Point(48, 40);
            label4.Name = "label4";
            label4.Size = new Size(128, 22);
            label4.TabIndex = 4;
            label4.Text = "Loading...";
            // 
            // lblCounter
            // 
            lblCounter.AutoSize = true;
            lblCounter.BackColor = Color.DarkCyan;
            lblCounter.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCounter.ForeColor = SystemColors.InfoText;
            lblCounter.Location = new Point(90, 94);
            lblCounter.Name = "lblCounter";
            lblCounter.Size = new Size(15, 16);
            lblCounter.TabIndex = 5;
            lblCounter.Text = "0";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // progressBar1
            // 
            progressBar1.ForeColor = SystemColors.ControlDarkDark;
            progressBar1.Location = new Point(0, 125);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(222, 17);
            progressBar1.TabIndex = 6;
            // 
            // _Loader
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkCyan;
            ClientSize = new Size(222, 142);
            Controls.Add(progressBar1);
            Controls.Add(lblCounter);
            Controls.Add(label4);
            FormBorderStyle = FormBorderStyle.None;
            Name = "_Loader";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "_Loader";
            Load += _Loader_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private Label lblCounter;
        private System.Windows.Forms.Timer timer1;
        private ProgressBar progressBar1;
    }
}