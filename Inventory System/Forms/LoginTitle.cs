using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_System.Forms
{
    /// <summary>Splash screen after sign-in that opens the main menu once its progress bar is full.</summary>
    public partial class LoginTitle : Form
    {
        public string fullname;
        public string username;
        public string language;
        public LoginTitle(string username, string fullname, string language)
        {
            // The UI culture is set before InitializeComponent so the forms load the user's language from here on
            if (language == "Russian")
            {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ru-RU");
            }
            else if (language == "English")
            {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            }
            InitializeComponent();
            timer1.Enabled = true;
            progressBar1.Visible = true;
            this.fullname = fullname;
            this.username = username;
            this.language = language;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value == progressBar1.Maximum)
            {
                timer1.Enabled = false;
                this.Hide();
                Main_Menu main = new Main_Menu(language);
                main.lblUser.Text = username;
                main.lblFullname.Text = fullname;
                main.lblLanguage.Text = language;
                main.btnFullName.Text = fullname;
                main.Show();
            }
            else
            {
                progressBar1.Value = progressBar1.Value + 5;
            }
        }
    }
}
