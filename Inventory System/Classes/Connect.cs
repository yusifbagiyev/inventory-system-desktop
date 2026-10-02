using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_System.Classes
{
    /// <summary>Opens the app's SQL connections and closes the app when the server is gone or the user is suspended.</summary>
    public class Connect
    {
        private readonly static string con = AppSettings.ConnectionString;
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        // Connections opened through this instance, so CloseConnection can close them
        private readonly List<SqlConnection> openConnections = new List<SqlConnection>();
        /// <summary>Checks the user's suspension on every call, so a suspend takes effect at their next database action.</summary>
        public SqlConnection EstablishConnection(string fullname)
        {
            SqlConnection connect = new SqlConnection(con);
            openConnections.Add(connect);
            try
            {
                if (!String.IsNullOrEmpty(fullname))
                {
                    connect.Open();
                    string isSuspend = "";
                    string query = @"SELECT suspended FROM Users WHERE fullname=@fullname";
                    cm = new SqlCommand(query, connect);
                    cm.Parameters.AddWithValue("@fullname", fullname);
                    dr = cm.ExecuteReader();
                    while (dr.Read())
                    {
                        isSuspend = dr[0].ToString();
                    }
                    dr.Close();
                    if (isSuspend == "disabled")
                    {
                        MessageBox.Show("You are currently suspended and cannot perform this action.", "User Suspension", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Application.Exit();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Connection", "Server Problem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (MessageBox.Show("Do you want to reconnect to the server?", "Recover Connection", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    EstablishConnection(fullname);
                }
                else
                {
                    connect = null;
                    Logger.WriteUserLog(fullname, " | could not connect to the Server. | Error: " + ex.Message);
                    Application.Exit();
                }
            }
            return connect;
        }
        /// <summary>Opens a connection without the suspension check, for the sign-in window and the log.</summary>
        public SqlConnection Login()
        {
            SqlConnection connect = new SqlConnection(con);
            openConnections.Add(connect);
            try
            {
                connect.Open();
            }
            catch
            {
                MessageBox.Show("No Connection", "Server Problem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                connect = null;
                Application.Exit();
            }
            return connect;
        }
        public SqlConnection CloseConnection()
        {
            SqlConnection last = null;
            foreach (var connect in openConnections)
            {
                connect.Close();
                connect.Dispose();
                last = connect;
            }
            openConnections.Clear();
            return last;
        }
    }
}
