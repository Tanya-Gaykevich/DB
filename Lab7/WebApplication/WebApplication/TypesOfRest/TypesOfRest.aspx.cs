using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Data;
using WebApplication.Models;

namespace WebApplication.TypesOfRest
{
    public partial class TypesOfRest : System.Web.UI.Page
    {
        private readonly TouristAgencyContext _context = new TouristAgencyContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                GetTypesOfRest();
        }

        private void GetTypesOfRest()
        {
            IEnumerable<TypeOfRest> typesOfRests = _context.TypesOfRest.ToList();
            TypesOfRestGridView.DataSource = typesOfRests;
            TypesOfRestGridView.DataBind();
        }

        protected void TypesOfRestGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            TypesOfRestGridView.PageIndex = e.NewPageIndex;
            GetTypesOfRest();
        }

        protected void AddTypeOfRestButton_Click(object sender, EventArgs e)
        {
            string name = TypeOfRestNameTextBox.Text;
            string description = TypeOfRestDescriptionTextBox.Text;
            string limitation = TypeOfRestLimitationTextBox.Text;

            if (CheckValues(name, description, limitation))
            {
                TypeOfRest typeOfRest = new TypeOfRest
                {
                    Name = name,
                    Description = description,
                    Limitation = limitation
                };

                _context.TypesOfRest.Add(typeOfRest);
                _context.SaveChanges();

                TypeOfRestNameTextBox.Text = string.Empty;
                TypeOfRestDescriptionTextBox.Text = string.Empty;
                TypeOfRestLimitationTextBox.Text = string.Empty;

                AddStatusLabel.Text = "Type of rest was successfully added.";

                TypesOfRestGridView.PageIndex = TypesOfRestGridView.PageCount;
                GetTypesOfRest();
            }
        }

        protected void TypesOfRestGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            TypesOfRestGridView.EditIndex = e.NewEditIndex;
            GetTypesOfRest();
        }

        protected void TypesOfRestGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            TypesOfRestGridView.EditIndex = -1;
            GetTypesOfRest();
        }

        protected void TypesOfRestGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string name = (string)e.NewValues["Name"];
            string description = (string)e.NewValues["Description"];
            string limitation = (string)e.NewValues["Limitation"];

            if (CheckValues(name, description, limitation))
            {
                var row = TypesOfRestGridView.Rows[e.RowIndex];
                int id = int.Parse(row.Cells[1].Text);

                TypeOfRest typeOfRest = _context.TypesOfRest.FirstOrDefault(t => t.Id == id);

                typeOfRest.Name = name;
                typeOfRest.Description = description;
                typeOfRest.Limitation = limitation;

                _context.SaveChanges();

                AddStatusLabel.Text = "Type of rest was successfully updated.";

                TypesOfRestGridView.EditIndex = -1;
                GetTypesOfRest();
            }
        }

        protected void TypesOfRestGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var row = TypesOfRestGridView.Rows[e.RowIndex];
            int id = int.Parse(row.Cells[1].Text);

            TypeOfRest typeOfRest = _context.TypesOfRest.FirstOrDefault(t => t.Id == id);
            _context.TypesOfRest.Remove(typeOfRest);
            _context.SaveChanges();

            AddStatusLabel.Text = "Type of rest was successfully deleted.";

            GetTypesOfRest();
        }

        private bool CheckValues(string name, string description, string limitation)
        {
            if (string.IsNullOrEmpty(name))
            {
                AddStatusLabel.Text = "Incorrect 'Name' data.";
                return false;
            }

            if (string.IsNullOrEmpty(description))
            {
                AddStatusLabel.Text = "Incorrect 'Description' data.";
                return false;
            }

            if (string.IsNullOrEmpty(limitation))
            {
                AddStatusLabel.Text = "Incorrect 'Limitation' data.";
                return false;
            }

            return true;
        }
    }
}