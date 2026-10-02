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
    public partial class User : Form
    {
        private readonly Connect connect = new Connect();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        private string isSuspend = "";
        public User(string fullname,string language)
        {
            InitializeComponent();
            _=LoadUser();
            lblFullname.Text = fullname;
            lblLanguage.Text=language;
        }
        private async Task LoadUser()
        {
            try
            {
                dgvUser.Rows.Clear();
                string searchText = txtSearch.Text == "Search in . . . " || txtSearch.Text == "Поиск в . . . " ? "" : txtSearch.Text;
                string query = "SELECT * FROM Users ORDER BY ID ASC";
                // Add search conditions only if searchText is not empty
                if (!string.IsNullOrEmpty(searchText))
                {
                    query = @"SELECT * FROM Users
                     WHERE fullname LIKE @searchText 
                     OR ip_address LIKE @searchText 
                     OR suspended LIKE @searchText";
                }
                cm = new SqlCommand(query, connect.EstablishConnection(lblFullname.Text));

                // Add search parameter only if searchText is not empty
                if (!string.IsNullOrEmpty(searchText))
                {
                    cm.Parameters.AddWithValue("@searchText", "%" + searchText + "%");
                }
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    dgvUser.Rows.Add(dr["ID"].ToString(), dr["fullname"].ToString(), dr["type"].ToString(), dr["online"].ToString(), dr["suspended"].ToString(), dr["session"].ToString(), dr["ip_address"].ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.WriteUserLog(lblFullname.Text, " | Error occured when loading users in User Panel. | Error is: " + ex.Message);
                Logger.WriteAllLog(lblFullname.Text, " | Error occured when loading users in User Panel. | Error is: " + ex.Message);
            }
            finally
            {
                dr.Close();
                connect.CloseConnection();
                txtTotal.Text = dgvUser.Rows.Count.ToString();
                await Task.Delay(10);
            }
        }
        private async Task EditUsers(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = dgvUser.Columns[e.ColumnIndex].Name;
                if (colName == "Edit")
                {
                    UserModule userModule = new UserModule(lblFullname.Text, lblLanguage.Text);
                    userModule.txtUserId.Text = dgvUser.Rows[e.RowIndex].Cells[0].Value.ToString();
                    userModule.txtFullname.Text = dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString();
                    userModule.cmbUsertype.Text = dgvUser.Rows[e.RowIndex].Cells[2].Value.ToString();
                    userModule.btnSave.Visible = false;
                    userModule.btnUpdate.Location = new System.Drawing.Point(34, 346);
                    userModule.btnClear.Location = new System.Drawing.Point(186, 346);
                    userModule.ShowDialog();
                    await LoadUser();
                }
                else if (colName == "Delete")
                {
                    if (MessageBox.Show("Are you sure you want to delete this user?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cm = new SqlCommand("DELETE FROM Users WHERE ID=@ID", connect.EstablishConnection(lblFullname.Text));
                        cm.Parameters.AddWithValue("@ID", dgvUser.Rows[e.RowIndex].Cells[0].Value.ToString());
                        cm.ExecuteNonQuery();
                        MessageBox.Show("User has been succesfully deleted!");
                        Logger.WriteUserLog(lblFullname.Text, " deleted a user with user_id [" + dgvUser.Rows[e.RowIndex].Cells[0].Value.ToString() + "]");
                        Logger.WriteAllLog(lblFullname.Text, " deleted a user with user_id [" + dgvUser.Rows[e.RowIndex].Cells[0].Value.ToString() + "]");
                    }
                    await LoadUser();
                }
                else if (colName == "Disconnect")
                {
                    cm = new SqlCommand("SELECT suspended FROM Users WHERE ID=@ID", connect.EstablishConnection(lblFullname.Text));
                    cm.Parameters.AddWithValue("@ID", dgvUser.Rows[e.RowIndex].Cells[0].Value.ToString());
                    dr = cm.ExecuteReader();
                    while (dr.Read())
                    {
                        isSuspend = dr[0].ToString();
                    }
                    if (isSuspend == "disabled")
                    {
                        if (MessageBox.Show("Do you want to enable this user?", "Enable User", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            cm = new SqlCommand("UPDATE Users SET suspended=@suspended,online=@online WHERE ID=@ID", connect.EstablishConnection(lblFullname.Text));
                            cm.Parameters.AddWithValue("@ID", dgvUser.Rows[e.RowIndex].Cells[0].Value.ToString());
                            cm.Parameters.AddWithValue("@suspended", "enabled");
                            cm.Parameters.AddWithValue("@online", "offline");
                            cm.ExecuteNonQuery();
                            MessageBox.Show("User is enabled");
                            Logger.WriteUserLog(lblFullname.Text, " suspended a user with Fullname [" + dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString() + "]");
                            Logger.WriteAllLog(lblFullname.Text, " suspended a user with Fullname [" + dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString() + "]");
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("Are you sure you want to disconnect this user?", "Disconnect User", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            cm = new SqlCommand("UPDATE Users SET suspended=@suspended,online=@online WHERE ID=@ID", connect.EstablishConnection(lblFullname.Text));
                            cm.Parameters.AddWithValue("@ID", dgvUser.Rows[e.RowIndex].Cells[0].Value.ToString());
                            cm.Parameters.AddWithValue("@suspended", "disabled");
                            cm.Parameters.AddWithValue("@online", "offline");
                            cm.Parameters.AddWithValue("@session", "");
                            cm.Parameters.AddWithValue("@ip_address", "");
                            cm.ExecuteNonQuery();
                            MessageBox.Show("User has been suspended");
                            Logger.WriteUserLog(lblFullname.Text, " suspended a user with Fullname [" + dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString() + "]");
                            Logger.WriteAllLog(lblFullname.Text, " suspended a user with Fullname [" + dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString() + "]");
                        }
                    }
                    await LoadUser();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteUserLog(lblFullname.Text, " | Error occured when editing users in User Panel. | Error is: " + ex.Message);
                Logger.WriteAllLog(lblFullname.Text, " | Error occured when editing users in User Panel. | Error is: " + ex.Message);
            }
            finally
            {
                dr.Close();
                connect.CloseConnection();
                await Task.Delay(10);
            }
        }
        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e) => _ = EditUsers(sender, e);
        private void txtSearch_TextChanged(object sender, EventArgs e)=>_ = LoadUser();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            UserModule userModule = new UserModule(lblFullname.Text,lblLanguage.Text);
            userModule.StartPosition = FormStartPosition.CenterScreen;
            userModule.btnUpdate.Visible = false;
            userModule.btnSave.Location = new System.Drawing.Point(34,346);
            userModule.btnClear.Location = new System.Drawing.Point(186,346);
            userModule.ShowDialog();
            _=LoadUser();
        }
        private void txtSearch_Leave(object sender, EventArgs e)
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
        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search in . . . "||txtSearch.Text== "Поиск в . . . ")
            {
                txtSearch.Text = "";
            }
        }
    }
}