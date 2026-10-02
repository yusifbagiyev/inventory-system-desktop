using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_System.Classes
{
    public class Connect
    {
        private readonly static string con = AppSettings.ConnectionString;
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public SqlConnection EstablishConnection(string fullname)
        {
            SqlConnection connect = new SqlConnection(con);
            try
            {
                if (!String.IsNullOrEmpty(fullname))
                {
                    connect.Open(); // Attempt to open the connection
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
            catch (Exception ex) // Catch any SQL-related exceptions
            {
                MessageBox.Show("No Connection", "Server Problem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (MessageBox.Show("Do you want to reconnect to the server?", "Recover Connection", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    EstablishConnection(fullname);
                }
                else
                {
                    connect = null; // Set connection to null if there's an error
                    Logger.WriteUserLog(fullname, " | could not connect to the Server. | Error: " + ex.Message);
                    Application.Exit();
                }
            }
            return connect;
        }
        public SqlConnection Login()
        {
            SqlConnection connect = new SqlConnection(con);
            try
            {
                connect.Open(); // Attempt to open the connection
            }
            catch // Catch any SQL-related exceptions
            {
                MessageBox.Show("No Connection", "Server Problem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                connect = null; // Set connection to null if there's an error
                Application.Exit();
            }
            return connect;
        }
        public SqlConnection CloseConnection()
        {
            SqlConnection connect = new SqlConnection(con);
            connect.Close();
            return connect;
        }
    }
}
