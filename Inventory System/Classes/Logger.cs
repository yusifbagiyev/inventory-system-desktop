using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_System.Classes
{
    public class Logger
    {
        private static readonly string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logfile.txt");
        /// <summary>Records an action in the shared Log table on the server.</summary>
        public static void WriteAllLog(string fullname, string message)
        {
            Connect connect = new Connect();
            try
            {
                SqlCommand cm = new SqlCommand("INSERT INTO Log(Time,Logs,fullname)VALUES(@Time,@Logs,@fullname)", connect.Login());
                cm.Parameters.AddWithValue("@Time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cm.Parameters.AddWithValue("@Logs", message);
                cm.Parameters.AddWithValue("@fullname", fullname);
                cm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex);
            }
            finally
            {
                connect.CloseConnection();
            }
        }
        /// <summary>Appends to logfile.txt next to the exe, which still works when the server is unreachable.</summary>
        public static void WriteUserLog(string fullname, string message)
        {
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
                try
                {
                    writer.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} | User: {fullname} | {message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error writing to log file: " + ex.Message, "Log Problem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    writer.Close();
                }
        }
    }
}
