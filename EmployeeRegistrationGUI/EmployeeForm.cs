using EmployeeRegistrationGui.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EmployeeRegistrationGUI
{
    public partial class EmployeeForm : Form
    {
        private bool _editMode = false;
        public EmployeeForm()
        {
            InitializeComponent();
        }

        public EmployeeForm(Employee employee)
        {
            InitializeComponent();
            EditMode(employee);
        }

        private void EditMode(Employee employee)
        {
            _editMode = true;
            lblID.Visible = true;
            txtId.Visible = true;
            PopulateFields(employee);
        }

        private void PopulateFields(Employee employee)
        {
            txtCPF.Text = employee.CPF;
            txtEmail.Text = employee.Email;
            txtId.Text = employee.Id.ToString();
            txtName.Text = employee.Name;
            txtStartDate.Text = employee.StartDate;
            dtpBirthDate.Value= employee.BirthDate;
            cbxGender.SelectedValue = employee.Gender;
            cbxTeam.SelectedValue = employee.Team;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Employee employee = new Employee(txtName.Text, dtpBirthDate.Value, (EGender)cbxGender.SelectedValue, txtEmail.Text, txtCPF.Text, txtStartDate.Text, (ETeam)cbxTeam.SelectedValue);

                if (!_editMode)
                {
                    bool sucess = new EmployeeClient().Post(employee).Result;
                    if (sucess)
                        MessageBox.Show("Employee Registered!");
                    else
                        MessageBox.Show("Employee cant be Registered, Check the input values and try again!");
                }
                else
                {
                    employee.Id = Convert.ToInt32(txtId.Text);
                    bool sucess = new EmployeeClient().Put(employee).Result;
                    if (sucess)
                        MessageBox.Show("Employee Updated!");
                    else
                        MessageBox.Show("Employee cant be updated, Check the input values and try again!");
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :"+ ex.Message);
            }
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            cbxGender.DataSource = Enum.GetValues(typeof(EGender));
            cbxTeam.DataSource = Enum.GetValues(typeof(ETeam));
        }
    }
}
