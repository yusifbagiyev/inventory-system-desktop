using Inventory_System.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_System.Forms
{
    /// <summary>Dialog that adds or renames a category, depending on whether Save or Update is shown.</summary>
    public partial class CategoryModule : Form
    {
        private readonly Connect connect = new Connect();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public CategoryModule(string fullname, string language)
        {
            InitializeComponent();
            lblFullname.Text = fullname;
            lblLanguage.Text = language;
            this.KeyPreview = true;
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private async Task SaveCategory(object sender, EventArgs e)
        {
            try
            {
                cm = new SqlCommand("SELECT catId,catname FROM Category WHERE catname LIKE N'" + txtCatName.Text + "' ", connect.EstablishConnection(lblFullname.Text));
                dr = cm.ExecuteReader();
                if (dr.HasRows == true)
                {
                    MessageBox.Show("There is already this category name.", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    while (dr.Read())
                    {
                        txtCatId.Text = dr["catId"].ToString();
                        txtCatName.Text = dr["catname"].ToString();
                    }
                }
                if (dr.HasRows == false)
                {
                    if (string.IsNullOrEmpty(txtCatName.Text) || txtCatName.Text == "Category Name")
                    {
                        MessageBox.Show("Please fill !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (MessageBox.Show("Are you sure you want to save this category?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cm = new SqlCommand("INSERT INTO Category(catname)VALUES(@catname)", connect.EstablishConnection(lblFullname.Text));
                        cm.Parameters.AddWithValue("@catname", txtCatName.Text);
                        cm.ExecuteNonQuery();
                        MessageBox.Show("Category has been successfully saved.");
                        Logger.WriteUserLog(lblFullname.Text, " added a new category with Category_Name [" + txtCatName.Text + "] to the Category Table");
                        Logger.WriteAllLog(lblFullname.Text, " added a new category with Category_Name [" + txtCatName.Text + "] to the Category Table");
                        this.Close();
                    }
                }
                await Task.Delay(10);
            }
            catch (Exception ex)
            {
                Logger.WriteUserLog(lblFullname.Text, " Error occured in Category Table when saving a category with Category Name [" + txtCatName.Text + "] | Error: " + ex.Message);
                Logger.WriteAllLog(lblFullname.Text, " Error occured in Category Table when saving a category with Category Name [" + txtCatName.Text + "] | Error: " + ex.Message);
            }
            finally
            {
                dr.Close();
                connect.CloseConnection();
            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            _ = SaveCategory(sender, e);
        }
        private async Task UpdateCategory(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCatName.Text))
                {
                    MessageBox.Show("Please fill !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Are you sure you want to update this category?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("UPDATE Category SET catname = @catname WHERE catId LIKE N'" + txtCatId.Text + "' ", connect.EstablishConnection(lblFullname.Text));
                    cm.Parameters.AddWithValue("@catname", txtCatName.Text);
                    cm.ExecuteNonQuery();
                    MessageBox.Show("Category has been successfully updated!");
                    Logger.WriteUserLog(lblFullname.Text, " updated a new category with Category_Name [" + txtCatName.Text + "] to the Category Table");
                    Logger.WriteAllLog(lblFullname.Text, " updated a new category with Category_Name [" + txtCatName.Text + "] to the Category Table");
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Logger.WriteUserLog(lblFullname.Text, " Error occured in Category Table when updating a category with Category Name [" + txtCatName.Text + "] | Error: " + ex.Message);
                Logger.WriteAllLog(lblFullname.Text, " Error occured in Category Table when updating a category with Category Name [" + txtCatName.Text + "] | Error: " + ex.Message);
            }
            finally
            {
                connect.CloseConnection();
                await Task.Delay(10);
            }
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            _ = UpdateCategory(sender, e);
        }
        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtCatName.Text = "";
        }
        #region Design
        private void TxtCatName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCatName.Text))
            {
                if (lblLanguage.Text == "Russian")
                {
                    txtCatName.Text = "Название категории";
                }
                else
                    txtCatName.Text = "Category Name";
            }
        }
        private void TxtCatName_Enter(object sender, EventArgs e)
        {
            if (txtCatName.Text == "Category Name" || txtCatName.Text == "Название категории")
            {
                txtCatName.Text = "";
            }
        }
        // Lets the borderless dialog be dragged by its body
        private void CategoryModule_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void CategoryModule_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (btnSave.Visible != false)
                {
                    BtnSave_Click(this, EventArgs.Empty);
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                }
                else
                {
                    BtnUpdate_Click(this, EventArgs.Empty);
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                }
            }
        }
        #endregion
    }
}
