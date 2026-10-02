using Inventory_System.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_System.Forms
{
    public partial class Login : Form
    {
        private readonly Connect connect = new Connect();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        private string _userType;
        private string _fullName;
        private string _isSuspend;
        private string _haveSession;
        private string _language;
        public Login()
        {
            InitializeComponent();
            _=LoadFullname();
            this.KeyPreview = true;
        }
        private async Task LoadFullname()
        {
            try
            {
                txtUsername.Items.Clear();
                cm = new SqlCommand("SELECT fullname FROM Users", connect.Login());
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    txtUsername.Items.Add(dr["fullname"].ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.WriteUserLog("System"," | Error is occured when loading fullname in Login Panel. | Error is: " + ex.Message);
                Logger.WriteAllLog("System", " | Error is occured when loading fullname in Login Panel. | Error is: " + ex.Message);
            }
            finally
            {
                dr.Close();
                connect.CloseConnection();
                await Task.Delay(10);
            }
        }
        private async Task SearchForSuspend()
        {
            try
            {
                cm = new SqlCommand("SELECT suspended FROM Users WHERE fullname = @fullname", connect.Login());
                cm.Parameters.AddWithValue("@fullname", txtUsername.Text);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    _isSuspend = dr["suspended"].ToString();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteUserLog("System", " | Error is occured when searching for suspend user in Login Panel. | Error is: " + ex.Message);
                Logger.WriteAllLog("System", " | Error is occured when searching for suspend user in Login Panel. | Error is: " + ex.Message);
            }
            finally
            {
                dr.Close();
                connect.CloseConnection();
                await Task.Delay(10);
            }
        }
        private async Task CheckSession()
        {
            try
            {
                cm = new SqlCommand("SELECT session FROM Users WHERE fullname =@fullname", connect.Login());
                cm.Parameters.AddWithValue("@fullname", txtUsername.Text);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    _haveSession = dr[0].ToString();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteUserLog("System", " | Error is occured when checking session in Login Panel. | Error is: " + ex.Message);
                Logger.WriteAllLog("System", " | Error is occured when checking session in Login Panel. | Error is: " + ex.Message);
            }
            finally
            {
                dr.Close();
                connect.CloseConnection();
                await Task.Delay(10);
            }
        }
        private async Task UpdateUserSession(string fullName)
        {
            try
            {
                using (SqlCommand cm = new SqlCommand("UPDATE Users SET online='online', session=@session, ip_address=@ip_address WHERE fullname=@fullname", connect.Login()))
                {
                    cm.Parameters.AddWithValue("@session", Dns.GetHostName());
                    cm.Parameters.AddWithValue("@ip_address", GetClientIPAddress());
                    cm.Parameters.AddWithValue("@fullname", fullName);
                    cm.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteUserLog("System", " | Error is occured when updating user session in Login Panel. | Error is: " + ex.Message);
                Logger.WriteAllLog("System", " | Error is occured when updating user session in Login Panel. | Error is: " + ex.Message);
            }
            finally
            {
                connect.CloseConnection();
                await Task.Delay(10);
            }
        }
        private string GetClientIPAddress()
        {
            try
            {
                var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(AppSettings.ServerHost, 1433);
                var ipEndPoint = socket.LocalEndPoint as IPEndPoint;
                return ipEndPoint.Address.ToString();
            }
            catch (Exception ex)
            {
                // No TCP route to the server (e.g. LocalDB uses named pipes): fall back to this machine's own address.
                Logger.WriteAllLog("System", " | Could not reach the server to read the client IP; using the local address. | " + ex.Message);
                return Dns.GetHostAddresses(Dns.GetHostName())
                          .FirstOrDefault(a => a.AddressFamily == AddressFamily.InterNetwork)?.ToString() ?? "127.0.0.1";
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            _=SearchForSuspend();
            _ = CheckSession();
            if (_isSuspend != "yes")
            {
                cm = new SqlCommand("SELECT * FROM Users WHERE fullname=@fullname AND password=@password", connect.Login());
                var key = AppSettings.PasswordKey;
                var user_password = Cryptography.EncryptString(key, txtPassword.Text);
                cm.Parameters.AddWithValue("@fullname", txtUsername.Text);
                cm.Parameters.AddWithValue("@password", user_password);
                dr = cm.ExecuteReader();
                if (!dr.HasRows)
                {
                    MessageBox.Show("Invalid username or password!", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logger.WriteAllLog("System"," Fullname: [" + txtUsername.Text + "] failed to sign in (wrong username or password)");
                    dr.Close();
                    connect.CloseConnection();
                    return;
                }
                while (dr.Read())
                {
                    _fullName = dr["fullname"].ToString();
                    _userType = dr["type"].ToString();
                    _language = dr["language"].ToString();
                    if (_userType == "Admin")
                    {
                        if (String.IsNullOrEmpty(_haveSession))
                        {
                            this.Hide();
                            LoginTitle loginForm = new LoginTitle(_userType, _fullName, _language);
                            loginForm.Show();
                        }
                        else
                        {
                            MessageBox.Show("You logged in another computer with this hostname: " + _haveSession, "User Active", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dr.Close();
                            connect.CloseConnection();
                            return;
                        }
                    }
                    else if (_userType == "User")
                    {
                        if (string.IsNullOrEmpty(_haveSession))
                        {
                            this.Hide();
                            LoginTitle loginForm = new LoginTitle(_userType, _fullName, _language);
                            loginForm.Show();
                        }
                        else
                        {
                            MessageBox.Show("You logged in another computer with this hostname: " + _haveSession, "User Active", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                dr.Close();
                _=UpdateUserSession(_fullName);
                Logger.WriteUserLog(_fullName, " logged in to the system with " + GetClientIPAddress());
                Logger.WriteAllLog(_fullName, " logged in to the system with " + GetClientIPAddress());
            }
            else
            {
                MessageBox.Show("You are currently suspended and cannot perform this action.", "User Suspension", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            connect.CloseConnection();
        }
        private void btnMinimize_Click(object sender, EventArgs e)=> this.WindowState = FormWindowState.Minimized;
        private void btnExit_Click(object sender, EventArgs e)=>Application.Exit();
        #region Design
        //To control Login Panel
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(this, EventArgs.Empty);  // Trigger the Click event
                e.SuppressKeyPress = true;  // Prevent the default behavior
                e.Handled = true;// Stops the event from being passed to the control
            }
        }
        private void txtPassword_DragEnter(object sender, DragEventArgs e)
        {
            btnLogin_Click(sender, e);
        }
        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Fullname")
            {
                txtUsername.Text = "";
            }
        }
        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                txtUsername.Text = "Fullname";
            }
        }
        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Password";
                txtPassword.UseSystemPasswordChar = true;
            }
        }
        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
                txtPassword.UseSystemPasswordChar = true;
            }
        }
        #endregion
    }
}
