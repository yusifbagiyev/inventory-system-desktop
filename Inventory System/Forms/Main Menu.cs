using Inventory_System.Classes;
using Inventory_System.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_System.Forms
{
    /// <summary>Main window whose side menu opens each page as a child form inside the main panel.</summary>
    public partial class Main_Menu : Form
    {
        private readonly Connect connect = new Connect();
        SqlCommand cm = new SqlCommand();
        public Form activeForm;
        public Main_Menu(string language)
        {
            InitializeComponent();
            if (language == "Russian")
            {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ru-RU");
            }
            else if (language == "English")
            {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            }
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        /// <summary>Turns a child form's Text into the page title shown in the top bar.</summary>
        private async Task ChangeFormName(string childForm)
        {
            if (childForm == "İnformation")
            {
                if (lblLanguage.Text == "Russian")
                    childForm = "Информация о продукции";
                else
                    childForm = "Information about Products";
            }
            if (childForm == "TheProducts")
            {
                if (lblLanguage.Text == "Russian")
                    childForm = "Все продукты";
                else
                    childForm = "All Products";
            }
            if (childForm == "SearchByDepartment")
            {
                if (lblLanguage.Text == "Russian")
                    childForm = "Поиск продуктов в отделе";
                else
                    childForm = "Search products in department";
            }
            if (childForm == "SearchForWorker")
            {
                if (lblLanguage.Text == "Russian")
                    childForm = "Поиск продуктов в рабочий";
                else
                    childForm = "Search products in Worker";
            }
            if (childForm == "Useless")
            {
                if (lblLanguage.Text == "Russian")
                    childForm = "Бесполезные продукты";
                else
                    childForm = "Useless Products";
            }
            if (childForm == "LostProducts")
            {
                if (lblLanguage.Text == "Russian")
                    childForm = "Потерянные продукты";
                else
                    childForm = "Lost Products";
            }
            if (childForm == "Routes")
            {
                if (lblLanguage.Text == "Russian")
                    childForm = "Маршрут продукта";
                else
                    childForm = "Route a product";
            }
            if (childForm == "Category")
            {
                if (lblLanguage.Text == "Russian")
                    childForm = "Категория";
                else
                    childForm = "Category";
            }
            if (childForm == "Departments")
            {
                if (lblLanguage.Text == "Russian")
                    childForm = "Отделы";
                else
                    childForm = "Departments";
            }
            if (childForm == "User")
            {
                if (lblLanguage.Text == "Russian")
                    childForm = "Пользователи управления";
                else
                    childForm = "Control Users";
            }
            if (childForm == "Settings")
            {
                if (lblLanguage.Text == "Russian")
                    childForm = "Изменить настройки для пользователя";
                else
                    childForm = "Change settings for user";
            }
            if (childForm == "Recycle")
            {
                if (lblLanguage.Text == "Russian")
                    childForm = "Удаленные продукты";
                else
                    childForm = "Removed products";
            }
            lblHome.Text = childForm;
            await Task.Delay(10);
        }
        private async Task OpenChildForm(Form childForm, object btnSender)
        {
            if (ActiveForm != null)
            {
                try
                {
                    activeForm = childForm;
                    childForm.TopLevel = false;
                    childForm.FormBorderStyle = FormBorderStyle.None;
                    childForm.Dock = DockStyle.Fill;
                    this.panelMain.Controls.Add(childForm);
                    this.panelMain.Tag = childForm;
                    await ChangeFormName(childForm.Text);
                    childForm.BringToFront();
                    childForm.Show();
                }
                // Clicking menu items in quick succession can try to show a form the next click already closed
                catch (ObjectDisposedException)
                {
                    MessageBox.Show("Be patient. Please click one by one : ", "Object is disposed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        #region Design
        private async Task NormalPanelConf()
        {
            btn_Products.Visible = true;
            btnRoutes.Visible = true;
            btnCategory.Visible = true;
            btnDepartments.Visible = true;
            btnUser.Visible = true;
            btnSettings.Visible = true;

            panelProducts.Visible = false;
            btnRoute_Copy.Visible = false;
            btnCategory_Copy.Visible = false;
            btnDepartment_Copy.Visible = false;
            btnUser_Copy.Visible = false;
            btnSettings_Copy.Visible = false;

            btnRoutes.Location = new Point(35, 199);
            btnCategory.Location = new Point(35, 259);
            btnDepartments.Location = new Point(35, 319);
            btnUser.Location = new Point(35, 379);
            btnSettings.Location = new Point(35, 441);
            await Task.Delay(10);
        }
        // Products opens a sub-menu, so every button below it moves down to make room
        private async Task ExpandPanelConf()
        {
            panelProducts.Visible = true;
            btnLeftThinButton_Products.Visible = true;
            btnRoutes.Visible = true;
            btnCategory.Visible = true;
            btnDepartments.Visible = true;
            btnUser.Visible = true;
            btnSettings.Visible = true;

            btn_Products.Visible = false;
            btnRoute_Copy.Visible = false;
            btnCategory_Copy.Visible = false;
            btnDepartment_Copy.Visible = false;
            btnUser_Copy.Visible = false;
            btnSettings_Copy.Visible = false;

            panelProducts.Location = new Point(35, 139);
            btnRoutes.Location = new Point(35, 339);
            btnCategory.Location = new Point(35, 399);
            btnDepartments.Location = new Point(35, 459);
            btnUser.Location = new Point(35, 519);
            btnSettings.Location = new Point(35, 579);
            await Task.Delay(10);
        }
        // Thin buttons are the bars beside the menu that mark the open page
        private async Task NotVisibleThinButton()
        {
            btnLeftThinButton_Products.Visible = false;
            btnLeftThin_Routes.Visible = false;
            btnLeftThin_Category.Visible = false;
            btnLeftThin_Department.Visible = false;
            btnLeftThin_User.Visible = false;
            btnLeftThin_Settings.Visible = false;
            await Task.Delay(10);
        }
        // Lets the borderless window be dragged by its body or top bar
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void Main_Menu_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion
        private void CloseActiveForm()
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            if (lblLanguage.Text == "Russian")
                lblHome.Text = "ГЛАВНАЯ";
            else
                lblHome.Text = "Home";
        }
        private async void btn_Products_Click(object sender, EventArgs e)
        {
            if (btnLeftThinButton_Products.Visible == true)
            {
                await NotVisibleThinButton();
            }
            else
            {
                await NotVisibleThinButton();
                btnLeftThinButton_Products.Visible = true;
            }
            await ExpandPanelConf();
            CloseActiveForm();
            await OpenChildForm(new Forms.İnformation(lblFullname.Text, lblLanguage.Text), sender);
        }
        private async void btnColorProducts_Click(object sender, EventArgs e)
        {
            await NormalPanelConf();
            CloseActiveForm();
            btnLeftThinButton_Products.Visible = false;
        }
        private async void btnAllProducts_Click(object sender, EventArgs e)
        {
            CloseActiveForm();
            await OpenChildForm(new Forms.TheProducts(lblUser.Text, lblFullname.Text, lblLanguage.Text), sender);
        }
        private async void btnRoutes_Click(object sender, EventArgs e)
        {
            await NormalPanelConf();
            if (btnLeftThin_Routes.Visible == true)
            {
                await NotVisibleThinButton();
            }
            else
            {
                await NotVisibleThinButton();
                btnLeftThin_Routes.Visible = true;
            }
            btnRoute_Copy.Visible = true;
            btnRoute_Copy.Location = new Point(35, 199);
            btnRoutes.Visible = false;

            CloseActiveForm();
            await OpenChildForm(new Forms.Routes(lblUser.Text, lblFullname.Text, lblLanguage.Text), sender);
        }
        // A _Copy button is the highlighted twin shown while its page is open, and clicking it closes the page
        private async void btnRoute_Copy_Click(object sender, EventArgs e)
        {
            if (btnLeftThin_Routes.Visible == true)
            {
                await NotVisibleThinButton();
            }
            else
            {
                await NotVisibleThinButton();
                btnLeftThin_Routes.Visible = true;
            }
            await NormalPanelConf();
            CloseActiveForm();
        }
        private async void btnCategory_Click(object sender, EventArgs e)
        {
            await NormalPanelConf();
            if (btnLeftThin_Category.Visible == true)
            {
                await NotVisibleThinButton();
            }
            else
            {
                await NotVisibleThinButton();
                btnLeftThin_Category.Visible = true;
            }
            btnCategory_Copy.Visible = true;
            btnCategory_Copy.Location = new Point(35, 259);
            btnCategory.Visible = false;

            CloseActiveForm();
            await OpenChildForm(new Forms.Category(lblFullname.Text, lblLanguage.Text), sender);
        }
        private async void btnCategory_Copy_Click(object sender, EventArgs e)
        {
            if (btnLeftThin_Category.Visible == true)
            {
                await NotVisibleThinButton();
            }
            else
            {
                await NotVisibleThinButton();
                btnLeftThin_Category.Visible = true;
            }
            await NormalPanelConf();
            CloseActiveForm();
        }
        private async void btnDepartments_Click(object sender, EventArgs e)
        {
            await NormalPanelConf();
            if (btnLeftThin_Department.Visible == true)
            {
                await NotVisibleThinButton();
            }
            else
            {
                await NotVisibleThinButton();
                btnLeftThin_Department.Visible = true;
            }
            btnDepartment_Copy.Visible = true;
            btnDepartment_Copy.Location = new Point(35, 319);
            btnDepartments.Visible = false;

            CloseActiveForm();
            await OpenChildForm(new Forms.Department(lblFullname.Text, lblLanguage.Text), sender);
        }
        private async void btnDepartment_Copy_Click(object sender, EventArgs e)
        {
            if (btnLeftThin_Department.Visible == true)
            {
                await NotVisibleThinButton();
            }
            else
            {
                await NotVisibleThinButton();
                btnLeftThin_Department.Visible = true;
            }
            await NormalPanelConf();
            CloseActiveForm();
        }
        private async void btnUser_Click(object sender, EventArgs e)
        {
            await NormalPanelConf();
            if (btnLeftThin_User.Visible == true)
            {
                await NotVisibleThinButton();
            }
            else
            {
                await NotVisibleThinButton();
                btnLeftThin_User.Visible = true;
            }
            btnUser_Copy.Visible = true;
            btnUser_Copy.Location = new Point(35, 379);
            btnUser.Visible = false;

            if (lblUser.Text == "Admin")
            {
                CloseActiveForm();
                await OpenChildForm(new Forms.User(lblFullname.Text, lblLanguage.Text), sender);
            }
            else
            {
                MessageBox.Show("You don't have an access", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private async void btnUser_Copy_Click(object sender, EventArgs e)
        {
            if (btnLeftThin_User.Visible == true)
            {
                await NotVisibleThinButton();
            }
            else
            {
                await NotVisibleThinButton();
                btnLeftThin_User.Visible = true;
            }
            await NormalPanelConf();
            CloseActiveForm();
        }
        private async void btnSettings_Click(object sender, EventArgs e)
        {
            await NormalPanelConf();
            if (btnLeftThin_Settings.Visible == true)
            {
                await NotVisibleThinButton();
            }
            else
            {
                await NotVisibleThinButton();
                btnLeftThin_Settings.Visible = true;
            }
            btnSettings_Copy.Visible = true;
            btnSettings_Copy.Location = new Point(35, 441);
            btnSettings.Visible = false;

            CloseActiveForm();
            await OpenChildForm(new Forms.Settings(lblFullname.Text, lblLanguage.Text), sender);
        }
        private async void btnSettings_Copy_Click(object sender, EventArgs e)
        {
            if (btnLeftThin_Settings.Visible == true)
            {
                await NotVisibleThinButton();
            }
            else
            {
                await NotVisibleThinButton();
                btnLeftThin_Settings.Visible = true;
            }
            await NormalPanelConf();
            CloseActiveForm();
        }
        private async void btnSearchByDep_Click(object sender, EventArgs e)
        {
            CloseActiveForm();
            await OpenChildForm(new Forms.SearchByDepartment(lblFullname.Text, lblLanguage.Text), sender);
        }
        private async void btnSearchForWorker_Click(object sender, EventArgs e)
        {
            CloseActiveForm();
            await OpenChildForm(new Forms.SearchForWorker(lblFullname.Text, lblLanguage.Text), sender);
        }
        private async void btnUseless_Click(object sender, EventArgs e)
        {
            CloseActiveForm();
            await OpenChildForm(new Forms.UselessProduct(lblFullname.Text, lblLanguage.Text), sender);
        }
        private async void btnLost_Click(object sender, EventArgs e)
        {
            CloseActiveForm();
            await OpenChildForm(new Forms.LostProducts(lblFullname.Text, lblLanguage.Text), sender);
        }
        private async Task Logout()
        {
            try
            {
                cm = new SqlCommand("UPDATE Users SET online=@online, ip_address=@ip_address,session=@session WHERE fullname LIKE @fullname", connect.Login());
                cm.Parameters.AddWithValue("@fullname", lblFullname.Text);
                cm.Parameters.AddWithValue("@session", "");
                cm.Parameters.AddWithValue("@ip_address", "");
                cm.Parameters.AddWithValue("@online", "offline");
                cm.ExecuteNonQuery();
                Logger.WriteUserLog(lblFullname.Text, " logged out of the system ");
                Logger.WriteAllLog(lblFullname.Text, " logged out of the system ");
            }
            catch (Exception ex)
            {
                Logger.WriteUserLog(lblFullname.Text, " | Error is occured when logging from account in Main Menu Panel. | Error is: " + ex.Message);
                Logger.WriteAllLog(lblFullname.Text, " | Error is occured when logging from account in Main Menu Panel. | Error is: " + ex.Message);
            }
            finally
            {
                connect.CloseConnection();
                await Task.Delay(10);
            }
        }
        private void Main_Menu_FormClosing(object sender, FormClosingEventArgs e)=>_=Logout();
        private void Watch_Tick(object sender, EventArgs e)
        {
            lblShowWatch.Text = String.Format("{0:HH:mm}", DateTime.Now);
            lblShowTime.Text = String.Format("{0:dd.MM.yy}", DateTime.Now);
        }
        private void btnExit_Click(object sender, EventArgs e)=>Application.Exit();
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.Close();
            Login login = new Login();
            login.Show();
            _ = Logout();
        }
        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
                this.WindowState = FormWindowState.Normal;
        }
        private void btnMinimize_Click(object sender, EventArgs e)=>this.WindowState = FormWindowState.Minimized;
    }
}
