using Inventory_System.Classes;
using iTextSharp.text.log;
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
    /// <summary>Dialog that adds or edits a department, depending on whether Save or Update is shown.</summary>
    public partial class DepartmentModule : Form
    {
        private readonly Connect connect = new Connect();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public DepartmentModule(string fullname, string language)
        {
            InitializeComponent();
            lblFullname.Text = fullname;
            lblLanguage.Text = language;
            this.KeyPreview = true;
        }
        // Optional fields still showing their placeholder are saved empty
        private async Task ClearItems()
        {
            if (txtDepHead.Text == "Head of Department" || txtDepHead.Text == "Начальник отдела")
            {
                txtDepHead.Text = "";
            }
            if (txtDepCont.Text == "Contact" || txtDepCont.Text == "Контакт")
            {
                txtDepCont.Text = "";
            }
            if (txtDepDesc.Text == "Description" || txtDepDesc.Text == "Описание")
            {
                txtDepDesc.Text = "";
            }
            await Task.Delay(10);
        }
        private async Task Clear()
        {
            txtDepName.Text = "";
            txtDepHead.Text = "";
            txtDepCont.Text = "";
            txtDepDesc.Text = "";
            await Task.Delay(10);
        }
        private async Task SaveDeparments(object sender, EventArgs e)
        {
            try
            {
                cm = new SqlCommand("SELECT depID,dname,dhead,dcontact,ddesc FROM Department WHERE dname LIKE N'" + txtDepName.Text + "' ", connect.EstablishConnection(lblFullname.Text));
                dr = cm.ExecuteReader();
                if (dr.HasRows == true)
                {
                    MessageBox.Show("There is already this department name.", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    while (dr.Read())
                    {
                        lblDepId.Text = dr["depID"].ToString();
                        txtDepName.Text = dr["dname"].ToString();
                        txtDepHead.Text = dr["dhead"].ToString();
                        txtDepCont.Text = dr["dcontact"].ToString();
                        txtDepDesc.Text = dr["ddesc"].ToString();
                    }
                }
                if (dr.HasRows == false)
                {
                    if (string.IsNullOrEmpty(txtDepName.Text))
                    {
                        MessageBox.Show("Please fill !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (MessageBox.Show("Are you sure you want to save this department?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        await ClearItems();
                        cm = new SqlCommand("INSERT INTO Department(dname,dhead,dcontact,ddesc)VALUES(@dname, @dhead, @dcontact, @ddesc)", connect.EstablishConnection(lblFullname.Text));
                        cm.Parameters.AddWithValue("@dname", txtDepName.Text);
                        cm.Parameters.AddWithValue("@dhead", txtDepHead.Text);
                        cm.Parameters.AddWithValue("@dcontact", txtDepCont.Text);
                        cm.Parameters.AddWithValue("@ddesc", txtDepDesc.Text);
                        cm.ExecuteNonQuery();
                        MessageBox.Show("Department has been successfully saved.");
                        Logger.WriteUserLog(lblFullname.Text, " added a new department with Department_Name  [" + txtDepName.Text + "], Department_Head [" + txtDepHead.Text + "], Department_Contact [" + txtDepCont.Text + "], Department_Description [" + txtDepDesc.Text + "] to the Department Table");
                        Logger.WriteAllLog(lblFullname.Text, " added a new department with Department_Name  [" + txtDepName.Text + "], Department_Head [" + txtDepHead.Text + "], Department_Contact [" + txtDepCont.Text + "], Department_Description [" + txtDepDesc.Text + "] to the Department Table");
                        await Clear();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteUserLog(lblFullname.Text, " Error occured in Department Table when saving a department with Department Name [" + txtDepName.Text + "]. | Error is: " + ex.Message);
                Logger.WriteAllLog(lblFullname.Text, " Error occured in Department Table when saving a department with Department Name [" + txtDepName.Text + "]. | Error is: " + ex.Message);
            }
            finally
            {
                connect.CloseConnection();
            }
        }
        private async Task UpdateDeparmnets(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtDepName.Text))
                {
                    MessageBox.Show("Please fill !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Are you sure you want to update this department?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    await ClearItems();
                    cm = new SqlCommand("UPDATE Department SET dname = @dname,dhead=@dhead, dcontact=@dcontact, ddesc=@ddesc WHERE depID LIKE '" + lblDepId.Text + "' ", connect.EstablishConnection(lblFullname.Text));
                    cm.Parameters.AddWithValue("@dname", txtDepName.Text);
                    cm.Parameters.AddWithValue("@dhead", txtDepHead.Text);
                    cm.Parameters.AddWithValue("@dcontact", txtDepCont.Text);
                    cm.Parameters.AddWithValue("@ddesc", txtDepDesc.Text);
                    cm.ExecuteNonQuery();
                    MessageBox.Show("Department has been successfully updated!");
                    Logger.WriteUserLog(lblFullname.Text, " updated a new department with Department_Name  [" + txtDepName.Text + "], Department_Head [" + txtDepHead.Text + "], Department_Contact [" + txtDepCont.Text + "], Department_Description [" + txtDepDesc.Text + "] in the Department Table");
                    Logger.WriteAllLog(lblFullname.Text, " updated a new department with Department_Name  [" + txtDepName.Text + "], Department_Head [" + txtDepHead.Text + "], Department_Contact [" + txtDepCont.Text + "], Department_Description [" + txtDepDesc.Text + "] in the Department Table");
                    this.Dispose();
                }

            }
            catch (Exception ex)
            {
                Logger.WriteUserLog(lblFullname.Text, " Error occured in Department Table when saving a department with Department Name [" + txtDepName.Text + "]. | Error is: " + ex.Message);
                Logger.WriteAllLog(lblFullname.Text, " Error occured in Department Table when saving a department with Department Name [" + txtDepName.Text + "]. | Error is: " + ex.Message);
            }
            finally
            {
                connect.CloseConnection();
            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            _ = SaveDeparments(sender, e);
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            _ = UpdateDeparmnets(sender, e);
        }
        private void BtnClear_Click(object sender, EventArgs e)
        {
            _ = Clear();
        }
        #region Design
        // Lets the borderless dialog be dragged by its body
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void DepartmentModule_KeyDown(object sender, KeyEventArgs e)
        {
                
        }
        private void DepartmentModule_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void TxtDepName_Enter(object sender, EventArgs e)
        {
            if (txtDepName.Text == "Department Name" || txtDepName.Text == "Название отдела")
            {
                txtDepName.Text = "";
            }
        }
        private void TxtDepName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDepName.Text))
            {
                if (lblLanguage.Text == "Russian")
                {
                    txtDepName.Text = "Название отдела";
                }
                else
                    txtDepName.Text = "Department Name";
            }
        }
        private void TxtDepHead_Enter(object sender, EventArgs e)
        {
            if (txtDepHead.Text == "Head of Department" || txtDepHead.Text == "Начальник отдела")
            {
                txtDepHead.Text = "";
            }
        }
        private void TxtDepHead_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDepHead.Text))
            {
                if (lblLanguage.Text == "Russian")
                {
                    txtDepHead.Text = "Начальник отдела";
                }
                else
                    txtDepHead.Text = "Head of Department";
            }
        }
        private void TxtDepCont_Enter(object sender, EventArgs e)
        {
            if (txtDepCont.Text == "Contact" || txtDepCont.Text == "Контакт")
            {
                txtDepCont.Text = "";
            }
        }
        private void TxtDepCont_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDepCont.Text))
            {
                if (lblLanguage.Text == "Russian")
                {
                    txtDepCont.Text = "Контакт";
                }
                else
                    txtDepCont.Text = "Contact";
            }
        }
        private void TxtDepDesc_Enter(object sender, EventArgs e)
        {
            if (txtDepDesc.Text == "Description" || txtDepDesc.Text == "Описание")
            {
                txtDepDesc.Text = "";
            }
        }
        private void TxtDepDesc_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDepDesc.Text))
            {
                if (lblLanguage.Text == "Russian")
                {
                    txtDepDesc.Text = "Описание";
                }
                else
                    txtDepDesc.Text = "Description";
            }
        }
        #endregion
    }
}
