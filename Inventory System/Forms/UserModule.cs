using Inventory_System.Classes;
using iTextSharp.text.xml;
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
    public partial class UserModule : Form
    {
        private readonly Connect connect = new Connect();
        SqlCommand cm = new SqlCommand();
        public UserModule(string fullname,string language)
        {
            InitializeComponent();
            lblFullname.Text = fullname;
            lblLanguage.Text = language;
            this.KeyPreview = true;
        }
        private void btnExit_Click(object sender, EventArgs e) => this.Dispose();
        private async Task SaveUsers()
        {
            try
            {
                if (string.IsNullOrEmpty(txtFullname.Text) || string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtConfirmPass.Text) || string.IsNullOrEmpty(cmbUsertype.Text) || txtPassword.Text == "Password" || txtConfirmPass.Text == "Confirm Password")
                {
                    MessageBox.Show("Please fill !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtPassword.Text != txtConfirmPass.Text)
                {
                    MessageBox.Show("Password did not Match!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Are you sure you want to save this user?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("INSERT INTO Users(fullname,password,type,online,suspended,session,ip_address,language)VALUES(@fullname,@password,@type,@online,@suspended,@session,@ip_address,@language)", connect.EstablishConnection(txtFullname.Text));
                    var key = AppSettings.PasswordKey;
                    var user_password = Cryptography.EncryptString(key, txtPassword.Text);
                    cm.Parameters.AddWithValue("@fullname", txtFullname.Text);
                    cm.Parameters.AddWithValue("@password", user_password);
                    cm.Parameters.AddWithValue("@type", cmbUsertype.Text);
                    cm.Parameters.AddWithValue("@online", "offline");
                    cm.Parameters.AddWithValue("@suspended", "enabled");
                    cm.Parameters.AddWithValue("@session", "");
                    cm.Parameters.AddWithValue("@ip_address", "");
                    cm.Parameters.AddWithValue("@language", "English");
                    cm.ExecuteNonQuery();
                    MessageBox.Show("User has been successfully saved.");
                    Logger.WriteUserLog(txtFullname.Text, " added a new user with Fullname [" + txtFullname.Text + "], User_Type [" + cmbUsertype.Text + "] to the User Table");
                    Logger.WriteAllLog(txtFullname.Text, " added a new user with Fullname [" + txtFullname.Text + "], User_Type [" + cmbUsertype.Text + "] to the User Table");
                }
            }
            catch (Exception ex)
            {
                Logger.WriteUserLog(lblFullname.Text, " | Error occured when saving a new user with Fullname [" + txtFullname.Text + "] in UserModule Panel. | Error is: " + ex.Message);
                Logger.WriteAllLog(lblFullname.Text, " | Error occured when saving a new user with Fullname [" + txtFullname.Text + "] in UserModule Panel. | Error is: " + ex.Message);
            }
            finally
            {
                connect.CloseConnection();
                await Task.Delay(200);
                this.Close();
            }
        }
        private async Task UpdateUsers()
        {
            try
            {
                if (string.IsNullOrEmpty(txtFullname.Text) || string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtConfirmPass.Text))
                {
                    MessageBox.Show("Please fill !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtPassword.Text != txtConfirmPass.Text)
                {
                    MessageBox.Show("Password did not Match!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Are you sure you want to update this user?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("UPDATE Users SET fullname = @fullname, password=@password, type=@type WHERE ID=@ID", connect.EstablishConnection(txtFullname.Text));
                    cm.Parameters.AddWithValue("@ID", txtUserId.Text);
                    cm.Parameters.AddWithValue("@fullname", txtFullname.Text);
                    var key = AppSettings.PasswordKey;
                    var user_password = Cryptography.EncryptString(key, txtPassword.Text);
                    cm.Parameters.AddWithValue("@password", user_password);
                    cm.Parameters.AddWithValue("@type", cmbUsertype.Text);
                    cm.ExecuteNonQuery();
                    MessageBox.Show("User has been successfully updated!");
                    Logger.WriteUserLog(txtFullname.Text, " updated a user with User_Id [" + txtUserId.Text + "], Fullname [" + txtFullname.Text + "], User_Type [" + cmbUsertype.Text + "] in the tbUser Table");
                    Logger.WriteAllLog(txtFullname.Text, " updated a user with User_Id [" + txtUserId.Text + "], Fullname [" + txtFullname.Text + "], User_Type [" + cmbUsertype.Text + "] in the tbUser Table");
                }
            }
            catch (Exception ex)
            {
                Logger.WriteUserLog(lblFullname.Text, " | Error occured when updating a user with Fullname [" + txtFullname.Text + "]. | Error is: " + ex.Message);
                Logger.WriteAllLog(lblFullname.Text, " | Error occured when updating a user with Fullname [" + txtFullname.Text + "]. | Error is: " + ex.Message);
            }
            finally
            {
                connect.CloseConnection();
                this.Dispose();
                await Task.Delay(10);
            }
        }
        private void btnSave_Click(object sender, EventArgs e) => _ = SaveUsers();
        private void btnUpdate_Click(object sender, EventArgs e) => _ = UpdateUsers();
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFullname.Text = "";
            txtPassword.Text = "";
            cmbUsertype.Text = null;
            txtConfirmPass.Text = "";
        }
        #region Design
        private void UserModule_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (btnSave.Visible != false)
                {
                    btnSave_Click(this, EventArgs.Empty);  // Trigger the Click event
                    e.SuppressKeyPress = true;  // Prevent the default behavior
                    e.Handled = true;// Stops the event from being passed to the control
                }
                else
                {
                    btnUpdate_Click(this, EventArgs.Empty);  // Trigger the Click event
                    e.SuppressKeyPress = true;  // Prevent the default behavior
                    e.Handled = true;// Stops the event from being passed to the control
                }
            }
        }
        private void txtFullname_Enter(object sender, EventArgs e)
        {
            if (txtFullname.Text == "Fullname"||txtFullname.Text== "Полное имя")
            {
                txtFullname.Text = "";
            }
        }
        private void txtFullname_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFullname.Text))
            {
                if (lblLanguage.Text == "Russian")
                {
                    txtFullname.Text = "Полное имя";
                }
                else
                txtFullname.Text = "Fullname";
            }
        }
        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                if (lblLanguage.Text == "Russian")
                {
                    txtPassword.Text = "Пароль";
                }
                else
                    txtPassword.Text = "Password";
                txtPassword.isPassword = false;
            }
            else
                txtPassword.isPassword = true;
        }
        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password" || txtPassword.Text == "Пароль")
            {
                txtPassword.Text = "";
                txtPassword.isPassword = true;
            }
            else
                txtPassword.isPassword = true;
        }
        private void txtConfirmPass_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfirmPass.Text))
            {
                if (lblLanguage.Text == "Russian")
                {
                    txtConfirmPass.Text = "Подтвердите пароль";
                    txtConfirmPass.isPassword = false;
                }
                else
                    txtConfirmPass.Text = "Confirm Password";
                txtConfirmPass.isPassword = false;
            }
        }
        private void txtConfirmPass_Enter(object sender, EventArgs e)
        {
            if (txtConfirmPass.Text == "Confirm Password" || txtConfirmPass.Text == "Подтвердите пароль")
            {
                txtConfirmPass.Text = "";
                txtConfirmPass.isPassword = true;
            }
            else
                txtConfirmPass.isPassword = true;
        }
        private void cmbUsertype_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbUsertype.Text))
            {
                if (lblLanguage.Text == "Russian")
                {
                    cmbUsertype.Text = "Тип пользователя";
                }
                else
                cmbUsertype.Text="User Type";
            }
        }
        private void cmbUsertype_Enter(object sender, EventArgs e)
        {
            if(cmbUsertype.Text=="User Type"||cmbUsertype.Text== "Тип пользователя")
            {
                cmbUsertype.Text = "";
            }
        }
        private void UserModule_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion
    }
}
