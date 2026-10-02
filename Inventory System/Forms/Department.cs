using Inventory_System.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_System.Forms
{
    /// <summary>Department list page with a search box and edit and delete buttons on each row.</summary>
    public partial class Department : Form
    {
        private readonly Connect connect = new Connect();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public Department(string fullname, string language)
        {
            InitializeComponent();
            lblFullname.Text = fullname;
            lblLanguage.Text = language;
            _ = LoadDepartment();
        }
        private async Task LoadDepartment()
        {
            try
            {
                dgvDepartment.Rows.Clear();
                // The search box holds its placeholder as text, and that text means no filter
                string searchText = txtSearch.Text == "Search in . . . " || txtSearch.Text == "Поиск в . . . " ? "" : txtSearch.Text;
                string query = "SELECT * FROM Department";
                if (!string.IsNullOrEmpty(searchText))
                {
                    query += @" WHERE dname LIKE @searchText 
                     OR dhead LIKE @searchText 
                     OR dcontact LIKE @searchText 
                     OR ddesc LIKE @searchText";
                }

                cm = new SqlCommand(query, connect.EstablishConnection(lblFullname.Text));

                if (!string.IsNullOrEmpty(searchText))
                {
                    cm.Parameters.AddWithValue("@searchText", "%" + searchText + "%");
                }
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    dgvDepartment.Rows.Add(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());
                }
                await Task.Delay(10);
            }
            catch (Exception ex)
            {
                Logger.WriteUserLog(lblFullname.Text, " | Error is occured when loading departments. | Error is: " + ex.Message);
                Logger.WriteAllLog(lblFullname.Text, " | Error is occured when loading departments. | Error is: " + ex.Message);
            }
            finally
            {
                dr.Close();
                connect.CloseConnection();
                txtTotal.Text = dgvDepartment.Rows.Count.ToString();
            }
        }
        // The grid shows no ids, so the id is looked up by department name
        private string LoadID(string text)
        {
            try
            {
                var depID = "";
                cm = new SqlCommand("SELECT depID FROM Department WHERE dname=@dname", connect.EstablishConnection(lblFullname.Text));
                cm.Parameters.AddWithValue("@dname", text);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    depID = dr["depID"].ToString();
                }
                return depID;
            }
            catch (Exception ex)
            {
                Logger.WriteUserLog(lblFullname.Text, " | Error is occured when loading ID in Department Panel. | Error is: " + ex.Message);
                Logger.WriteAllLog(lblFullname.Text, " | Error is occured when loading ID in Department Panel. | Error is: " + ex.Message);
                throw;
            }
            finally
            {
                dr.Close();
                connect.CloseConnection();
            }
        }
        private async Task EditDeparment(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = dgvDepartment.Columns[e.ColumnIndex].Name;
                if (colName == "Edit")
                {
                    DepartmentModule departmentModule = new DepartmentModule(lblFullname.Text, lblLanguage.Text);
                    departmentModule.txtDepName.Text = dgvDepartment.Rows[e.RowIndex].Cells[0].Value.ToString();
                    departmentModule.txtDepHead.Text = dgvDepartment.Rows[e.RowIndex].Cells[1].Value.ToString();
                    departmentModule.txtDepCont.Text = dgvDepartment.Rows[e.RowIndex].Cells[2].Value.ToString();
                    departmentModule.txtDepDesc.Text = dgvDepartment.Rows[e.RowIndex].Cells[3].Value.ToString();
                    departmentModule.lblDepId.Text = LoadID(dgvDepartment.Rows[e.RowIndex].Cells[0].Value.ToString());

                    departmentModule.StartPosition = FormStartPosition.CenterScreen;
                    departmentModule.btnSave.Visible = false;
                    departmentModule.btnUpdate.Location = new System.Drawing.Point(38, 331);
                    departmentModule.btnClear.Location = new System.Drawing.Point(191, 331);
                    departmentModule.ShowDialog();
                    await LoadDepartment();
                }
                else if (colName == "Delete")
                {
                    if (MessageBox.Show("Are you sure you want to delete this department?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cm = new SqlCommand("DELETE FROM Department WHERE depID LIKE @depID", connect.EstablishConnection(lblFullname.Text));
                        cm.Parameters.AddWithValue("@depID", LoadID(dgvDepartment.Rows[e.RowIndex].Cells[0].Value.ToString()));
                        cm.ExecuteNonQuery();
                        MessageBox.Show("Record has been successfully deleted!");
                        Logger.WriteUserLog(lblFullname.Text, " deleted a department with Department_Name [" + dgvDepartment.Rows[e.RowIndex].Cells[0].Value.ToString() + "] from Department Table");
                        Logger.WriteAllLog(lblFullname.Text, " deleted a department with Department_Name [" + dgvDepartment.Rows[e.RowIndex].Cells[0].Value.ToString() + "] from Department Table");
                        await LoadDepartment();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteUserLog(lblFullname.Text, " | Error occured in Departments Panel when loading departments. | Error is: " + ex.Message);
                Logger.WriteAllLog(lblFullname.Text, " | Error occured in Departments Panel when loading departments. | Error is: " + ex.Message);
            }
            finally
            {
                connect.CloseConnection();
            }
        }
        private void dgvDepartment_CellContentClick(object sender, DataGridViewCellEventArgs e) => _ = EditDeparment(sender, e);
        // One dialog both adds and edits, so the unused button is hidden and the others take its place
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            DepartmentModule DepartmentForm = new DepartmentModule(lblFullname.Text, lblLanguage.Text);
            DepartmentForm.StartPosition = FormStartPosition.CenterScreen;
            DepartmentForm.btnUpdate.Visible = false;
            DepartmentForm.StartPosition = FormStartPosition.CenterScreen;
            DepartmentForm.btnSave.Location = new System.Drawing.Point(38, 331);
            DepartmentForm.btnClear.Location = new System.Drawing.Point(191, 331);
            DepartmentForm.ShowDialog();
            _ = LoadDepartment();
        }
        private void TxtSearch_OnValueChanged(object sender, EventArgs e)
        {
            _ = LoadDepartment();
        }
        #region Design
        private void TxtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search in . . . " || txtSearch.Text == "Поиск в . . . ")
            {
                txtSearch.Text = "";
            }
        }
        private void TxtSearch_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtSearch.Text))
            {
                if (lblLanguage.Text == "Russian")
                {
                    txtSearch.Text = "Поиск в . . . ";
                }
                else
                    txtSearch.Text = "Search in . . . ";
            }
        }
        #endregion
    }
}
