using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Data;
using WebApplication.Models;

namespace WebApplication.Positions
{
    public partial class Positions : System.Web.UI.Page
    {
        private readonly TouristAgencyContext _context = new TouristAgencyContext();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                GetPositions();
        }

        private void GetPositions()
        {
            IEnumerable<Position> positions = _context.Positions.ToList();
            PositionsGridView.DataSource = positions;
            PositionsGridView.DataBind();
        }

        protected void PositionsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            PositionsGridView.PageIndex = e.NewPageIndex;
            GetPositions();
        }

        protected void AddPositionButton_Click(object sender, EventArgs e)
        {
            string name = PositionNameTextBox.Text;

            if (CheckValues(name))
            {
                Position position = new Position
                {
                    Name = name
                };

                _context.Positions.Add(position);
                _context.SaveChanges();

                PositionNameTextBox.Text = string.Empty;

                AddStatusLabel.Text = "Position was successfully added.";

                PositionsGridView.PageIndex = PositionsGridView.PageCount;
                GetPositions();
            }
        }

        protected void PositionsGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            PositionsGridView.EditIndex = e.NewEditIndex;
            GetPositions();
        }

        protected void PositionsGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            PositionsGridView.EditIndex = -1;
            GetPositions();
        }

        protected void PositionsGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string name = (string)e.NewValues["Name"];

            if (CheckValues(name))
            {
                var row = PositionsGridView.Rows[e.RowIndex];
                int id = int.Parse(row.Cells[1].Text);

                Position position = _context.Positions.FirstOrDefault(p => p.Id == id);

                position.Name = name;

                _context.SaveChanges();

                AddStatusLabel.Text = "Position was successfully updated.";

                PositionsGridView.EditIndex = -1;
                GetPositions();
            }
        }

        protected void PositionsGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var row = PositionsGridView.Rows[e.RowIndex];
            int id = int.Parse(row.Cells[1].Text);

            Position position = _context.Positions.FirstOrDefault(p => p.Id == id);
            _context.Positions.Remove(position);
            _context.SaveChanges();

            AddStatusLabel.Text = "Position was successfully deleted.";

            GetPositions();
        }

        private bool CheckValues(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                AddStatusLabel.Text = "Incorrect 'Name' data.";
                return false;
            }

            return true;
        }
    }
}