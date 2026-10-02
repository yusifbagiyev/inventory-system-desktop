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
using ZXing;

namespace Inventory_System.Forms
{
    /// <summary>Category list page with a search box and edit and delete buttons on each row.</summary>
    public partial class Category : Form
    {
        private readonly Connect connect = new Connect();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public Category(string fullname, string language)
        {
            InitializeComponent();
            lblFullname.Text = fullname;
            lblLanguage.Text = language;
            _ = LoadCategory();
        }
        private async Task LoadCategory()
        {
            try
            {
                dgvCategory.Rows.Clear();
                // The search box holds its placeholder as text, and that text means no filter
                string searchText = txtSearch.Text == "Search in . . . " || txtSearch.Text == "Поиск в . . . " ? "" : txtSearch.Text;
                string query = "SELECT * FROM Category";
                if (!string.IsNullOrEmpty(searchText))
                {
                    query += @" WHERE catname LIKE @searchText ";
                }
                cm = new SqlCommand(query, connect.EstablishConnection(lblFullname.Text));
                if (!string.IsNullOrEmpty(searchText))
                {
                    cm.Parameters.AddWithValue("@searchText", "%" + searchText + "%");
                }
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    dgvCategory.Rows.Add(dr["catname"].ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.WriteUserLog(lblFullname.Text, " | Error is occured when loading categories in Category Panel. | Error is: " + ex.Message);
                Logger.WriteAllLog(lblFullname.Text, " | Error is occured when loading categories in Category Panel. | Error is: " + ex.Message);
            }
            finally
            {
                dr.Close();
                connect.CloseConnection();
                txtTotal.Text = dgvCategory.Rows.Count.ToString();
                await Task.Delay(10);
            }
        }
        // The grid shows only names, so the id is looked up by name
        private string LoadID(string text)
        {
            try
            {
                var catid = "";
                cm = new SqlCommand("SELECT catID FROM Category WHERE catname=N'" + text + "'", connect.EstablishConnection(lblFullname.Text));
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    catid = dr[0].ToString();
                }
                return catid;
            }
            catch (Exception ex)
            {
                Logger.WriteUserLog(lblFullname.Text, " | Error is occured when loading ID in Category Panel. | Error is: " + ex.Message);
                Logger.WriteAllLog(lblFullname.Text, " | Error is occured when loading ID in Category Panel. | Error is: " + ex.Message);
                throw;
            }
            finally
            {
                dr.Close();
                connect.CloseConnection();
            }
        }
        // One dialog both adds and edits, so the unused button is hidden and the others take its place
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            CategoryModule categoryForm = new CategoryModule(lblFullname.Text, lblLanguage.Text);
            categoryForm.btnUpdate.Visible = false;
            categoryForm.StartPosition = FormStartPosition.CenterScreen;
            categoryForm.btnSave.Location = new System.Drawing.Point(34, 187);
            categoryForm.btnClear.Location = new System.Drawing.Point(187, 187);
            categoryForm.ShowDialog();
            _ = LoadCategory();
        }
        private async Task EditCategory(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = dgvCategory.Columns[e.ColumnIndex].Name;
                if (colName == "Edit")
                {
                    CategoryModule categoryModule = new CategoryModule(lblFullname.Text, lblLanguage.Text);
                    categoryModule.txtCatName.Text = dgvCategory.Rows[e.RowIndex].Cells[0].Value.ToString();
                    categoryModule.txtCatId.Text = LoadID(dgvCategory.Rows[e.RowIndex].Cells[0].Value.ToString());

                    categoryModule.StartPosition = FormStartPosition.CenterScreen;
                    categoryModule.btnSave.Visible = false;
                    categoryModule.btnUpdate.Location = new System.Drawing.Point(34, 187);
                    categoryModule.btnClear.Location = new System.Drawing.Point(187, 187);
                    categoryModule.ShowDialog();
                    await LoadCategory();
                }
                if (colName == "Delete")
                {
                    if (MessageBox.Show("Are you sure you want to delete this category?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cm = new SqlCommand("DELETE FROM Category WHERE catId LIKE '" + LoadID(dgvCategory.Rows[e.RowIndex].Cells[0].Value.ToString()) + "'", connect.EstablishConnection(lblFullname.Text));
                        cm.ExecuteNonQuery();
                        connect.CloseConnection();
                        MessageBox.Show("Record has been successfully deleted!");
                        Logger.WriteUserLog(lblFullname.Text, " deleted a department with Category_Name [" + dgvCategory.Rows[e.RowIndex].Cells[0].Value.ToString() + "] from Category Table");
                        Logger.WriteAllLog(lblFullname.Text, " deleted a department with Category_Name [" + dgvCategory.Rows[e.RowIndex].Cells[0].Value.ToString() + "] from Category Table");
                        await LoadCategory();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteUserLog(lblFullname.Text, " | Error is occured when editing categories. | Error is: " + ex.Message);
                Logger.WriteAllLog(lblFullname.Text, " | Error is occured when editing categories. | Error is: " + ex.Message);
            }
            finally
            {
                connect.CloseConnection();
                await Task.Delay(100);
            }
        }
        private void DgvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e) => _ = EditCategory(sender, e);
        private void TxtSearch_OnValueChanged(object sender, EventArgs e)=> _ = LoadCategory();
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
            if (string.IsNullOrEmpty(txtSearch.Text))
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