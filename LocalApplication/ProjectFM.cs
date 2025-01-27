using LocalApplication.DTO;

namespace LocalApplication
{
    public partial class ProjectFM : Form
    {
        CompanyEmployee _employee = new CompanyEmployee();
        private int ProjectId = 0;
        public ProjectFM(CompanyEmployee employee, int? Pid = 0)
        {
            InitializeComponent();
            _employee = employee;
            if (Pid > 0) { ProjectId = (int)Pid; lblProjectId.Text = Pid.ToString(); }
            getIntilize();
        }

        private void getIntilize()
        {
            ProductDetailsUC productDetailsUC = new ProductDetailsUC(_employee, ProjectId);
            productDetailsUC.IDChanged += ProductDetailsUC_IDChanged;
            btnProjectDetails.BackColor = Color.Orange;
            showControl(productDetailsUC);
        }

        public void showControl(Control control)
        {
            pnlBody.Controls.Clear();

            control.Dock = DockStyle.Fill;
            control.BringToFront();
            control.Focus();

            pnlBody.Controls.Add(control);
        }

        private void btnProjectDetails_Click(object sender, EventArgs e)
        {
            btnProjectDetails.BackColor = Color.Orange;
            btnTextInImage.BackColor = Color.Navy;
            btnImgProcessing.BackColor = Color.Navy;
            btnConfiguration.BackColor = Color.Navy;

            if (lblProjectId.Text != "0")
            {
                ProductDetailsUC productDetailsUC = new ProductDetailsUC(_employee, ProjectId);
                showControl(productDetailsUC);
            }
            else
            {
                ProductDetailsUC productDetailsUC = new ProductDetailsUC(_employee, ProjectId);
                showControl(productDetailsUC);
            }
        }

        private void ProductDetailsUC_IDChanged(object sender, int newId)
        {
            lblProjectId.Text = newId.ToString();
        }

        private void btnImgProcessing_Click(object sender, EventArgs e)
        {
            

            if (lblProjectId.Text != "0")
            {
                ImageProcessUC imageProcessUC = new ImageProcessUC(Convert.ToInt32(lblProjectId.Text), _employee);
                showControl(imageProcessUC);

                btnProjectDetails.BackColor = Color.Navy;
                btnTextInImage.BackColor = Color.Navy;
                btnImgProcessing.BackColor = Color.Orange;
                btnConfiguration.BackColor = Color.Navy;
            }
            else
            {
                MessageBox.Show("Please create project.");
            }
        }

        private void btnTextInImage_Click(object sender, EventArgs e)
        {
            

            if (lblProjectId.Text != "0")
            {
                TextInImageUC txtImage = new TextInImageUC(Convert.ToInt32(lblProjectId.Text), _employee);
                showControl(txtImage);

                btnProjectDetails.BackColor = Color.Navy;
                btnTextInImage.BackColor = Color.Orange;
                btnImgProcessing.BackColor = Color.Navy;
                btnConfiguration.BackColor = Color.Navy;
            }
            else
            {
                MessageBox.Show("Please create project.");
            }
        }

        private void btnConfiguration_Click(object sender, EventArgs e)
        {
            

            if (lblProjectId.Text != "0")
            {
                ModuleConfiguration projectConfigure = new ModuleConfiguration(_employee, Convert.ToInt32(lblProjectId.Text));
                showControl(projectConfigure);

                btnProjectDetails.BackColor = Color.Navy;
                btnTextInImage.BackColor = Color.Navy;
                btnImgProcessing.BackColor = Color.Navy;
                btnConfiguration.BackColor = Color.Orange;
            }
            else
            {
                MessageBox.Show("Please create project.");
            }
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
