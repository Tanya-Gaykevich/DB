using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Data;
using WebApplication.Models;
using System.Data.Entity;

namespace WebApplication.Employees
{
    public partial class Employees : System.Web.UI.Page
    {
        private readonly TouristAgencyContext _context = new TouristAgencyContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                GetEmployees();
        }

        private void GetEmployees()
        {
            IEnumerable<Employee> employees = _context.Employees.Include(emp => emp.Position).ToList();
            EmployeesGridView.DataSource = employees;
            EmployeesGridView.DataBind();
        }

        protected void EmployeesGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            EmployeesGridView.PageIndex = e.NewPageIndex;
            GetEmployees();
        }

        protected void AddEmployeeButton_Click(object sender, EventArgs e)
        {
            string lastName = EmployeeLastNameTextBox.Text;
            string firstName = EmployeeFirstNameTextBox.Text;
            string middleName = EmployeeMiddleNameTextBox.Text;
            DateTime birthDate = EmployeeBirthDatesCalendar.SelectedDate;
            int positionId = int.Parse(PositionsDropDownList.SelectedValue);

            if (CheckValues(lastName, firstName, middleName, birthDate))
            {
                Employee employee = new Employee
                {
                    LastName = lastName,
                    FirstName = firstName,
                    MiddleName = middleName,
                    BirthDate = birthDate,
                    PositionId = positionId
                };

                _context.Employees.Add(employee);
                _context.SaveChanges();

                EmployeeLastNameTextBox.Text = string.Empty;
                EmployeeFirstNameTextBox.Text = string.Empty;
                EmployeeMiddleNameTextBox.Text = string.Empty;
                EmployeeBirthDatesCalendar.SelectedDate = DateTime.Now.Date;
                PositionsDropDownList.SelectedIndex = 1;

                AddStatusLabel.Text = "Employee was successfully added.";

                EmployeesGridView.PageIndex = EmployeesGridView.PageCount;
                GetEmployees();
            }
        }

        protected void EmployeesGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            EmployeesGridView.EditIndex = e.NewEditIndex;
            GetEmployees();
        }

        protected void EmployeesGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            EmployeesGridView.EditIndex = -1;
            GetEmployees();
        }

        protected void EmployeesGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string lastName = (string)e.NewValues["LastName"];
            string firstName = (string)e.NewValues["FirstName"];
            string middleName = (string)e.NewValues["MiddleName"];
            DateTime birthDate = (DateTime)e.NewValues["BirthDate"];
            int positionId = int.Parse((string)e.NewValues["PositionId"]);

            if (CheckValues(lastName, firstName, middleName, birthDate))
            {
                var row = EmployeesGridView.Rows[e.RowIndex];
                int id = int.Parse(row.Cells[1].Text);

                Employee employee = _context.Employees.FirstOrDefault(emp => emp.Id == id);

                employee.LastName = lastName;
                employee.FirstName = firstName;
                employee.MiddleName = middleName;
                employee.BirthDate = birthDate;
                employee.PositionId = positionId;

                _context.SaveChanges();

                AddStatusLabel.Text = "Employee was successfully updated.";

                EmployeesGridView.EditIndex = -1;
                GetEmployees();
            }
        }

        protected void EmployeesGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var row = EmployeesGridView.Rows[e.RowIndex];
            int id = int.Parse(row.Cells[1].Text);

            Employee employee = _context.Employees.FirstOrDefault(emp => emp.Id == id);
            _context.Employees.Remove(employee);
            _context.SaveChanges();

            AddStatusLabel.Text = "Employee was successfully deleted.";
            GetEmployees();
        }

        private bool CheckValues(string lastName, string firstName, string middleName, DateTime birthDate)
        {
            if (string.IsNullOrEmpty(lastName))
            {
                AddStatusLabel.Text = "Incorrect 'Last Name' data.";
                return false;
            }

            if (string.IsNullOrEmpty(firstName))
            {
                AddStatusLabel.Text = "Incorrect 'First Name' data.";
                return false;
            }

            if (string.IsNullOrEmpty(middleName))
            {
                AddStatusLabel.Text = "Incorrect 'Middle Name' data.";
                return false;
            }

            if (birthDate == default)
            {
                AddStatusLabel.Text = "Incorrect 'Birth Date' data.";
                return false;
            }

            return true;
        }
    }
}