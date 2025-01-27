using LocalApplication.DTO;
using LocalApplication.Helpers;
using System.Data;
using System.Data.SqlClient;

namespace LocalApplication
{
    public partial class AcceptanceCriteria : UserControl
    {
        DBHelper DBHelper = new DBHelper();
        private int projectId = 0;
        CompanyEmployee _employee = new CompanyEmployee();

        public AcceptanceCriteria(int PId, CompanyEmployee employee)
        {
            InitializeComponent();
            _employee = employee;
            projectId = PId;
            gvAcceptance.AutoGenerateColumns = false;

            if (projectId > 0)
            {
                getAccepanceMainData();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var result = AddAcceptanceCriteria();
            if (result == true)
            {
                MessageBox.Show("Acceptance criteria added successfully.");
            }
            else
            {
                MessageBox.Show("Please enter all fields.");
            }
        }
            
        private void BindDefectType()
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                try
                {
                    var qry = $"select Id,Value from DefectType where SoftwareId={_employee.SoftwareId}";
                    SqlCommand cmd = new SqlCommand(qry, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataGridViewRow row in gvAcceptance.Rows)
                    {
                        var comboBoxCell = (DataGridViewComboBoxCell)row.Cells["DefectType"];
                        comboBoxCell.DisplayMember = "Value";
                        comboBoxCell.ValueMember = "Id";
                        comboBoxCell.DataSource = dt;
                    }

                }
                catch (Exception)
                {

                }
            }
        }

        private void AcceptanceCriteria_Load(object sender, EventArgs e)
        {
            BindDefectType();
        }

        private bool AddAcceptanceCriteria()
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                SqlTransaction transaction = null;

                try
                {
                    transaction = connection.BeginTransaction();

                    // Insert or update project
                    foreach (DataGridViewRow row in gvAcceptance.Rows)
                    {
                        if (row.IsNewRow)
                            continue;

                        string DefectType = row.Cells["DefectType"].Value.ToString();
                        string UnitOfMeasurement = row.Cells["UnitOfMeasurement"].Value.ToString();
                        string QuantityAcceptable = row.Cells["QuantityAcceptable"].Value.ToString();
                        string AcceptableMeasurement = row.Cells["AcceptableMeasurement"].Value.ToString();

                        if (String.IsNullOrEmpty(DefectType) == true || 
                            String.IsNullOrEmpty(UnitOfMeasurement) == true || 
                            String.IsNullOrEmpty(QuantityAcceptable) == true || 
                            String.IsNullOrEmpty(AcceptableMeasurement) == true)
                        {
                            return false;
                        }

                        if (!double.TryParse(QuantityAcceptable, out _))
                        {
                            MessageBox.Show("Quantity Acceptable must be numeric values.");
                            return false;
                        }
                    }

                    int accId;
                    accId = Convert.ToInt32(lblId.Text);

                    if (accId > 0)
                    {
                        using (var cmdUpdate = new SqlCommand("UPDATE AcceptanceCriteriaMain SET BasketName=@BasketName,AcceptanceOptions=@AcceptanceOptions, CriteriaBasketId=@CriteriaBasketId WHERE Id=@Id", connection, transaction))
                        {
                            cmdUpdate.Parameters.AddWithValue("@BasketName", txtKey.Text);
                            cmdUpdate.Parameters.AddWithValue("@AcceptanceOptions", "Factory Line");
                            cmdUpdate.Parameters.AddWithValue("@CriteriaBasketId", projectId);
                            cmdUpdate.Parameters.AddWithValue("@Id", accId);
                            cmdUpdate.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        using (var cmdInsert = new SqlCommand("INSERT INTO AcceptanceCriteriaMain (BasketName, AcceptanceOptions, CriteriaBasketId,SoftwareId) VALUES (@BasketName, @AcceptanceOptions, @CriteriaBasketId,@SoftwareId); SELECT SCOPE_IDENTITY();", connection, transaction))
                        {
                            cmdInsert.Parameters.AddWithValue("@BasketName", txtKey.Text);
                            cmdInsert.Parameters.AddWithValue("@AcceptanceOptions", "Factory Line");
                            cmdInsert.Parameters.AddWithValue("@CriteriaBasketId", projectId);
                            cmdInsert.Parameters.AddWithValue("@SoftwareId", _employee.SoftwareId);
                            accId = Convert.ToInt32(cmdInsert.ExecuteScalar());
                            lblId.Text = accId.ToString();
                        }
                    }

                    gvAcceptance.Visible = true;

                    // Insert or update project
                    foreach (DataGridViewRow row in gvAcceptance.Rows)
                    {
                        if (row.IsNewRow)
                            continue;

                        string DefectType = row.Cells["DefectType"].Value.ToString();
                        string UnitOfMeasurement = row.Cells["UnitOfMeasurement"].Value.ToString();
                        string QuantityAcceptable = row.Cells["QuantityAcceptable"].Value.ToString();
                        string AcceptableMeasurement = row.Cells["AcceptableMeasurement"].Value.ToString();

                        var Id = "0";
                        try
                        {
                            Id = String.IsNullOrEmpty(row.Cells["Id"].Value?.ToString()) ? "0" : row.Cells["Id"].Value.ToString();
                        }
                        catch (Exception ex)
                        {
                            Id = "0";
                        }

                        if (Convert.ToInt32(Id) > 0)
                        {
                            using (var cmdUpdateProject = new SqlCommand("UPDATE AcceptanceCriteria SET DefectTypeId=@DefectTypeId, UnitOfMeasurement=@UnitOfMeasurement, AcceptableMeasurement=@AcceptableMeasurement, QuantityAcceptable=@QuantityAcceptable, FactoryLineId=@FactoryLineId WHERE Id=@Id", connection, transaction))
                            {
                                cmdUpdateProject.Parameters.AddWithValue("@DefectTypeId", Convert.ToInt32(DefectType));
                                cmdUpdateProject.Parameters.AddWithValue("@UnitOfMeasurement", UnitOfMeasurement);
                                cmdUpdateProject.Parameters.AddWithValue("@AcceptableMeasurement", AcceptableMeasurement);
                                cmdUpdateProject.Parameters.AddWithValue("@QuantityAcceptable", QuantityAcceptable);
                                cmdUpdateProject.Parameters.AddWithValue("@FactoryLineId", accId);
                                cmdUpdateProject.Parameters.AddWithValue("@Id", Convert.ToInt32(row.Cells["Id"].Value));
                                cmdUpdateProject.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            using (var cmdInsertProject = new SqlCommand("INSERT INTO AcceptanceCriteria (DefectTypeId,  UnitOfMeasurement, AcceptableMeasurement, QuantityAcceptable, FactoryLineId) VALUES (@DefectTypeId, @UnitOfMeasurement, @AcceptableMeasurement, @QuantityAcceptable, @FactoryLineId); SELECT SCOPE_IDENTITY();", connection, transaction))
                            {
                                cmdInsertProject.Parameters.AddWithValue("@DefectTypeId", Convert.ToInt32(DefectType));
                                cmdInsertProject.Parameters.AddWithValue("@UnitOfMeasurement", UnitOfMeasurement);
                                cmdInsertProject.Parameters.AddWithValue("@AcceptableMeasurement", AcceptableMeasurement);
                                cmdInsertProject.Parameters.AddWithValue("@QuantityAcceptable", QuantityAcceptable);
                                cmdInsertProject.Parameters.AddWithValue("@FactoryLineId", accId);
                                cmdInsertProject.ExecuteScalar();
                            }
                        }
                    }

                    transaction.Commit();
                    getAccepanceMainData();
                    return true;
                }
                catch (Exception)
                {
                    transaction?.Rollback();
                    return false;
                }
            }
        }

        private void cmbOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOption.SelectedIndex == 0)
            {
                lblKey.Visible = true;
                txtKey.Visible = true;
                lblKey.Text = "Manufacturer Name :";
                gvAcceptance.Visible = false;
            }
            else if (cmbOption.SelectedIndex == 1)
            {
                lblKey.Visible = true;
                txtKey.Visible = true;
                lblKey.Text = "Site Name :";
                gvAcceptance.Visible = false;
            }
            else if (cmbOption.SelectedIndex == 2)
            {
                lblKey.Visible = false;
                txtKey.Visible = false;
                gvAcceptance.Visible = true;
            }
        }

        private void getAccepanceMainData()
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                try
                {
                    var qry = $"select * from CriteriaBasket where Id={projectId}";
                    SqlCommand cmd = new SqlCommand(qry, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        txtCriteriaBasket.Text = dt.Rows[0]["Name"].ToString();
                        GetAccepanceData();
                    }

                }
                catch (Exception)
                {

                }
            }
        }

        private void GetAccepanceData()
        {
            using (var connection = DBHelper.GetConnection())
            {

                // Bind dynamic ComboBox column
                DataGridViewComboBoxColumn dynamicComboBoxColumn = (DataGridViewComboBoxColumn)gvAcceptance.Columns["DefectType"];
                dynamicComboBoxColumn.DataSource = GetDefectType();
                dynamicComboBoxColumn.DisplayMember = "Value";
                dynamicComboBoxColumn.ValueMember = "Id";

                // Bind static ComboBox column
                DataGridViewComboBoxColumn staticComboBoxColumn = (DataGridViewComboBoxColumn)gvAcceptance.Columns["UnitOfMeasurement"];
                staticComboBoxColumn.DataSource = GetTableNames(); // Replace GetStaticComboBoxData with your method to get the static data
                staticComboBoxColumn.DisplayMember = "UnitOfMeasurement";
                staticComboBoxColumn.ValueMember = "UnitOfMeasurement";

                connection.Open();
                int facId = Convert.ToInt32(lblId.Text);
                var qry = $"select * from AcceptanceCriteria where FactoryLineId={facId}";
                SqlCommand cmd = new SqlCommand(qry, connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvAcceptance.DataSource = dt;

                gvAcceptance.Visible = true;

                connection.Close();
            }
        }

        private DataTable GetDefectType()
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();

                try
                {
                    var qry = $"select Id,Value from DefectType where SoftwareId={_employee.SoftwareId}";
                    SqlCommand cmd = new SqlCommand(qry, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    return dt;

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null; 
                }
            }
        }

        private DataTable GetTableNames()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("UnitOfMeasurement");

            DataRow row = dt.NewRow();
            row["UnitOfMeasurement"] = "mm";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["UnitOfMeasurement"] = "nos";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["UnitOfMeasurement"] = "qty";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["UnitOfMeasurement"] = "mm2";
            dt.Rows.Add(row);

            return dt;
        }

        private DataTable GetOptionNames()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Option");

            DataRow row = dt.NewRow();
            row["Option"] = "Manufacturer Name";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Option"] = "Site Name";
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["Option"] = "Factory Line";
            dt.Rows.Add(row);

            return dt;
        }

    }
}
