using LocalApplication.DTO;

namespace LocalApplication
{
    public partial class ProjectGroup : UserControl
    {
        CompanyEmployee _employee = new CompanyEmployee();
        private int ProjectId = 0;
        public ProjectGroup(CompanyEmployee employee, int? Pid = 0)
        {
            InitializeComponent();
            _employee = employee;
            if (Pid > 0) { ProjectId = (int)Pid; lblProjectId.Text = Pid.ToString(); }
            btnProjectDetails_Click(null, null);
        }

        #region Project Details

        private void btnProjectDetails_Click(object sender, EventArgs e)
        {
            pnlBody.Controls.Clear();
            showPD();
        }

        private void showPD()
        {
            ProductDetailsUC productDetailsUC = new ProductDetailsUC(_employee, ProjectId);
            pnlBody.Controls.Add(productDetailsUC);
            productDetailsUC.IDChanged += ProductDetailsUC_IDChanged;
        }

        private void ProductDetailsUC_IDChanged(object sender, int newId)
        {
            lblProjectId.Text = newId.ToString();
        }

        #endregion

        #region Image Processing
        private void btnImgProcessing_Click(object sender, EventArgs e)
        {
            if (lblProjectId.Text != "0")
            {
                pnlBody.Controls.Clear();
                ImageProcessUC imageProcessUC = new ImageProcessUC(Convert.ToInt32(lblProjectId.Text), _employee);
                pnlBody.Controls.Add(imageProcessUC);
            }
            else
            {
                MessageBox.Show("Please create project.");
            }
        }
        #endregion

        #region Acceptance
        private void btnAcceptance_Click(object sender, EventArgs e)
        {
            if (lblProjectId.Text != "0")
            {
                pnlBody.Controls.Clear();
                AcceptanceCriteria acc = new AcceptanceCriteria(Convert.ToInt32(lblProjectId.Text), _employee);
                pnlBody.Controls.Add(acc);
            }
            else
            {
                MessageBox.Show("Please create project.");
            }
        }

        #endregion

        #region Text In Image
        private void btnTextInImage_Click(object sender, EventArgs e)
        {
            if (lblProjectId.Text != "0")
            {
                pnlBody.Controls.Clear();
                TextInImageUC txtImage = new TextInImageUC(Convert.ToInt32(lblProjectId.Text), _employee);
                pnlBody.Controls.Add(txtImage);
            }
            else
            {
                MessageBox.Show("Please create project.");
            }
        }

#endregion
    }
}
