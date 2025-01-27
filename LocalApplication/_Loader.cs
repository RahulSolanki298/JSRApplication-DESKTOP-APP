using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocalApplication
{
    public partial class _Loader : Form
    {
        public _Loader()
        {
            InitializeComponent();
        }

        private void _Loader_Load(object sender, EventArgs e)
        {
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value += 1;
                lblCounter.Text=progressBar1.Value.ToString() + "%";
            }
            else
            {
                timer1.Stop();
                this.Close();
            }
        }
    }
}
