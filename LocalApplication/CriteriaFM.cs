using LocalApplication.DTO;

namespace LocalApplication
{
    public partial class CriteriaFM : Form
    {
        CompanyEmployee _employee = new CompanyEmployee();
        private int ProjectId = 0;
        public CriteriaFM(CompanyEmployee employee, int? Pid = 0)
        {
            InitializeComponent();
            _employee = employee;
            btnProjectDetails.BackColor = Color.Orange;
            btnAcceptance.BackColor = Color.Navy;
            if (Pid > 0) { ProjectId = (int)Pid; lblCriteriaId.Text = Pid.ToString(); }
            getIntilize();
        }

        private void getIntilize()
        {
            CreateCriteriaUC productDetailsUC = new CreateCriteriaUC(_employee, ProjectId);
            productDetailsUC.IDChanged += ProductDetailsUC_IDChanged;
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
            btnProjectDetails.BackColor=Color.Orange;
            btnAcceptance.BackColor=Color.Navy;

            if (lblCriteriaId.Text != "0")
            {
                CreateCriteriaUC createCriteriaUC = new CreateCriteriaUC(_employee, Convert.ToInt32(lblCriteriaId.Text));
                showControl(createCriteriaUC);
            }
            else
            {
                CreateCriteriaUC createCriteriaUC = new CreateCriteriaUC(_employee);
                showControl(createCriteriaUC);
            }
        }

        private void ProductDetailsUC_IDChanged(object sender, int newId)
        {
            lblCriteriaId.Text = newId.ToString();
        }

        private void btnAcceptance_Click(object sender, EventArgs e)
        {
            btnProjectDetails.BackColor = Color.Navy;
            btnAcceptance.BackColor = Color.Orange;
            if (lblCriteriaId.Text != "0")
            {
                AcceptanceCriteria acc = new AcceptanceCriteria(Convert.ToInt32(lblCriteriaId.Text), _employee);
                showControl(acc);
            }
            else
            {
                MessageBox.Show("Please create project.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashboard = new Dashboard(_employee);
            dashboard.Show();
        }

        private void btnConfiguration_Click(object sender, EventArgs e)
        {
            ModuleConfiguration projectConfigure = new ModuleConfiguration(_employee, Convert.ToInt32(lblCriteriaId.Text));
            showControl(projectConfigure);
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
