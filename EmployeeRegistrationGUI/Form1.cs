using EmployeeRegistrationGui.Core;

namespace EmployeeRegistrationGUI
{
    public partial class MainMenu : Form
    {
        public List<Employee> _internEmployeeList { get; set; } = new List<Employee>();
        public MainMenu()
        {
            InitializeComponent();
        }
        private void MainMenu_Load_1(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            _internEmployeeList = new EmployeeClient().GetAll().Result.ToList();
            dataGridView1.DataSource = _internEmployeeList;
            dataGridView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmployeeForm employeeForm = new EmployeeForm();
            employeeForm.ShowDialog();
            LoadDataGridView();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //edit
            if (e.ColumnIndex == 8)
            {
                EmployeeForm employeeForm = new EmployeeForm(_internEmployeeList[e.RowIndex]);
                employeeForm.ShowDialog();
            }
            //delete
            else if (e.ColumnIndex == 9)
            {
                var result = MessageBox.Show($"Are you sure you want delete this employee?", "Confirm", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    bool sucess = new EmployeeClient().Delete(_internEmployeeList[e.RowIndex].Id).Result;
                    if (sucess)
                        MessageBox.Show("Employee Deleted!");
                    else
                         MessageBox.Show("Error while trying to delete the employee.");
                }
            }
            LoadDataGridView();
        }
    }
}