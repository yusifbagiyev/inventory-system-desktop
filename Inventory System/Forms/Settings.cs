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
    public partial class Settings : Form
    {
        private readonly Connect connect = new Connect();
        SqlCommand cm = new SqlCommand();
        SqlCommand cn = new SqlCommand();
        SqlDataReader dr;
        private string LoadID()
        {
            try
            {
                string _ID = "";
                cm = new SqlCommand("SELECT ID FROM Users WHERE fullname=@fullname", connect.EstablishConnection(lblFullname.Text));
                cm.Parameters.AddWithValue("@fullname",lblFullname.Text);
                dr=cm.ExecuteReader();
                while (dr.Read())
                {
                    _ID = dr[0].ToString();
                }
                dr.Close();
                connect.CloseConnection();
                return _ID;
            }
            catch (Exception ex)
            {
                Logger.WriteUserLog(lblFullname.Text, " | Error is occured when loading categories in Category Panel. | Error is: " + ex.Message);
                Logger.WriteAllLog(lblFullname.Text, " | Error is occured when loading categories in Category Panel. | Error is: " + ex.Message);
                throw;
            }
        }
        private string OldPassword()
        {
            string password = "";
            cn = new SqlCommand("SELECT password FROM Users WHERE fullname=@fullname", connect.EstablishConnection(lblFullname.Text));
            cn.Parameters.AddWithValue("@fullname",lblFullname.Text);
            dr = cn.ExecuteReader();
            while (dr.Read())
            {
                password = dr[0].ToString();
            }
            dr.Close();
            connect.CloseConnection();
            return password;
        }
        public Settings(string fullname,string language)
        {
            InitializeComponent(); 
            lblFullname.Text = fullname;
            lblLang.Text = language;
            txtFulName.Text = fullname;
            lblUserId.Text = LoadID();
            this.KeyPreview = true;
        }
        private async Task SaveSettings()
        {
            if (string.IsNullOrEmpty(txtOldPass.Text) || string.IsNullOrEmpty(txtNewPass.Text) || string.IsNullOrEmpty(txtConfirmPass.Text))
            {
                MessageBox.Show("Please fill !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtNewPass.Text != txtConfirmPass.Text)
            {
                MessageBox.Show("Password did not Match !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var key = AppSettings.PasswordKey;
            var user_oldpassword = Cryptography.EncryptString(key, txtOldPass.Text);
            if (OldPassword() != user_oldpassword)
            {
                MessageBox.Show("Your old password is incorrect !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (OldPassword() == user_oldpassword)
            {
                if (MessageBox.Show("Are you sure you want to update your password ?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("UPDATE Users SET fullname = @fullname, password=@password WHERE ID=@ID", connect.EstablishConnection(lblFullname.Text));
                    cm.Parameters.AddWithValue("@ID", lblUserId.Text);
                    cm.Parameters.AddWithValue("@fullname", txtFulName.Text);
                    var user_password = Cryptography.EncryptString(key, txtNewPass.Text);
                    cm.Parameters.AddWithValue("@password", user_password);
                    cm.ExecuteNonQuery();
                    connect.CloseConnection();
                    await Task.Delay(10);
                    MessageBox.Show("Account has been successfully updated!");
                    Logger.WriteUserLog(lblFullname.Text, " updated a user with Fullname [" + txtFulName.Text + "] in the Users Table");
                    Logger.WriteAllLog(lblFullname.Text, " updated a user with Fullname [" + txtFulName.Text + "] in the Users Table");
                    this.Dispose();
                }
            }
        }
        private async Task LanguageOption()
        {
            try
            {
                if (!String.IsNullOrEmpty(cmbLang.Text))
                {
                    cm = new SqlCommand("UPDATE Users SET language=@language WHERE fullname=@fullname", connect.EstablishConnection(lblFullname.Text));
                    cm.Parameters.AddWithValue("language", cmbLang.Text);
                    cm.Parameters.AddWithValue("fullname", lblFullname.Text);
                    cm.ExecuteNonQuery();
                    MessageBox.Show("Your Language has changed succesfully. Please login to the program again");
                }
                else
                {
                    MessageBox.Show("Please select a language !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteUserLog(lblFullname.Text, "Error occured when changing language : " + ex + "user is:" + lblFullname.Text);
                Logger.WriteAllLog(lblFullname.Text, "Error occured when changing language : " + ex + "user is:" + lblFullname.Text);
            }
            finally
            {
                connect.CloseConnection();
                await Task.Delay(10);
            }
        }
        private void btnSave_Click(object sender, EventArgs e) => _=SaveSettings();
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e) => _ = LanguageOption();
        private void txtConfirmPass_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfirmPass.Text))
            {
                if (lblLang.Text == "Russian")
                {
                    txtConfirmPass.Text = "Подтвердите пароль";
                }
                else
                {
                    txtConfirmPass.Text = "Confirm Password";
                }
                txtConfirmPass.UseSystemPasswordChar = false;
            }
        }
        private void txtConfirmPass_Enter(object sender, EventArgs e)
        {
            if (txtConfirmPass.Text == "Confirm Password"||txtConfirmPass.Text== "Подтвердите пароль")
            {
                txtConfirmPass.Text = "";
                txtConfirmPass.UseSystemPasswordChar = true;
            }
        }
        private void txtNewPass_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPass.Text))
            {
                if (lblLang.Text == "Russian")
                {
                    txtNewPass.Text = "Новый пароль";
                }
                else
                {
                    txtNewPass.Text = "New Password";
                }
                txtNewPass.UseSystemPasswordChar = false;
            }
        }
        private void txtNewPass_Enter(object sender, EventArgs e)
        {
            if (txtNewPass.Text == "New Password"||txtNewPass.Text== "Новый пароль")
            {
                txtNewPass.Text = "";
                txtNewPass.UseSystemPasswordChar = true;
            }
        }
        private void txtOldPass_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOldPass.Text))
            {
                if (lblLang.Text == "Russian")
                {
                    txtOldPass.Text = "Старый пароль";
                }
                else
                {
                    txtOldPass.Text = "Old Password";
                }
                txtOldPass.UseSystemPasswordChar = false;
            }
        }
        private void txtOldPass_Enter(object sender, EventArgs e)
        {
            if (txtOldPass.Text == "Old Password"||txtOldPass.Text== "Старый пароль")
            {
                txtOldPass.Text = "";
                txtOldPass.UseSystemPasswordChar = true;
            }
        }
        private void txtFulName_Enter(object sender, EventArgs e)
        {
            if (txtFulName.Text == "Fullname"||txtFulName.Text== "Полное имя")
            {
                txtFulName.Text = "";
            }
        }
        private void txtFulName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFulName.Text))
            {
                if (lblLang.Text == "Russian")
                {
                    txtFulName.Text = "Полное имя";
                }
                else
                txtFulName.Text = "Fullname";
            }
        }
        private void cmbLang_Enter(object sender, EventArgs e)
        {
            if(cmbLang.Text =="Select a language"||cmbLang.Text== "Выберите язык")
            {
                cmbLang.Text = "";
            }
        }
        private void cmbLang_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbLang.Text))
            {
                if (lblLang.Text == "Russian")
                {
                    cmbLang.Text = "Выберите язык";
                }
                else
                cmbLang.Text = "Select a language";
            }
        }
        private void Settings_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(this, EventArgs.Empty);  // Trigger the Click event
                e.SuppressKeyPress = true;  // Prevent the default behavior
                e.Handled = true;// Stops the event from being passed to the control
            }
        }
    }
}